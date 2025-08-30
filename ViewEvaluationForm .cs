using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public partial class ViewEvaluationForm : Form
    {
        private int employeeId;
        private string managerName;
        private DbHelper dbHelper;

        // 🔹 Add this field to store evaluation details for printing
        private string lastEvalPrintText = "";

        public ViewEvaluationForm(int employeeId, string managerName)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.managerName = managerName;
            dbHelper = new DbHelper();
            LoadEvaluations();
        }

        private void LoadEvaluations()
        {
            string query = @"SELECT TOP (1000) [EvaluationID]
                                ,[EvaluatorID]
                                ,[EvaluatedID]
                                ,[EvaluationTypeID]
                                ,[Date]
                                ,[Comments]
                                ,[TotalScore]
                                ,[MaxPossibleScore]
                                ,[Percentage]
                             FROM [EmployeeeData].[dbo].[OfficerManagerEvaluations]
                             WHERE [EvaluatedID] = @EvaluatedID
                             ORDER BY [Date] DESC";

            SqlParameter[] parameters = { new SqlParameter("@EvaluatedID", employeeId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            dataGridView1.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"مدير: {managerName}");
                sb.AppendLine($"تاريخ: {dt.Rows[0]["Date"]}");
                sb.AppendLine($"إجمالي النقاط: {dt.Rows[0]["TotalScore"]}/{dt.Rows[0]["MaxPossibleScore"]}");
                sb.AppendLine($"النسبة: {dt.Rows[0]["Percentage"]}%");
                sb.AppendLine($"ملاحظات: {dt.Rows[0]["Comments"]}");

                // 🔹 Save for printing
                lastEvalPrintText = sb.ToString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lastEvalPrintText))
            {
                MessageBox.Show("لا يوجد تقييم للطباعة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc
            };
            preview.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
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
                // Replace with your actual logo in Resources
                Image logo = Properties.Resources.RoyalResortLogo;
                int logoWidth = 100;
                int logoHeight = 100;
                int logoX = leftMargin;
                int logoY = y;

                e.Graphics.DrawImage(logo, new Rectangle(logoX, logoY, logoWidth, logoHeight));
            }
            catch
            {
                // ignore if resource not found 
            }

            // ===== Report Title (centered) =====
            e.Graphics.DrawString("تقرير تقييم الموظف", headerFont, brush,
                new RectangleF(leftMargin, y, rightMargin - leftMargin, 40),
                centerAlign);
            y += 120;

            // ===== Employee Info (right aligned like Arabic format) =====
            string[] lines = (string.IsNullOrEmpty(lastEvalPrintText) ? "" : lastEvalPrintText).Split('\n');
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                e.Graphics.DrawString(line.Trim(), bodyFont, brush,
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
            e.Graphics.DrawString(DateTime.Now.ToString("yyyy/MM/dd HH:mm"), footerFont, Brushes.Gray,
                new RectangleF(leftMargin, e.MarginBounds.Bottom + 5, rightMargin - leftMargin, 20),
                centerAlign);
        }
    }
}
