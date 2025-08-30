using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace EmployeeManagementApp
{
    public partial class ManagerForm : Form
    {
        private int managerId;
        private DbHelper dbHelper;
        private string lastEvalPrintText = ""; // store last evaluation text for printing

        // 🔹 Printing objects
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        public ManagerForm(int managerId)
        {
            InitializeComponent();
            this.managerId = managerId;
            dbHelper = new DbHelper();
            ApplyArabicTheme();
            LoadEmployees();
            LoadDepartmentInfo();

            // 🔹 attach print event
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog.Document = printDocument;
        }

        private void ApplyArabicTheme()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "لوحة تحكم المدير";

            btnAddEmployee.BackColor = Color.FromArgb(0, 120, 215);
            btnAddEmployee.ForeColor = Color.White;
            btnAddEmployee.FlatStyle = FlatStyle.Flat;
            btnAddEmployee.FlatAppearance.BorderSize = 0;
            btnAddEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            btnEvaluateEmployee.BackColor = Color.FromArgb(0, 150, 136);
            btnEvaluateEmployee.ForeColor = Color.White;
            btnEvaluateEmployee.FlatStyle = FlatStyle.Flat;
            btnEvaluateEmployee.FlatAppearance.BorderSize = 0;
            btnEvaluateEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            btnViewLastEvaluation.BackColor = Color.FromArgb(255, 152, 0);
            btnViewLastEvaluation.ForeColor = Color.White;
            btnViewLastEvaluation.FlatStyle = FlatStyle.Flat;
            btnViewLastEvaluation.FlatAppearance.BorderSize = 0;
            btnViewLastEvaluation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RightToLeft = RightToLeft.Yes;

            label1.Text = "اسم الموظف:";
            label2.Text = "المسمى الوظيفي:";
            label3.Text = "تاريخ الانضمام:";
            btnAddEmployee.Text = "إضافة موظف";
            btnEvaluateEmployee.Text = "تقييم موظف";
            btnViewLastEvaluation.Text = "عرض آخر تقييم";
            groupBox1.Text = "بيانات الموظف الجديد";
            lblTitle.Text = "لوحة تحكم المدير";

            txtName.Text = "أدخل الاسم";
            txtName.ForeColor = Color.Gray;
            txtJobTitle.Text = "أدخل المسمى الوظيفي";
            txtJobTitle.ForeColor = Color.Gray;

            txtName.Font = new Font("Segoe UI", 12F);
            txtJobTitle.Font = new Font("Segoe UI", 12F);
            dateTimePicker1.Font = new Font("Segoe UI", 12F);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text == "أدخل الاسم" ||
                string.IsNullOrWhiteSpace(txtJobTitle.Text) || txtJobTitle.Text == "أدخل المسمى الوظيفي")
            {
                MessageBox.Show("يرجى ملء جميع الحقول المطلوبة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = @"INSERT INTO Employees (Name, DepartmentID, JobTitle, JoinDate, ManagerID) 
                                 VALUES (@Name, @DepartmentID, @JobTitle, @JoinDate, @ManagerID)";

                int departmentId = GetManagerDepartmentId();
                if (departmentId == 0)
                {
                    throw new Exception("لم يتم العثور على معرف القسم.");
                }

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", txtName.Text),
                    new SqlParameter("@DepartmentID", departmentId),
                    new SqlParameter("@JobTitle", txtJobTitle.Text),
                    new SqlParameter("@JoinDate", dateTimePicker1.Value),
                    new SqlParameter("@ManagerID", managerId)
                };

                int rowsAffected = dbHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("تم إضافة الموظف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في إضافة الموظف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEvaluateEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد موظف للتقييم!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int employeeId = (int)dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value;
            string employeeName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

            int evaluationTypeId = DetermineEvaluationType(employeeName);

            EvaluationForm evalForm = new EvaluationForm(employeeId, employeeName, managerId, evaluationTypeId);
            evalForm.ShowDialog();
            LoadEmployees();
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للتصدير.", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", FileName = "Evaluations.csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var sb = new System.Text.StringBuilder();

                        var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
                        sb.AppendLine(string.Join(",", headers.Select(c => c.HeaderText)));

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>();
                            sb.AppendLine(string.Join(",", cells.Select(c => c.Value?.ToString().Replace(",", "،"))));
                        }

                        System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), System.Text.Encoding.UTF8);
                        MessageBox.Show("تم تصدير البيانات إلى Excel بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التصدير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewLastEvaluation_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد موظف لعرض تفاصيل آخر تقييم!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int employeeId = (int)dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value;
            string employeeName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

            try
            {
                string evalQuery = @"SELECT TOP 1 e.EvaluationID, e.Date AS [التاريخ], 
                                            et.TypeName AS [نوع التقييم], 
                                            m.Name AS [اسم المدير], 
                                            e.TotalScore AS [الدرجة الإجمالية], 
                                            e.MaxPossibleScore AS [الدرجة القصوى], 
                                            e.Percentage AS [النسبة المئوية], 
                                            e.Comments AS [التعليقات] 
                                     FROM Evaluations e 
                                     LEFT JOIN EvaluationTypes et ON e.EvaluationTypeID = et.EvaluationTypeID 
                                     LEFT JOIN Managers m ON e.ManagerID = m.ManagerID 
                                     WHERE e.EmployeeID = @EmployeeID 
                                     ORDER BY e.Date DESC";

                SqlParameter[] evalParams = new SqlParameter[] { new SqlParameter("@EmployeeID", employeeId) };
                DataTable evalDt = dbHelper.ExecuteQuery(evalQuery, evalParams);

                if (evalDt.Rows.Count == 0)
                {
                    MessageBox.Show("لا يوجد تقييمات سابقة لهذا الموظف.", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow evalRow = evalDt.Rows[0];
                int evaluationId = Convert.ToInt32(evalRow["EvaluationID"]);

                string ratingsQuery = @"SELECT c.CriterionText AS [المعيار], 
                                               r.Score AS [الدرجة], 
                                               c.Points AS [الدرجة القصوى] 
                                        FROM Ratings r 
                                        INNER JOIN Criteria c ON r.CriterionID = c.CriterionID 
                                        WHERE r.EvaluationID = @EvaluationID";
                SqlParameter[] ratingsParams = new SqlParameter[] { new SqlParameter("@EvaluationID", evaluationId) };
                DataTable ratingsDt = dbHelper.ExecuteQuery(ratingsQuery, ratingsParams);

                lastEvalPrintText = $"تقرير التقييم للموظف: {employeeName}\n" +
                                    $"--------------------------------\n" +
                                    $"التاريخ: {Convert.ToDateTime(evalRow["التاريخ"]).ToString("yyyy-MM-dd")}\n" +
                                    $"نوع التقييم: {evalRow["نوع التقييم"]}\n" +
                                    $"اسم المدير: {evalRow["اسم المدير"]}\n" +
                                    $"الدرجة الإجمالية: {evalRow["الدرجة الإجمالية"]}/{evalRow["الدرجة القصوى"]}\n" +
                                    $"النسبة المئوية: {evalRow["النسبة المئوية"]}%\n" +
                                    $"التعليقات: {(evalRow["التعليقات"] != DBNull.Value ? evalRow["التعليقات"].ToString() : "لا توجد تعليقات")}\n\n" +
                                    $"تفاصيل المعايير:\n";

                foreach (DataRow row in ratingsDt.Rows)
                {
                    lastEvalPrintText += $" - {row["المعيار"]}: {row["الدرجة"]}/{row["الدرجة القصوى"]}\n";
                }

                DialogResult result = MessageBox.Show(lastEvalPrintText + "\n\nهل ترغب في طباعة هذا التقرير؟",
                                                      "تفاصيل آخر تقييم",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    printPreviewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في عرض تفاصيل آخر تقييم: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Draw organized report for printing
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // ===== Fonts & Brushes =====
            Font headerFont = new Font("Segoe UI", 18, FontStyle.Bold);
            Font subHeaderFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font bodyFont = new Font("Segoe UI", 11);
            Font footerFont = new Font("Segoe UI", 10, FontStyle.Italic);
            Brush brush = Brushes.Black;

            int y = 50;
            int leftMargin = e.MarginBounds.Left;
            int rightMargin = e.MarginBounds.Right;

            StringFormat rightAlign = new StringFormat()
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };

            StringFormat centerAlign = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // ===== Logo (top-left) =====
            try
            {
                Image logo = Properties.Resources.RoyalResortLogo; // Replace with your resource name
                int logoWidth = 100;
                int logoHeight = 100;
                int logoX = leftMargin; // Left side
                int logoY = y;

                e.Graphics.DrawImage(logo, new Rectangle(logoX, logoY, logoWidth, logoHeight));
            }
            catch { /* Ignore if not found */ }

            // ===== Report Title (centered) =====
            e.Graphics.DrawString("تقرير تقييم الموظف", headerFont, brush,
                new RectangleF(leftMargin, y, rightMargin - leftMargin, 40),
                centerAlign);
            y += 120;

            // ===== Employee Info (right aligned like Arabic format) =====
            string[] lines = lastEvalPrintText.Split('\n');
            foreach (string line in lines)
            {
                e.Graphics.DrawString(line, bodyFont, brush,
                    new RectangleF(leftMargin, y, rightMargin - leftMargin, 25),
                    rightAlign);
                y += 25;
            }

            y += 40;

            // ===== Comments (Boxes for each role) =====
            e.Graphics.DrawString("ملاحظات رئيس القسم:", subHeaderFont, brush, rightMargin, y, rightAlign);
            y += 20;
            e.Graphics.DrawRectangle(Pens.Black, leftMargin, y, rightMargin - leftMargin, 50);
            y += 70;

            e.Graphics.DrawString("ملاحظات مدير القسم:", subHeaderFont, brush, rightMargin, y, rightAlign);
            y += 20;
            e.Graphics.DrawRectangle(Pens.Black, leftMargin, y, rightMargin - leftMargin, 50);
            y += 70;

            e.Graphics.DrawString("ملاحظات مدير الدار:", subHeaderFont, brush, rightMargin, y, rightAlign);
            y += 20;
            e.Graphics.DrawRectangle(Pens.Black, leftMargin, y, rightMargin - leftMargin, 50);

            y += 80;

            // ===== Footer =====
            e.Graphics.DrawLine(Pens.Gray, leftMargin, e.MarginBounds.Bottom, rightMargin, e.MarginBounds.Bottom);
            e.Graphics.DrawString("", footerFont, Brushes.Gray,
                new RectangleF(leftMargin, e.MarginBounds.Bottom + 5, rightMargin - leftMargin, 20),
                centerAlign);
        }





        private void LoadEmployees()
        {
            try
            {
                string query = @"
SELECT 
    e.EmployeeID,
    e.Name,
    e.JobTitle,
    e.JoinDate,
    d.DepartmentName,
    ISNULL(SUM(o.TotalScore), 0) AS TotalScore
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
LEFT JOIN OfficerManagerEvaluations o ON o.EvaluatedID = e.EmployeeID
WHERE e.ManagerID = @ManagerID
GROUP BY 
    e.EmployeeID, e.Name, e.JobTitle, e.JoinDate, d.DepartmentName";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ManagerID", managerId)
                };

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dataGridView1.Columns.Contains("EmployeeID"))
                    dataGridView1.Columns["EmployeeID"].HeaderText = "معرف الموظف";

                if (dataGridView1.Columns.Contains("Name"))
                    dataGridView1.Columns["Name"].HeaderText = "اسم الموظف";

                if (dataGridView1.Columns.Contains("JobTitle"))
                    dataGridView1.Columns["JobTitle"].HeaderText = "المسمى الوظيفي";

                if (dataGridView1.Columns.Contains("JoinDate"))
                {
                    dataGridView1.Columns["JoinDate"].HeaderText = "تاريخ الانضمام";
                    dataGridView1.Columns["JoinDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                }

                if (dataGridView1.Columns.Contains("DepartmentName"))
                    dataGridView1.Columns["DepartmentName"].HeaderText = "اسم القسم";

                if (dataGridView1.Columns.Contains("TotalScore"))
                {
                    dataGridView1.Columns["TotalScore"].HeaderText = "إجمالي الدرجات";
                    dataGridView1.Columns["TotalScore"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الموظفين: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDepartmentInfo()
        {
            try
            {
                string query = @"SELECT d.DepartmentName, m.Name as ManagerName 
                                 FROM Managers m 
                                 INNER JOIN Departments d ON m.DepartmentID = d.DepartmentID
                                 WHERE m.ManagerID = @ManagerID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ManagerID", managerId)
                };

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    lblDepartment.Text = "القسم: " + dt.Rows[0]["DepartmentName"].ToString();
                    lblManager.Text = "المدير: " + dt.Rows[0]["ManagerName"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل معلومات القسم: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetManagerDepartmentId()
        {
            try
            {
                string query = "SELECT DepartmentID FROM Managers WHERE ManagerID = @ManagerID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ManagerID", managerId)
                };

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في الحصول على معرف القسم: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        private void ClearFields()
        {
            txtName.Text = "أدخل الاسم";
            txtName.ForeColor = Color.Gray;
            txtJobTitle.Text = "أدخل المسمى الوظيفي";
            txtJobTitle.ForeColor = Color.Gray;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtName.ForeColor = Color.Black;
                txtJobTitle.Text = row.Cells["JobTitle"].Value.ToString();
                txtJobTitle.ForeColor = Color.Black;

                if (row.Cells["JoinDate"].Value != DBNull.Value)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells["JoinDate"].Value);
                }
            }
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

        private void txtJobTitle_Leave(object sender, EventArgs e)
        {
            if (
string.IsNullOrWhiteSpace(txtJobTitle.Text))
            {
                txtJobTitle.Text = "أدخل المسمى الوظيفي";
                txtJobTitle.ForeColor = Color.Gray;
            }
        }

        private int DetermineEvaluationType(string employeeName)
        {
            return 2; // Default to Monthly Evaluation
        }
    }
}