using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmployeeManagementApp
{
    public partial class EvaluationForm : Form
    {
        private int employeeId;
        private string employeeName;
        private int managerId;
        private int evaluationTypeId;
        private DbHelper dbHelper;
        private int maxPossibleScore = 0;

        public EvaluationForm(int empId, string empName, int mgrId, int evalTypeId = 1)
        {
            InitializeComponent();
            employeeId = empId;
            employeeName = empName;
            managerId = mgrId;
            evaluationTypeId = evalTypeId;
            dbHelper = new DbHelper();
            this.Text = "Evaluate " + empName + " - " + GetEvaluationTypeName(evalTypeId);
            LoadEvaluationCriteria();
        }
        private void ApplyArabicTheme()
        {
            // Set form styling
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            // Style button
            btnSubmitEvaluation.BackColor = Color.FromArgb(0, 120, 215);
            btnSubmitEvaluation.ForeColor = Color.White;
            btnSubmitEvaluation.FlatStyle = FlatStyle.Flat;
            btnSubmitEvaluation.FlatAppearance.BorderSize = 0;
            btnSubmitEvaluation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            // Update labels with Arabic text
            label1.Text = "ملاحظات:";
            btnSubmitEvaluation.Text = "إرسال التقييم";

            // Update score labels
            lblTotalScore.Text = "المجموع: 0";
            lblPercentage.Text = "النسبة: 0%";
            lblGrade.Text = "التقدير: -";
            lblMaxPossible.Text = "أقصى درجة: 0";

            // Update title
            lblEvaluationTitle.Text = "تقييم " + employeeName + " - " + GetEvaluationTypeName(evaluationTypeId);
        }

        private string GetEvaluationTypeName(int typeId)
        {
            switch (typeId)
            {
                case 1: return "15-Day Evaluation";
                case 2: return "Monthly Evaluation";
                case 3: return "Reception Evaluation";
                case 4: return "Supervisor Evaluation";
                case 5: return "Manager Evaluation";
                default: return "Evaluation";
            }
        }

        private void LoadEvaluationCriteria()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                maxPossibleScore = 0;

                string query = "SELECT CriterionID, CriterionText, Points FROM Criteria WHERE EvaluationTypeID = @EvaluationTypeID";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@EvaluationTypeID", evaluationTypeId)
                };

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    string criterion = row["CriterionText"].ToString();
                    int points = Convert.ToInt32(row["Points"]);
                    maxPossibleScore += points;

                    GroupBox groupBox = new GroupBox();
                    groupBox.Text = $"{criterion} (الحد الأقصى: {points})";
                    groupBox.Size = new System.Drawing.Size(740, 70);
                    groupBox.Tag = row["CriterionID"];
                    groupBox.Font = new Font("Segoe UI", 10F);
                    groupBox.RightToLeft = RightToLeft.Yes;

                    NumericUpDown numericUpDown = new NumericUpDown();
                    numericUpDown.Minimum = 0;
                    numericUpDown.Maximum = points;
                    numericUpDown.Size = new System.Drawing.Size(80, 26);
                    numericUpDown.Location = new System.Drawing.Point(20, 25);
                    numericUpDown.Tag = row["CriterionID"];
                    numericUpDown.ValueChanged += new EventHandler(numericUpDown_ValueChanged);
                    numericUpDown.Font = new Font("Segoe UI", 10F);

                    groupBox.Controls.Add(numericUpDown);
                    flowLayoutPanel1.Controls.Add(groupBox);
                }

                lblMaxPossible.Text = $"أقصى درجة: {maxPossibleScore}";
                UpdateScoreDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل معايير التقييم: " + ex.Message);
            }
        }

        private int CalculateTotalScore()
        {
            int totalScore = 0;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    foreach (Control innerControl in groupBox.Controls)
                    {
                        if (innerControl is NumericUpDown numericUpDown)
                        {
                            totalScore += (int)numericUpDown.Value;
                        }
                    }
                }
            }
            return totalScore;
        }

        private decimal CalculatePercentage(int totalScore)
        {
            if (maxPossibleScore == 0) return 0;
            return Math.Round((decimal)totalScore / maxPossibleScore * 100, 2);
        }

        private string GetGrade(decimal percentage)
        {
            switch (evaluationTypeId)
            {
                case 1: // 15-Day Evaluation
                    if (percentage >= 92) return "ممتاز (Excellent)";
                    if (percentage >= 83) return "جيد للغاية (Very Good)";
                    if (percentage >= 75) return "جيد جدا (Good)";
                    if (percentage >= 67) return "جيد (Good)";
                    if (percentage >= 58) return "مقبول (Acceptable)";
                    if (percentage >= 50) return "ضعيف (Weak)";
                    return "لا يصلح (Unacceptable)";

                case 2: // Monthly Evaluation
                    if (percentage >= 90) return "ممتاز (Excellent)";
                    if (percentage >= 85) return "جيد للغاية (Very Good)";
                    if (percentage >= 80) return "جيد جدا (Good)";
                    if (percentage >= 75) return "جيد (Good)";
                    if (percentage >= 65) return "مقبول (Acceptable)";
                    if (percentage >= 55) return "ضعيف (Weak)";
                    return "عدم صلاحية (Unacceptable)";

                case 3: // Reception Evaluation
                    if (percentage >= 90) return "ممتاز (Excellent)";
                    if (percentage >= 87) return "جيد للغاية (Very Good)";
                    if (percentage >= 80) return "جيد جدا (Good)";
                    if (percentage >= 73) return "جيد (Good)";
                    if (percentage >= 67) return "مقبول (Acceptable)";
                    if (percentage >= 63) return "ضعيف (Weak)";
                    return "عدم صلاحية (Unacceptable)";

                case 5: // Manager Evaluation (Police Officer evaluating Manager)
                    if (percentage >= 95) return "استثنائي (Exceptional)";
                    if (percentage >= 90) return "متميز (Distinguished)";
                    if (percentage >= 85) return "متفوق (Superior)";
                    if (percentage >= 75) return "متقدم (Advanced)";
                    if (percentage >= 65) return "كفء (Competent)";
                    return "متوسط (Average)";

                case 4: // Supervisor Evaluation
                    if (percentage >= 93) return "استثنائي (Exceptional)";
                    if (percentage >= 86) return "متميز (Distinguished)";
                    if (percentage >= 82) return "جدير (Worthy)";
                    if (percentage >= 68) return "مرضي (Satisfactory)";
                    return "متوسط (Average)";

                default:
                    if (percentage >= 90) return "ممتاز (Excellent)";
                    if (percentage >= 80) return "جيد جدا (Very Good)";
                    if (percentage >= 70) return "جيد (Good)";
                    if (percentage >= 60) return "مقبول (Acceptable)";
                    return "ضعيف (Weak)";
            }
        }

        private void UpdateScoreDisplay()
        {
            int totalScore = CalculateTotalScore();
            decimal percentage = CalculatePercentage(totalScore);
            string grade = GetGrade(percentage);

            lblTotalScore.Text = $"المجموع: {totalScore}";
            lblPercentage.Text = $"النسبة: {percentage}%";
            lblGrade.Text = $"التقدير: {grade}";
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScoreDisplay();
        }

        private void btnSubmitEvaluation_Click(object sender, EventArgs e)
        {
            try
            {
                int totalScore = CalculateTotalScore();
                decimal percentage = CalculatePercentage(totalScore);
                string grade = GetGrade(percentage);

                string evalQuery;
                SqlParameter[] evalParams;

                // Check if this is a Manager Evaluation (TypeID = 5) - Police Officer evaluating Manager
                if (evaluationTypeId == 5)
                {
                    // Use OfficerManagerEvaluations table for police officer → manager evaluations
                    evalQuery = @"INSERT INTO OfficerManagerEvaluations (EvaluatorID, EvaluatedID, EvaluationTypeID, Date, Comments, TotalScore, MaxPossibleScore, Percentage) 
                               VALUES (@EvaluatorID, @EvaluatedID, @EvaluationTypeID, @Date, @Comments, @TotalScore, @MaxPossibleScore, @Percentage);
                               SELECT SCOPE_IDENTITY();";

                    // For now, set EvaluatorID to NULL since we don't have police officer ID tracking
                    // You might want to implement a way to get the current police officer's ID
                    evalParams = new SqlParameter[]
                    {
                        new SqlParameter("@EvaluatorID", DBNull.Value),
                        new SqlParameter("@EvaluatedID", employeeId),
                        new SqlParameter("@EvaluationTypeID", evaluationTypeId),
                        new SqlParameter("@Date", DateTime.Now),
                        new SqlParameter("@Comments", txtComments.Text),
                        new SqlParameter("@TotalScore", totalScore),
                        new SqlParameter("@MaxPossibleScore", maxPossibleScore),
                        new SqlParameter("@Percentage", percentage)
                    };
                }
                else
                {
                    // Use regular Evaluations table for other evaluations
                    evalQuery = @"INSERT INTO Evaluations (EmployeeID, ManagerID, EvaluationTypeID, Date, Comments, TotalScore, MaxPossibleScore, Percentage) 
                               VALUES (@EmployeeID, @ManagerID, @EvaluationTypeID, @Date, @Comments, @TotalScore, @MaxPossibleScore, @Percentage);
                               SELECT SCOPE_IDENTITY();";

                    evalParams = new SqlParameter[]
                    {
                        new SqlParameter("@EmployeeID", employeeId),
                        new SqlParameter("@ManagerID", managerId),
                        new SqlParameter("@EvaluationTypeID", evaluationTypeId),
                        new SqlParameter("@Date", DateTime.Now),
                        new SqlParameter("@Comments", txtComments.Text),
                        new SqlParameter("@TotalScore", totalScore),
                        new SqlParameter("@MaxPossibleScore", maxPossibleScore),
                        new SqlParameter("@Percentage", percentage)
                    };
                }

                object result = dbHelper.ExecuteScalar(evalQuery, evalParams);

                if (result != null && result != DBNull.Value)
                {
                    int evaluationId = Convert.ToInt32(result);

                    // Insert ratings
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        if (control is GroupBox groupBox)
                        {
                            int criterionId = Convert.ToInt32(groupBox.Tag);
                            NumericUpDown numericUpDown = null;

                            foreach (Control innerControl in groupBox.Controls)
                            {
                                if (innerControl is NumericUpDown)
                                {
                                    numericUpDown = (NumericUpDown)innerControl;
                                    break;
                                }
                            }

                            if (numericUpDown != null && numericUpDown.Value > 0)
                            {
                                string ratingQuery;
                                SqlParameter[] ratingParams;

                                if (evaluationTypeId == 5)
                                {
                                    // Use OfficerManagerEvaluationID for manager evaluations
                                    ratingQuery = "INSERT INTO Ratings (OfficerManagerEvaluationID, CriterionID, Score) VALUES (@EvaluationID, @CriterionID, @Score)";
                                }
                                else
                                {
                                    // Use EvaluationID for regular evaluations
                                    ratingQuery = "INSERT INTO Ratings (EvaluationID, CriterionID, Score) VALUES (@EvaluationID, @CriterionID, @Score)";
                                }

                                ratingParams = new SqlParameter[]
                                {
                                    new SqlParameter("@EvaluationID", evaluationId),
                                    new SqlParameter("@CriterionID", criterionId),
                                    new SqlParameter("@Score", numericUpDown.Value)
                                };

                                dbHelper.ExecuteNonQuery(ratingQuery, ratingParams);
                            }
                        }
                    }

                    MessageBox.Show($"Evaluation submitted successfully!\n\nTotal Score: {totalScore}/{maxPossibleScore}\nPercentage: {percentage}%\nGrade: {grade}");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to submit evaluation. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting evaluation: " + ex.Message);
            }
        }
    }
}