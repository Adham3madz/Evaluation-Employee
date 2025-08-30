using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public partial class MainForm : Form
    {
        private int currentManagerId = 0;

        public MainForm()
        {
            InitializeComponent();
            ApplyArabicTheme();
        }

        private void ApplyArabicTheme()
        {
            // Set form styling
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "نظام إدارة الموظفين - تسجيل الدخول";

            // Set Arabic placeholder text
            txtUsername.ForeColor = Color.Gray;
            txtPassword.ForeColor = Color.Gray;

            // Style button
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);

            // Style textboxes
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 14F);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 14F);

            // Update title
            lblTitle.Text = "نظام إدارة وتقييم الموظفين";
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;

            // Update copyright
            lblCopyright.Text = "© 2024 جميع الحقوق محفوظة";
            lblCopyright.Font = new Font("Segoe UI", 10F);
            lblCopyright.ForeColor = Color.FromArgb(100, 100, 100);

            // Update button text
            btnLogin.Text = "دخول إلى النظام";

            // Set placeholder texts
            txtUsername.Text = "اسم المستخدم";
            txtPassword.Text = "كلمة المرور";
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "اسم المستخدم")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "اسم المستخدم";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "كلمة المرور")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
                txtPassword.PasswordChar = '•';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "كلمة المرور";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = "";
            int managerId = 0;

            // Check if placeholder text is still there
            if (username == "اسم المستخدم" || password == "كلمة المرور")
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم وكلمة المرور", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection("Data Source=192.168.50.5;Initial Catalog=EmployeeeData;User Id=sa;Password=comsys@123;Encrypt=False"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Role, ManagerID FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                role = reader["Role"].ToString();
                                if (!reader.IsDBNull(reader.GetOrdinal("ManagerID")))
                                {
                                    managerId = reader.GetInt32(reader.GetOrdinal("ManagerID"));
                                }
                                currentManagerId = managerId;
                                OpenRoleForm(role, managerId);
                            }
                            else
                            {
                                MessageBox.Show("بيانات الدخول غير صحيحة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ في الاتصال بقاعدة البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenRoleForm(string role, int managerId)
        {
            this.Hide();
            Form roleForm = null;

            switch (role)
            {
                case "Admin":
                case "مسؤول": // Arabic for Admin
                    roleForm = new AdminForm();
                    break;

                case "HR":
                case "موارد بشرية": // Arabic for HR
                    roleForm = new HRForm();
                    break;

                case "PoliceOfficer":
                case "ضابط شرطة": // Arabic for Police Officer
                    roleForm = new PoliceOfficerForm();
                    break;

                case "Manager":
                case "مدير": // Arabic for Manager
                    roleForm = new ManagerForm(managerId);
                    break;

                case "HR_VIEW":
                case "هر": // Arabic for Manager
                    roleForm = new ManagerForm(managerId);
                    break;
            }

            if (roleForm != null)
            {
                roleForm.FormClosed += (s, args) => this.Show();
                roleForm.Show();
            }
            else
            {
                MessageBox.Show("دور المستخدم غير معروف!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }


        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}