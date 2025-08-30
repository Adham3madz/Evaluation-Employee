using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    partial class ManagerForm
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
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnEvaluateEmployee = new System.Windows.Forms.Button();
            this.btnViewLastEvaluation = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblManager = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelHeader.SuspendLayout();
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
            // txtJobTitle
            // 
            this.txtJobTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtJobTitle.ForeColor = System.Drawing.Color.Gray;
            this.txtJobTitle.Location = new System.Drawing.Point(30, 107);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(320, 34);
            this.txtJobTitle.TabIndex = 2;
            this.txtJobTitle.Text = "أدخل المسمى الوظيفي";
            this.txtJobTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJobTitle.Enter += new System.EventHandler(this.txtJobTitle_Enter);
            this.txtJobTitle.Leave += new System.EventHandler(this.txtJobTitle_Leave);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateTimePicker1.Location = new System.Drawing.Point(30, 164);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(320, 34);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAddEmployee.FlatAppearance.BorderSize = 0;
            this.btnAddEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddEmployee.Location = new System.Drawing.Point(1081, 346);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(200, 45);
            this.btnAddEmployee.TabIndex = 4;
            this.btnAddEmployee.Text = "إضافة موظف";
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnEvaluateEmployee
            // 
            this.btnEvaluateEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEvaluateEmployee.FlatAppearance.BorderSize = 0;
            this.btnEvaluateEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluateEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEvaluateEmployee.ForeColor = System.Drawing.Color.White;
            this.btnEvaluateEmployee.Location = new System.Drawing.Point(1301, 346);
            this.btnEvaluateEmployee.Name = "btnEvaluateEmployee";
            this.btnEvaluateEmployee.Size = new System.Drawing.Size(200, 45);
            this.btnEvaluateEmployee.TabIndex = 5;
            this.btnEvaluateEmployee.Text = "تقييم موظف";
            this.btnEvaluateEmployee.UseVisualStyleBackColor = false;
            this.btnEvaluateEmployee.Click += new System.EventHandler(this.btnEvaluateEmployee_Click);
            // 
            // btnViewLastEvaluation
            // 
            this.btnViewLastEvaluation.BackColor = System.Drawing.Color.Blue;
            this.btnViewLastEvaluation.FlatAppearance.BorderSize = 0;
            this.btnViewLastEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLastEvaluation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewLastEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnViewLastEvaluation.Location = new System.Drawing.Point(1081, 406);
            this.btnViewLastEvaluation.Name = "btnViewLastEvaluation";
            this.btnViewLastEvaluation.Size = new System.Drawing.Size(420, 45);
            this.btnViewLastEvaluation.TabIndex = 6;
            this.btnViewLastEvaluation.Text = "عرض تفاصيل آخر تقييم";
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
            this.dataGridView1.Location = new System.Drawing.Point(35, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(896, 480);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(395, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "اسم الموظف:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(360, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "المسمى الوظيفي:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(388, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "تاريخ الانضمام:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDepartment.Location = new System.Drawing.Point(30, 69);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(74, 28);
            this.lblDepartment.TabIndex = 11;
            this.lblDepartment.Text = "القسم: ";
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblManager.Location = new System.Drawing.Point(30, 20);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(72, 28);
            this.lblManager.TabIndex = 12;
            this.lblManager.Text = "المدير: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtJobTitle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(1024, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 255);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات الموظف الجديد";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1548, 70);
            this.panelHeader.TabIndex = 14;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(350, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(227, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "لوحة تحكم المدير";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(1198, 480);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(219, 81);
            this.btnExportExcel.TabIndex = 1;
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1548, 682);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnViewLastEvaluation);
            this.Controls.Add(this.btnEvaluateEmployee);
            this.Controls.Add(this.btnAddEmployee);
            this.Name = "ManagerForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لوحة تحكم المدير";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnEvaluateEmployee;
        private System.Windows.Forms.Button btnViewLastEvaluation;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private Button btnExportExcel;
    }
}