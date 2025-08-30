using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public partial class HREditEvaluationForm : Form
    {
        DbHelper db = new DbHelper();

        public HREditEvaluationForm()
        {
            InitializeComponent();
            LoadEvaluations();
        }

        private void LoadEvaluations()
        {
            string query = "SELECT EvaluationID, EmployeeID, ManagerID, EvaluationTypeID, Date, Comments, TotalScore, MaxPossibleScore, Percentage FROM Evaluations";
            DataTable dt = db.ExecuteQuery(query);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtEvaluationID.Text = row.Cells["EvaluationID"].Value.ToString();
                txtComments.Text = row.Cells["Comments"].Value?.ToString();
                numTotalScore.Value = row.Cells["TotalScore"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["TotalScore"].Value) : 0;
                numMaxScore.Value = row.Cells["MaxPossibleScore"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["MaxPossibleScore"].Value) : 100;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int evaluationId = int.Parse(txtEvaluationID.Text);
            string comments = txtComments.Text;
            int totalScore = (int)numTotalScore.Value;
            int maxScore = (int)numMaxScore.Value;

            db.UpdateEvaluation(evaluationId, comments, totalScore, maxScore);

            MessageBox.Show("Evaluation updated successfully!");
            LoadEvaluations();
        }
    }
}
