using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeEvaluationApp
{
    public partial class EditScoresForm : Form
    {
        private int evaluationId;
        private EmployeeManagementApp.DbHelper dbHelper;

        public EditScoresForm(int evaluationId)
        {
            InitializeComponent();
            this.evaluationId = evaluationId;
            this.dbHelper = new EmployeeManagementApp.DbHelper();
            LoadEvaluationData();
        }

        private void LoadEvaluationData()
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT e.EvaluationID, emp.Name AS EmployeeName, mgr.Name AS ManagerName,
                           e.Date, e.Comments, e.TotalScore, e.MaxPossibleScore, e.Percentage
                    FROM Evaluations e
                    JOIN EmployeeeData.dbo.Employees emp ON e.EmployeeID = emp.EmployeeID
                    LEFT JOIN EmployeeeData.dbo.Employees mgr ON e.ManagerID = mgr.EmployeeID
                    WHERE e.EvaluationID = @EvaluationID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EvaluationID", evaluationId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtEmployee.Text = reader["EmployeeName"].ToString();
                        txtManager.Text = reader["ManagerName"] != DBNull.Value ? reader["ManagerName"].ToString() : "لا يوجد مدير";
                        dtpDate.Value = reader["Date"] != DBNull.Value ? Convert.ToDateTime(reader["Date"]) : DateTime.Now;
                        txtComments.Text = reader["Comments"].ToString();
                        numTotal.Value = reader["TotalScore"] != DBNull.Value ? Convert.ToDecimal(reader["TotalScore"]) : 0;
                        numMax.Value = reader["MaxPossibleScore"] != DBNull.Value ? Convert.ToDecimal(reader["MaxPossibleScore"]) : 100;
                        txtPercentage.Text = reader["Percentage"] != DBNull.Value ? Convert.ToDecimal(reader["Percentage"]).ToString("F2") : "0.00";
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal total = numTotal.Value;
            decimal max = numMax.Value;
            decimal percentage = max > 0 ? (total / max) * 100 : 0;

            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE Evaluations
                    SET Date = @Date,
                        Comments = @Comments,
                        TotalScore = @TotalScore,
                        MaxPossibleScore = @MaxPossibleScore,
                        Percentage = @Percentage
                    WHERE EvaluationID = @EvaluationID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                    cmd.Parameters.AddWithValue("@Comments", txtComments.Text);
                    cmd.Parameters.AddWithValue("@TotalScore", total);
                    cmd.Parameters.AddWithValue("@MaxPossibleScore", max);
                    cmd.Parameters.AddWithValue("@Percentage", percentage);
                    cmd.Parameters.AddWithValue("@EvaluationID", evaluationId);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("تم تعديل التقييم بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numTotal_ValueChanged(object sender, EventArgs e)
        {
            UpdatePercentage();
        }

        private void numMax_ValueChanged(object sender, EventArgs e)
        {
            UpdatePercentage();
        }

        private void UpdatePercentage()
        {
            decimal total = numTotal.Value;
            decimal max = numMax.Value;
            decimal percentage = max > 0 ? (total / max) * 100 : 0;
            txtPercentage.Text = percentage.ToString("F2");
        }
    }
}
