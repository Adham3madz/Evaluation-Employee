using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    partial class HRForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblJobTitle = new System.Windows.Forms.Label();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.btnViewAllEvaluations = new System.Windows.Forms.Button();
            this.btnEditEvaluation = new System.Windows.Forms.Button();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.cmbFilterDepartment = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterDepartment = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.Location = new System.Drawing.Point(250, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(350, 32);
            this.txtName.TabIndex = 0;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtJobTitle.Location = new System.Drawing.Point(250, 110);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(350, 32);
            this.txtJobTitle.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePicker1.Location = new System.Drawing.Point(250, 150);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(350, 32);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbDepartment.Location = new System.Drawing.Point(250, 65);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(350, 33);
            this.cmbDepartment.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 400);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1600, 400);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1600, 70);
            this.panelHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(585, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "لوحة تحكم الموارد البشرية";
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.txtName);
            this.panelForm.Controls.Add(this.txtJobTitle);
            this.panelForm.Controls.Add(this.dateTimePicker1);
            this.panelForm.Controls.Add(this.cmbDepartment);
            this.panelForm.Controls.Add(this.lblEmployeeName);
            this.panelForm.Controls.Add(this.lblDepartment);
            this.panelForm.Controls.Add(this.lblJobTitle);
            this.panelForm.Controls.Add(this.lblJoinDate);
            this.panelForm.Controls.Add(this.btnAddEmployee);
            this.panelForm.Controls.Add(this.btnEvaluate);
            this.panelForm.Controls.Add(this.btnViewAllEvaluations);
            this.panelForm.Controls.Add(this.btnEditEvaluation);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 70);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(1600, 260);
            this.panelForm.TabIndex = 1;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmployeeName.Location = new System.Drawing.Point(620, 23);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(100, 23);
            this.lblEmployeeName.TabIndex = 4;
            this.lblEmployeeName.Text = "اسم الموظف:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDepartment.Location = new System.Drawing.Point(640, 68);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(100, 23);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "القسم:";
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblJobTitle.Location = new System.Drawing.Point(640, 113);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.Size = new System.Drawing.Size(100, 23);
            this.lblJobTitle.TabIndex = 6;
            this.lblJobTitle.Text = "المسمى الوظيفي:";
            // 
            // lblJoinDate
            // 
            this.lblJoinDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblJoinDate.Location = new System.Drawing.Point(650, 153);
            this.lblJoinDate.Name = "lblJoinDate";
            this.lblJoinDate.Size = new System.Drawing.Size(100, 23);
            this.lblJoinDate.TabIndex = 7;
            this.lblJoinDate.Text = "تاريخ الانضمام:";
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.Color.Blue;
            this.btnAddEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddEmployee.Location = new System.Drawing.Point(250, 200);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(170, 45);
            this.btnAddEmployee.TabIndex = 8;
            this.btnAddEmployee.Text = "إضافة موظف";
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.BackColor = System.Drawing.Color.Blue;
            this.btnEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluate.ForeColor = System.Drawing.Color.White;
            this.btnEvaluate.Location = new System.Drawing.Point(430, 200);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(170, 45);
            this.btnEvaluate.TabIndex = 9;
            this.btnEvaluate.Text = "تقييم الموظف";
            this.btnEvaluate.UseVisualStyleBackColor = false;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // btnViewAllEvaluations
            // 
            this.btnViewAllEvaluations.BackColor = System.Drawing.Color.Blue;
            this.btnViewAllEvaluations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAllEvaluations.ForeColor = System.Drawing.Color.White;
            this.btnViewAllEvaluations.Location = new System.Drawing.Point(610, 200);
            this.btnViewAllEvaluations.Name = "btnViewAllEvaluations";
            this.btnViewAllEvaluations.Size = new System.Drawing.Size(220, 45);
            this.btnViewAllEvaluations.TabIndex = 10;
            this.btnViewAllEvaluations.Text = "عرض جميع التقييمات";
            this.btnViewAllEvaluations.UseVisualStyleBackColor = false;
            this.btnViewAllEvaluations.Click += new System.EventHandler(this.btnViewAllEvaluations_Click);
            // 
            // btnEditEvaluation
            // 
            this.btnEditEvaluation.BackColor = System.Drawing.Color.Blue;
            this.btnEditEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnEditEvaluation.Location = new System.Drawing.Point(840, 200);
            this.btnEditEvaluation.Name = "btnEditEvaluation";
            this.btnEditEvaluation.Size = new System.Drawing.Size(169, 45);
            this.btnEditEvaluation.TabIndex = 11;
            this.btnEditEvaluation.Text = "تعديل التقييم";
            this.btnEditEvaluation.UseVisualStyleBackColor = false;
            this.btnEditEvaluation.Click += new System.EventHandler(this.btnEditEvaluation_Click);
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelFilters.Controls.Add(this.btnPrint);
            this.panelFilters.Controls.Add(this.btnClearFilters);
            this.panelFilters.Controls.Add(this.cmbFilterDepartment);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Controls.Add(this.lblFilterDepartment);
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 330);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1600, 70);
            this.panelFilters.TabIndex = 3;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(80, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(150, 40);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "طباعة التقرير";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(250, 15);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(150, 40);
            this.btnClearFilters.TabIndex = 4;
            this.btnClearFilters.Text = "مسح الفلتر";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // cmbFilterDepartment
            // 
            this.cmbFilterDepartment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFilterDepartment.FormattingEnabled = true;
            this.cmbFilterDepartment.Location = new System.Drawing.Point(486, 24);
            this.cmbFilterDepartment.Name = "cmbFilterDepartment";
            this.cmbFilterDepartment.Size = new System.Drawing.Size(200, 31);
            this.cmbFilterDepartment.TabIndex = 3;
            this.cmbFilterDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbFilterDepartment_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(819, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 30);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblFilterDepartment
            // 
            this.lblFilterDepartment.AutoSize = true;
            this.lblFilterDepartment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterDepartment.Location = new System.Drawing.Point(723, 32);
            this.lblFilterDepartment.Name = "lblFilterDepartment";
            this.lblFilterDepartment.Size = new System.Drawing.Size(58, 23);
            this.lblFilterDepartment.TabIndex = 1;
            this.lblFilterDepartment.Text = "القسم:";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(1088, 32);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(151, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "بحث باسم الموظف:";
            // 
            // HRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1600, 800);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelHeader);
            this.Name = "HRForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لوحة تحكم الموارد البشرية";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtName;
        private TextBox txtJobTitle;
        private DateTimePicker dateTimePicker1;
        private ComboBox cmbDepartment;
        private DataGridView dataGridView1;
        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelForm;

        // Labels
        private Label lblEmployeeName;
        private Label lblDepartment;
        private Label lblJobTitle;
        private Label lblJoinDate;

        // Buttons
        private Button btnAddEmployee;
        private Button btnEvaluate;
        private Button btnViewAllEvaluations;
        private Button btnEditEvaluation;

        // New controls for filtering
        private Panel panelFilters;
        private TextBox txtSearch;
        private Label lblSearch;
        private ComboBox cmbFilterDepartment;
        private Label lblFilterDepartment;
        private Button btnClearFilters;
        private Button btnPrint;
    }
}
