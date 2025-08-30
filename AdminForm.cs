using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public partial class AdminForm : Form
    {
        private DbHelper dbHelper;

        public AdminForm()
        {
            InitializeComponent();
            dbHelper = new DbHelper();

            ApplyArabicTheme();
            LoadDepartments();
            LoadUsers();
        }

        #region Theme & UI

        private void ApplyArabicTheme()
        {
            // Form
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "لوحة تحكم المسؤول";

            // Buttons
            StyleButton(btnAddUser, Color.FromArgb(0, 120, 215));
            StyleButton(btnDeleteUser, Color.FromArgb(200, 0, 0));

            // DataGrid
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;

            // Labels
            labelUsername.Text = "اسم المستخدم:";
            labelPassword.Text = "كلمة المرور:";
            labelRole.Text = "الدور:";
            labelUserID.Text = "معرف المستخدم:";
            labelManager.Text = "معرف المدير:";



            // Buttons text
            btnAddUser.Text = "إضافة مستخدم";
            btnDeleteUser.Text = "حذف مستخدم";

            // Role ComboBox
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new object[] { "مسؤول", "موارد بشرية", "ضابط شرطة", "مدير" });
        }

        private void StyleButton(Button btn, Color backColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        #endregion

        #region User Operations

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            try
            {
                string query;
                SqlParameter[] parameters;

                if (cmbRole.Text == "مدير") // Arabic check
                {
                    if (cmbManager.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select a manager!");
                        return;
                    }

                    query = "INSERT INTO Users (Username, Password, Role, ManagerID) VALUES (@Username, @Password, @Role, @ManagerID)";
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Username", txtUsername.Text),
                        new SqlParameter("@Password", txtPassword.Text),
                        new SqlParameter("@Role", cmbRole.Text),
                        new SqlParameter("@ManagerID", cmbManager.SelectedValue)
                    };
                }
                else
                {
                    query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Username", txtUsername.Text),
                        new SqlParameter("@Password", txtPassword.Text),
                        new SqlParameter("@Role", cmbRole.Text)
                    };
                }

                int rowsAffected = dbHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User added successfully!");
                    ClearFields();
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtUserID.Text, out int userId))
            {
                MessageBox.Show("Please enter a valid User ID!");
                return;
            }

            try
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };

                int rowsAffected = dbHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User deleted successfully!");
                    ClearFields();
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("User not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message);
            }
        }

        private void LoadUsers()
        {
            try
            {
                string query = "SELECT UserID, Username, Role, ManagerID FROM Users";
                DataTable dt = dbHelper.ExecuteQuery(query);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            txtUserID.Clear();
            cmbManager.SelectedIndex = -1;
            cmbManager.Visible = false;
            labelManager.Visible = true;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtUserID.Text = row.Cells["UserID"].Value.ToString();
            txtUsername.Text = row.Cells["Username"].Value.ToString();
            cmbRole.Text = row.Cells["Role"].Value.ToString();

            if (row.Cells["ManagerID"].Value != DBNull.Value)
            {
                cmbManager.SelectedValue = row.Cells["ManagerID"].Value;
                cmbManager.Visible = true;
                labelManager.Visible = true;

            }
            else
            {
                cmbManager.SelectedIndex = -1;
                cmbManager.Visible = false;
                labelManager.Visible = true;

            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show manager only for "مدير"
            bool isManager = cmbRole.Text == "مدير";
            cmbManager.Visible = isManager;
            labelManager.Visible = true;

        }

        #endregion

        #region Departments & Managers

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedIndex == -1) return;
            LoadManagers(Convert.ToInt32(cmbDepartment.SelectedValue));
        }

        private void LoadManagers(int departmentId)
        {
            try
            {
                string query = "SELECT ManagerID, Name FROM Managers WHERE DepartmentID = @DepartmentID AND Name IS NOT NULL";
                SqlParameter[] parameters = { new SqlParameter("@DepartmentID", departmentId) };
                DataTable dt = dbHelper.ExecuteQuery(query, parameters);

                cmbManager.DataSource = dt;
                cmbManager.DisplayMember = "Name";
                cmbManager.ValueMember = "ManagerID";
                cmbManager.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading managers: " + ex.Message);
            }
        }

        #endregion
    }
}
