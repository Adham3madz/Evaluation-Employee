
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public partial class PoliceOfficerForm : Form
    {
        private DbHelper dbHelper;
        private DataTable allManagersData; // To store all managers for filtering

        public PoliceOfficerForm()
        {
            InitializeComponent();
            dbHelper = new DbHelper();
            ApplyArabicTheme();
            LoadDepartments();
            LoadManagers();
            SetupFilterDepartmentComboBox();
        }

        private void ApplyArabicTheme()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "لوحة تحكم ضابط الشرطة";

            // Style buttons
            btnAddManager.BackColor = Color.FromArgb(0, 120, 215);
            btnAddManager.ForeColor = Color.White;
            btnAddManager.FlatStyle = FlatStyle.Flat;
            btnAddManager.FlatAppearance.BorderSize = 0;
            btnAddManager.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            btnEvaluateManager.BackColor = Color.FromArgb(0, 150, 136);
            btnEvaluateManager.ForeColor = Color.White;
            btnEvaluateManager.FlatStyle = FlatStyle.Flat;
            btnEvaluateManager.FlatAppearance.BorderSize = 0;
            btnEvaluateManager.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            btnViewLastEvaluation.BackColor = Color.FromArgb(156, 39, 176);
            btnViewLastEvaluation.ForeColor = Color.White;
            btnViewLastEvaluation.FlatStyle = FlatStyle.Flat;
            btnViewLastEvaluation.FlatAppearance.BorderSize = 0;
            btnViewLastEvaluation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnViewLastEvaluation.Text = "عرض آخر تقييم";

            // Style data grid
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RightToLeft = RightToLeft.Yes;

            // Placeholder text
            txtName.Text = "أدخل الاسم";
            txtName.ForeColor = Color.Gray;
            txtJobTitle.Text = "أدخل المسمى الوظيفي";
            txtJobTitle.ForeColor = Color.Gray;

            txtName.Font = new Font("Segoe UI", 12F);
            cmbDepartment.Font = new Font("Segoe UI", 12F);
            txtJobTitle.Font = new Font("Segoe UI", 12F);

            // Filter labels
            lblSearch.Text = "بحث باسم المدير:";
            lblFilterDepartment.Text = "القسم:";
            btnClearFilters.Text = "مسح الفلتر";
        }

        private void LoadDepartments()
        {
            try
            {
                string query = "SELECT DepartmentID, DepartmentName FROM Departments";
                DataTable dt = dbHelper.ExecuteQuery(query);

                cmbDepartment.DataSource = dt;
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentID";
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Text = "أدخل القسم";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الأقسام: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddManager_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text == "أدخل الاسم" ||
                cmbDepartment.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtJobTitle.Text) || txtJobTitle.Text == "أدخل المسمى الوظيفي")
            {
                MessageBox.Show("يرجى ملء جميع الحقول المطلوبة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int departmentId = Convert.ToInt32(cmbDepartment.SelectedValue);

                string employeeQuery = "INSERT INTO Employees (Name, DepartmentID, JobTitle, JoinDate, ManagerID) OUTPUT INSERTED.EmployeeID VALUES (@Name, @DepartmentID, @JobTitle, GETDATE(), NULL)";
                SqlParameter[] empParams = new SqlParameter[]
                {
                    new SqlParameter("@Name", txtName.Text),
                    new SqlParameter("@DepartmentID", departmentId),
                    new SqlParameter("@JobTitle", txtJobTitle.Text)
                };
                object empIdObj = dbHelper.ExecuteScalar(employeeQuery, empParams);
                if (empIdObj == null) throw new Exception("فشل في إدراج الموظف");

                int employeeId = Convert.ToInt32(empIdObj);

                string managerQuery = "INSERT INTO Managers (Name, DepartmentID, JobTitle, EmployeeID) VALUES (@Name, @DepartmentID, @JobTitle, @EmployeeID)";
                SqlParameter[] mgrParams = new SqlParameter[]
                {
                    new SqlParameter("@Name", txtName.Text),
                    new SqlParameter("@DepartmentID", departmentId),
                    new SqlParameter("@JobTitle", txtJobTitle.Text),
                    new SqlParameter("@EmployeeID", employeeId)
                };
                int rowsAffected = dbHelper.ExecuteNonQuery(managerQuery, mgrParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("تم إضافة المدير بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadManagers();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في إضافة المدير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadManagers()
        {
            try
            {
                string query = @"
        SELECT 
            m.ManagerID,
            m.Name,
            m.DepartmentID,
            m.JobTitle,
            m.EmployeeID,
            d.DepartmentName,
            ISNULL((
                SELECT TOP 1 e.TotalScore
                FROM OfficerManagerEvaluations e
                WHERE e.EvaluatedID = m.EmployeeID AND m.EmployeeID IS NOT NULL
                ORDER BY e.Date DESC
            ), 0) AS LastEvaluationScore
        FROM Managers m
        LEFT JOIN Departments d ON m.DepartmentID = d.DepartmentID
        ";

                allManagersData = dbHelper.ExecuteQuery(query);
                dataGridView1.DataSource = allManagersData;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dataGridView1.Columns.Contains("ManagerID"))
                    dataGridView1.Columns["ManagerID"].HeaderText = "معرف المدير";

                if (dataGridView1.Columns.Contains("Name"))
                    dataGridView1.Columns["Name"].HeaderText = "اسم المدير";

                if (dataGridView1.Columns.Contains("DepartmentID"))
                    dataGridView1.Columns["DepartmentID"].Visible = false;

                if (dataGridView1.Columns.Contains("DepartmentName"))
                    dataGridView1.Columns["DepartmentName"].HeaderText = "اسم القسم";

                if (dataGridView1.Columns.Contains("JobTitle"))
                    dataGridView1.Columns["JobTitle"].HeaderText = "المسمى الوظيفي";

                if (dataGridView1.Columns.Contains("EmployeeID"))
                    dataGridView1.Columns["EmployeeID"].Visible = false;

                if (dataGridView1.Columns.Contains("LastEvaluationScore"))
                    dataGridView1.Columns["LastEvaluationScore"].HeaderText = "أحدث تقييم";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل المديرين: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtName.Text = "أدخل الاسم";
            txtName.ForeColor = Color.Gray;
            cmbDepartment.SelectedIndex = -1;
            cmbDepartment.Text = "أدخل القسم";
            txtJobTitle.Text = "أدخل المسمى الوظيفي";
            txtJobTitle.ForeColor = Color.Gray;
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "أدخل الاسم")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = "أدخل الاسم";
                txtName.ForeColor = Color.Gray;
            }
        }

        private void txtJobTitle_Enter(object sender, EventArgs e)
        {
            if (txtJobTitle.Text == "أدخل المسمى الوظيفي")
            {
                txtJobTitle.Text = "";
                txtJobTitle.ForeColor = Color.Black;
            }
        }

        private void btnEvaluateManager_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد مدير للتقييم!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int employeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);
            string managerName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

            EvaluationForm evalForm = new EvaluationForm(employeeId, managerName, 0, 5);
            evalForm.ShowDialog();
            LoadManagers();
        }

        private void btnViewLastEvaluation_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد مدير!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int employeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);
            string managerName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

            ViewEvaluationForm evalForm = new ViewEvaluationForm(employeeId, managerName);
            evalForm.ShowDialog();
        }

        private void txtJobTitle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobTitle.Text))
            {
                txtJobTitle.Text = "أدخل المسمى الوظيفي";
                txtJobTitle.ForeColor = Color.Gray;
            }
        }

        #region Filtering and Search
        private void SetupFilterDepartmentComboBox()
        {
            try
            {
                string query = "SELECT DepartmentID, DepartmentName FROM Departments ORDER BY DepartmentName";
                DataTable dt = dbHelper.ExecuteQuery(query);

                // Add "جميع الأقسام" option
                DataRow allDepartmentsRow = dt.NewRow();
                allDepartmentsRow["DepartmentID"] = 0;
                allDepartmentsRow["DepartmentName"] = "جميع الأقسام";
                dt.Rows.InsertAt(allDepartmentsRow, 0);

                cmbFilterDepartment.DisplayMember = "DepartmentName";
                cmbFilterDepartment.ValueMember = "DepartmentID";
                cmbFilterDepartment.DataSource = dt;
                cmbFilterDepartment.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل قائمة الأقسام للفلترة: " + ex.Message);
            }
        }

        private void ApplyFilters()
        {
            if (allManagersData == null) return;

            DataView dv = allManagersData.DefaultView;
            string filterExpression = "";

            // Apply name filter
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                filterExpression += $"Name LIKE '%{txtSearch.Text}%'";
            }

            // Apply department filter
            if (cmbFilterDepartment.SelectedIndex > 0) // Not "All Departments"
            {
                string departmentName = cmbFilterDepartment.Text;
                if (!string.IsNullOrEmpty(filterExpression))
                    filterExpression += " AND ";
                filterExpression += $"DepartmentName = '{departmentName}'";
            }

            dv.RowFilter = filterExpression;
            dataGridView1.DataSource = dv.ToTable();

            // Reapply column headers
            if (dataGridView1.Columns.Contains("ManagerID"))
                dataGridView1.Columns["ManagerID"].HeaderText = "معرف المدير";

            if (dataGridView1.Columns.Contains("Name"))
                dataGridView1.Columns["Name"].HeaderText = "اسم المدير";

            if (dataGridView1.Columns.Contains("DepartmentID"))
                dataGridView1.Columns["DepartmentID"].Visible = false;

            if (dataGridView1.Columns.Contains("DepartmentName"))
                dataGridView1.Columns["DepartmentName"].HeaderText = "اسم القسم";

            if (dataGridView1.Columns.Contains("JobTitle"))
                dataGridView1.Columns["JobTitle"].HeaderText = "المسمى الوظيفي";

            if (dataGridView1.Columns.Contains("EmployeeID"))
                dataGridView1.Columns["EmployeeID"].Visible = false;

            if (dataGridView1.Columns.Contains("LastEvaluationScore"))
                dataGridView1.Columns["LastEvaluationScore"].HeaderText = "أحدث تقييم";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbFilterDepartment.SelectedIndex = 0;
            // Filters will be cleared automatically through the event handlers
        }
        #endregion

        #region Print Functionality
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDoc = new PrintDocument();

                printDoc.PrintPage += (s, ev) =>
                {
                    // Print a header
                    ev.Graphics.DrawString("تقرير المديرين",
                        new Font("Arial", 16, FontStyle.Bold),
                        Brushes.Black, new PointF(100, 100));

                    // Print rows from DataGridView
                    float y = 150;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            // Build a line manually
                            string line = "";
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Visible)
                                {
                                    line += (cell.Value?.ToString() ?? "") + " | ";
                                }
                            }

                            ev.Graphics.DrawString(line, new Font("Arial", 10),
                                Brushes.Black, new PointF(100, y));
                            y += 25;
                        }
                    }
                };

                printDialog.Document = printDoc;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الطباعة: " + ex.Message);
            }
        }
        #endregion
    }
}
