using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public partial class EvaluationDetailsForm : Form
    {
        private readonly DbHelper dbHelper;
        private readonly int employeeId;
        private readonly string employeeName;
        private readonly bool showAll;
        private DataTable evalTable;

        private PrintDocument printDocument;

        public EvaluationDetailsForm(int employeeId, string employeeName, bool showAll)
        {
            InitializeComponent();
            dbHelper = new DbHelper();
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.showAll = showAll;

            ApplyArabicTheme();
            LoadEvaluationDetails();

            // setup printing
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        #region UI Styling
        private void ApplyArabicTheme()
        {
            this.Text = $"تفاصيل تقييمات الموظف: {employeeName}";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.BackColor = Color.White;

            lblTitle.Text = this.Text;
            btnClose.Text = "إغلاق";
            btnPrint.Text = "طباعة";

            btnClose.Click += (s, e) => this.Close();
            btnPrint.Click += BtnPrint_Click;

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RightToLeft = RightToLeft.Yes;
        }
        #endregion

        #region Data Loading
        private void LoadEvaluationDetails()
        {
            try
            {
                string query;

                if (showAll)
                {
                    query = @"
                        SELECT e.EvaluationID, e.Date, e.TotalScore, e.MaxPossibleScore, e.Percentage, e.Comments,
                               et.TypeName as EvaluationType
                        FROM Evaluations e
                        INNER JOIN EvaluationTypes et ON e.EvaluationTypeID = et.EvaluationTypeID
                        WHERE e.EmployeeID = @EmployeeID
                        ORDER BY e.Date DESC";
                }
                else
                {
                    query = @"
                        SELECT TOP 1 e.EvaluationID, e.Date, e.TotalScore, e.MaxPossibleScore, e.Percentage, e.Comments,
                               et.TypeName as EvaluationType
                        FROM Evaluations e
                        INNER JOIN EvaluationTypes et ON e.EvaluationTypeID = et.EvaluationTypeID
                        WHERE e.EmployeeID = @EmployeeID
                        ORDER BY e.Date DESC";
                }

                var parameters = new[] { new SqlParameter("@EmployeeID", employeeId) };
                evalTable = dbHelper.ExecuteQuery(query, parameters);

                if (evalTable.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد تقييمات متاحة!", "معلومة",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }

                dataGridView1.DataSource = evalTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل تفاصيل التقييم: " + ex.Message,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Printing
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            using (PrintPreviewDialog preview = new PrintPreviewDialog { Document = printDocument })
            {
                preview.Width = 800;
                preview.Height = 600;
                preview.ShowDialog();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (evalTable == null || evalTable.Rows.Count == 0) return;

            Graphics g = e.Graphics;
            int startX = 50, startY = 50, offsetY = 0;

            Font titleFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 11);

            g.DrawString($"تقرير تقييمات الموظف: {employeeName}", titleFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 40;

            foreach (DataRow row in evalTable.Rows)
            {
                g.DrawString("التاريخ: " + Convert.ToDateTime(row["Date"]).ToString("yyyy/MM/dd"), textFont, Brushes.Black, startX, startY + offsetY); offsetY += 25;
                g.DrawString("الدرجة: " + row["TotalScore"] + " / " + row["MaxPossibleScore"], textFont, Brushes.Black, startX, startY + offsetY); offsetY += 25;
                g.DrawString("النسبة: " + row["Percentage"] + "%", textFont, Brushes.Black, startX, startY + offsetY); offsetY += 25;
                g.DrawString("النوع: " + row["EvaluationType"], textFont, Brushes.Black, startX, startY + offsetY); offsetY += 25;
                g.DrawString("ملاحظات: " + row["Comments"], textFont, Brushes.Black, startX, startY + offsetY); offsetY += 40;
            }
        }
        #endregion
    }
}
