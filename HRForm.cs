using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public partial class HRForm : Form
    {
        private readonly DbHelper dbHelper;
        private DataTable allEmployeesData; // To store all employees for filtering

        public HRForm()
        {
            InitializeComponent();
            dbHelper = new DbHelper();
            ApplyArabicTheme();
            LoadDepartments();
            LoadEmployees();
            SetupFilterDepartmentComboBox();
        }

        #region UI Styling
        private void ApplyArabicTheme()
        {
            // Form setup
            this.Text = "لوحة تحكم الموارد البشرية";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Labels
            lblTitle.Text = "لوحة تحكم الموارد البشرية";
            lblEmployeeName.Text = "اسم الموظف:";
            lblDepartment.Text = "القسم:";
            lblJobTitle.Text = "المسمى الوظيفي:";
            lblJoinDate.Text = "تاريخ الانضمام:";

            // Filter labels
            lblSearch.Text = "بحث باسم الموظف:";
            lblFilterDepartment.Text = "القسم:";
            btnClearFilters.Text = "مسح الفلتر";

            // DataGridView
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void StyleButton(Button btn, string text, Color bgColor)
        {
            btn.Text = text;
            btn.BackColor = bgColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }
        #endregion

        #region Employee Management
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtJobTitle.Text) ||
                cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى ملء جميع الحقول المطلوبة!");
                return;
            }

            try
            {
                string query = @"INSERT INTO Employees (Name, DepartmentID, JobTitle, JoinDate, ManagerID) 
                                 VALUES (@Name, @DepartmentID, @JobTitle, @JoinDate, @ManagerID)";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Name", txtName.Text),
                    new SqlParameter("@DepartmentID", (int)cmbDepartment.SelectedValue),
                    new SqlParameter("@JobTitle", txtJobTitle.Text),
                    new SqlParameter("@JoinDate", dateTimePicker1.Value),
                    new SqlParameter("@ManagerID", DBNull.Value) // HR does not assign manager here
                };

                if (dbHelper.ExecuteNonQuery(query, parameters) > 0)
                {
                    MessageBox.Show("تم إضافة الموظف بنجاح!");
                    ClearFields();
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في إضافة الموظف: " + ex.Message);
            }
        }
        #endregion

        #region Evaluations
        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedEmployee(out int employeeId, out string employeeName)) return;

            int evaluationTypeId = 2; // افتراضي: تقييم شهري للموارد البشرية
            new EvaluationForm(employeeId, employeeName, 0, evaluationTypeId).ShowDialog();

            LoadEmployees();
        }

        private void btnEditEvaluation_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedEmployee(out int employeeId, out string employeeName)) return;

            try
            {
                string query = @"SELECT TOP 1 EvaluationID
                                 FROM Evaluations 
                                 WHERE EmployeeID = @EmployeeID
                                 ORDER BY EvaluationID DESC";

                SqlParameter[] parameters = { new SqlParameter("@EmployeeID", employeeId) };
                DataTable dt = dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد تقييمات لهذا الموظف!");
                    return;
                }

                int evaluationId = Convert.ToInt32(dt.Rows[0]["EvaluationID"]);
                var editForm = new EmployeeEvaluationApp.EditScoresForm(evaluationId);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("تم التعديل بنجاح!");
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void btnViewAllEvaluations_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedEmployee(out int employeeId, out string employeeName)) return;
            new EvaluationDetailsForm(employeeId, employeeName, true).ShowDialog();
        }

        private void btnViewManagerEvaluation_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedEmployee(out int employeeId, out string employeeName)) return;

            string managerName = dataGridView1.SelectedRows[0].Cells["ManagerName"].Value?.ToString();

            if (string.IsNullOrEmpty(managerName))
            {
                MessageBox.Show("هذا الموظف لا يوجد له مدير مسجل!");
                return;
            }

            new EvaluationDetailsForm(employeeId, managerName, false).ShowDialog();
        }

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
                            // Build a line manually (no LINQ needed)
                            string line = "";
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                line += (cell.Value?.ToString() ?? "") + " | ";
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

        #region Data Loading
        private void LoadEmployees()
        {
            try
            {
                string query = @"
                    SELECT 
                        e.EmployeeID, 
                        e.Name, 
                        d.DepartmentName, 
                        e.JobTitle, 
                        e.JoinDate,
                        ISNULL(ev.TotalScore, 0) as TotalScore,
                        ISNULL(ev.MaxPossibleScore, 0) as MaxPossibleScore,
                        ISNULL(ev.Percentage, 0) as Percentage,
                        ISNULL(ev.Date, '') as LastEvaluationDate,
                        ISNULL(ev.Comments, '') as LastComments
                      
                    FROM Employees e 
                    INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
                    LEFT JOIN (
                        SELECT 
                            EmployeeID,
                            TotalScore,
                            MaxPossibleScore,
                            Percentage,
                            Date,
                            Comments,
                            ROW_NUMBER() OVER (PARTITION BY EmployeeID ORDER BY Date DESC) as rn
                        FROM Evaluations
                    ) ev ON e.EmployeeID = ev.EmployeeID AND ev.rn = 1
                    LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
                    ORDER BY e.Name";

                allEmployeesData = dbHelper.ExecuteQuery(query);
                dataGridView1.DataSource = allEmployeesData;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                RenameColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل بيانات الموظفين: " + ex.Message);
            }
        }

        private void RenameColumns()
        {
            if (dataGridView1.Columns.Contains("EmployeeID"))
                dataGridView1.Columns["EmployeeID"].HeaderText = "رقم الموظف";
            if (dataGridView1.Columns.Contains("Name"))
                dataGridView1.Columns["Name"].HeaderText = "اسم الموظف";
            if (dataGridView1.Columns.Contains("DepartmentName"))
                dataGridView1.Columns["DepartmentName"].HeaderText = "القسم";
            if (dataGridView1.Columns.Contains("JobTitle"))
                dataGridView1.Columns["JobTitle"].HeaderText = "المسمى الوظيفي";
            if (dataGridView1.Columns.Contains("JoinDate"))
                dataGridView1.Columns["JoinDate"].HeaderText = "تاريخ الانضمام";
            if (dataGridView1.Columns.Contains("TotalScore"))
                dataGridView1.Columns["TotalScore"].HeaderText = "المجموع";
            if (dataGridView1.Columns.Contains("MaxPossibleScore"))
                dataGridView1.Columns["MaxPossibleScore"].HeaderText = "الحد الأقصى";
            if (dataGridView1.Columns.Contains("Percentage"))
                dataGridView1.Columns["Percentage"].HeaderText = "النسبة";
            if (dataGridView1.Columns.Contains("LastEvaluationDate"))
                dataGridView1.Columns["LastEvaluationDate"].HeaderText = "تاريخ آخر تقييم";
            if (dataGridView1.Columns.Contains("LastComments"))
                dataGridView1.Columns["LastComments"].HeaderText = "ملاحظات أخيرة";
            if (dataGridView1.Columns.Contains("ManagerName"))
                dataGridView1.Columns["ManagerName"].HeaderText = "اسم المدير";
        }

        private void LoadDepartments()
        {
            try
            {
                string query = "SELECT DepartmentID, DepartmentName FROM Departments";
                DataTable dt = dbHelper.ExecuteQuery(query);

                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentID";
                cmbDepartment.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الأقسام: " + ex.Message);
            }
        }

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
        #endregion

        #region Filtering and Search
        private void ApplyFilters()
        {
            if (allEmployeesData == null) return;

            DataView dv = allEmployeesData.DefaultView;
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
            RenameColumns();
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

        #region Helpers
        private void ClearFields()
        {
            txtName.Clear();
            txtJobTitle.Clear();
            cmbDepartment.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
        }

        private bool TryGetSelectedEmployee(out int employeeId, out string employeeName)
        {
            employeeId = 0;
            employeeName = string.Empty;

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار موظف أولاً!");
                return false;
            }

            employeeId = (int)dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value;
            employeeName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            return true;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtJobTitle.Text = row.Cells["JobTitle"].Value.ToString();

            if (cmbDepartment.Items.Count > 0)
            {
                for (int i = 0; i < cmbDepartment.Items.Count; i++)
                {
                    DataRowView drv = (DataRowView)cmbDepartment.Items[i];
                    if (drv["DepartmentName"].ToString() == row.Cells["DepartmentName"].Value.ToString())
                    {
                        cmbDepartment.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (row.Cells["JoinDate"].Value != DBNull.Value)
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["JoinDate"].Value);
        }
        #endregion
    }
}
