using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public class DbHelper
    {
        private readonly string connectionString = "Data Source=192.168.50.5;Initial Catalog=EmployeeeData;User Id=sa;Password=comsys@123;Encrypt=False";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        result = cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"DB ERROR in ExecuteScalar: {ex.Message}\nQuery: {query}");
                    throw;
                }
            }
            return result;
        }

        public void UpdateEvaluation(int evaluationId, string comments, int totalScore, int maxScore)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Evaluations
                                 SET Comments = @Comments,
                                     TotalScore = @TotalScore,
                                     MaxPossibleScore = @MaxPossibleScore,
                                     Percentage = CAST(@TotalScore AS FLOAT) / NULLIF(@MaxPossibleScore, 0) * 100
                                 WHERE EvaluationID = @EvaluationID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Comments", comments ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalScore", totalScore);
                    cmd.Parameters.AddWithValue("@MaxPossibleScore", maxScore);
                    cmd.Parameters.AddWithValue("@EvaluationID", evaluationId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public SqlDataReader GetHRUser(string username, string password)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(
                @"SELECT * 
                  FROM Users 
                  WHERE (Role = 'HR' OR Role = N'موارد بشرية') 
                    AND Username = @Username 
                    AND Password = @Password", conn);

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}