namespace EmployeeManagementApp
{
    partial class PoliceOfficerForm
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

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.btnAddManager = new System.Windows.Forms.Button();
            this.btnEvaluateManager = new System.Windows.Forms.Button();
            this.btnViewLastEvaluation = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDept = new System.Windows.Forms.Label();
            this.labelJob = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.cmbFilterDepartment = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterDepartment = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.ForeColor = System.Drawing.Color.Gray;
            this.txtName.Location = new System.Drawing.Point(30, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(320, 34);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "أدخل الاسم";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(30, 110);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(320, 36);
            this.cmbDepartment.TabIndex = 2;
            this.cmbDepartment.Text = "أدخل القسم";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtJobTitle.ForeColor = System.Drawing.Color.Gray;
            this.txtJobTitle.Location = new System.Drawing.Point(30, 170);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(320, 34);
            this.txtJobTitle.TabIndex = 3;
            this.txtJobTitle.Text = "أدخل المسمى الوظيفي";
            this.txtJobTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJobTitle.Enter += new System.EventHandler(this.txtJobTitle_Enter);
            this.txtJobTitle.Leave += new System.EventHandler(this.txtJobTitle_Leave);
            // 
            // btnAddManager
            // 
            this.btnAddManager.BackColor = System.Drawing.Color.Blue;
            this.btnAddManager.FlatAppearance.BorderSize = 0;
            this.btnAddManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddManager.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddManager.ForeColor = System.Drawing.Color.White;
            this.btnAddManager.Location = new System.Drawing.Point(1068, 319);
            this.btnAddManager.Name = "btnAddManager";
            this.btnAddManager.Size = new System.Drawing.Size(200, 45);
            this.btnAddManager.TabIndex = 4;
            this.btnAddManager.Text = "إضافة مدير";
            this.btnAddManager.UseVisualStyleBackColor = false;
            this.btnAddManager.Click += new System.EventHandler(this.btnAddManager_Click);
            // 
            // btnEvaluateManager
            // 
            this.btnEvaluateManager.BackColor = System.Drawing.Color.Blue;
            this.btnEvaluateManager.FlatAppearance.BorderSize = 0;
            this.btnEvaluateManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluateManager.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEvaluateManager.ForeColor = System.Drawing.Color.White;
            this.btnEvaluateManager.Location = new System.Drawing.Point(1293, 319);
            this.btnEvaluateManager.Name = "btnEvaluateManager";
            this.btnEvaluateManager.Size = new System.Drawing.Size(200, 45);
            this.btnEvaluateManager.TabIndex = 5;
            this.btnEvaluateManager.Text = "تقييم مدير";
            this.btnEvaluateManager.UseVisualStyleBackColor = false;
            this.btnEvaluateManager.Click += new System.EventHandler(this.btnEvaluateManager_Click);
            // 
            // btnViewLastEvaluation
            // 
            this.btnViewLastEvaluation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnViewLastEvaluation.FlatAppearance.BorderSize = 0;
            this.btnViewLastEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLastEvaluation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewLastEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnViewLastEvaluation.Location = new System.Drawing.Point(1068, 370);
            this.btnViewLastEvaluation.Name = "btnViewLastEvaluation";
            this.btnViewLastEvaluation.Size = new System.Drawing.Size(425, 45);
            this.btnViewLastEvaluation.TabIndex = 13;
            this.btnViewLastEvaluation.Text = "عرض آخر تقييم";
            this.btnViewLastEvaluation.UseVisualStyleBackColor = false;
            this.btnViewLastEvaluation.Click += new System.EventHandler(this.btnViewLastEvaluation_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(329, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(691, 394);
            this.dataGridView1.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelName.Location = new System.Drawing.Point(360, 53);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(100, 25);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "اسم المدير:";
            // 
            // labelDept
            // 
            this.labelDept.AutoSize = true;
            this.labelDept.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelDept.Location = new System.Drawing.Point(360, 113);
            this.labelDept.Name = "labelDept";
            this.labelDept.Size = new System.Drawing.Size(102, 25);
            this.labelDept.TabIndex = 9;
            this.labelDept.Text = "اسم القسم:";
            // 
            // labelJob
            // 
            this.labelJob.AutoSize = true;
            this.labelJob.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelJob.Location = new System.Drawing.Point(360, 173);
            this.labelJob.Name = "labelJob";
            this.labelJob.Size = new System.Drawing.Size(156, 25);
            this.labelJob.TabIndex = 10;
            this.labelJob.Text = "المسمى الوظيفي:";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1551, 70);
            this.panelHeader.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(350, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(325, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "لوحة تحكم ضابط الشرطة";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Controls.Add(this.cmbDepartment);
            this.groupBox1.Controls.Add(this.labelDept);
            this.groupBox1.Controls.Add(this.txtJobTitle);
            this.groupBox1.Controls.Add(this.labelJob);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(1026, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 238);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات المدير الجديد";
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
            this.panelFilters.Location = new System.Drawing.Point(329, 475);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1210, 140);
            this.panelFilters.TabIndex = 14;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Blue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(385, 66);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(128, 40);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "طباعة التقرير";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.Blue;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(694, 66);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(106, 40);
            this.btnClearFilters.TabIndex = 4;
            this.btnClearFilters.Text = "مسح الفلتر";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // cmbFilterDepartment
            // 
            this.cmbFilterDepartment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFilterDepartment.FormattingEnabled = true;
            this.cmbFilterDepartment.Location = new System.Drawing.Point(329, 20);
            this.cmbFilterDepartment.Name = "cmbFilterDepartment";
            this.cmbFilterDepartment.Size = new System.Drawing.Size(200, 31);
            this.cmbFilterDepartment.TabIndex = 3;
            this.cmbFilterDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbFilterDepartment_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(619, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 30);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblFilterDepartment
            // 
            this.lblFilterDepartment.AutoSize = true;
            this.lblFilterDepartment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterDepartment.Location = new System.Drawing.Point(535, 21);
            this.lblFilterDepartment.Name = "lblFilterDepartment";
            this.lblFilterDepartment.Size = new System.Drawing.Size(58, 23);
            this.lblFilterDepartment.TabIndex = 1;
            this.lblFilterDepartment.Text = "القسم:";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(875, 23);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(133, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "بحث باسم المدير:";
            // 
            // PoliceOfficerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1551, 608);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.btnViewLastEvaluation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEvaluateManager);
            this.Controls.Add(this.btnAddManager);
            this.Name = "PoliceOfficerForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لوحة تحكم ضابط الشرطة";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.Button btnAddManager;
        private System.Windows.Forms.Button btnEvaluateManager;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDept;
        private System.Windows.Forms.Label labelJob;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnViewLastEvaluation;

        // New controls for filtering
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbFilterDepartment;
        private System.Windows.Forms.Label lblFilterDepartment;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnPrint;
    }
}