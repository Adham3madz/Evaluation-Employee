using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class LastEvaluationForm : Form
{
    private string connectionString = @"Data Source=192.168.50.5;Initial Catalog=EmployeeeData;User Id=sa;Password=comsys@123;Encrypt=False";

    public LastEvaluationForm()
    {
        InitializeComponent();
        LoadLastEvaluations();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadLastEvaluations();
    }

    private void LoadLastEvaluations()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT e.[EmployeeID], e.[Name], ev.[EvaluationID], ev.[Date], ev.[TotalScore], ev.[Comments]
                FROM [dbo].[Employees] e
                INNER JOIN [dbo].[Evaluations] ev ON e.EmployeeID = ev.EmployeeID
                WHERE ev.[Date] = (SELECT MAX([Date]) FROM [dbo].[Evaluations] WHERE EmployeeID = e.EmployeeID)
                ORDER BY e.[EmployeeID];
                ";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvLastEvaluations.DataSource = dt;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading evaluations: " + ex.Message);
        }
    }
}
