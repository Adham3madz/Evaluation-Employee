using System.Windows.Forms;

namespace EmployeeEvaluationApp
{
    partial class EditScoresForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.NumericUpDown numTotal;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.TextBox txtPercentage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblManager = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblComments = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.numTotal = new System.Windows.Forms.NumericUpDown();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.txtPercentage = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            this.SuspendLayout();

            // 
            // Labels
            // 
            this.lblEmployee.Text = "Employee:";
            this.lblEmployee.Location = new System.Drawing.Point(30, 30);

            this.lblManager.Text = "Manager:";
            this.lblManager.Location = new System.Drawing.Point(30, 70);

            this.lblDate.Text = "Date:";
            this.lblDate.Location = new System.Drawing.Point(30, 110);

            this.lblComments.Text = "Comments:";
            this.lblComments.Location = new System.Drawing.Point(30, 150);

            this.lblTotal.Text = "Total Score:";
            this.lblTotal.Location = new System.Drawing.Point(30, 230);

            this.lblMax.Text = "Max Possible:";
            this.lblMax.Location = new System.Drawing.Point(30, 270);

            this.lblPercentage.Text = "Percentage:";
            this.lblPercentage.Location = new System.Drawing.Point(30, 310);

            // 
            // Controls
            // 
            this.txtEmployee.Location = new System.Drawing.Point(150, 30);
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Width = 250;

            this.txtManager.Location = new System.Drawing.Point(150, 70);
            this.txtManager.ReadOnly = true;
            this.txtManager.Width = 250;

            this.dtpDate.Location = new System.Drawing.Point(150, 110);
            this.dtpDate.Width = 250;

            this.txtComments.Location = new System.Drawing.Point(150, 150);
            this.txtComments.Multiline = true;
            this.txtComments.Height = 60;
            this.txtComments.Width = 250;

            this.numTotal.Location = new System.Drawing.Point(150, 230);
            this.numTotal.Maximum = 1000;
            this.numTotal.ValueChanged += new System.EventHandler(this.numTotal_ValueChanged);

            this.numMax.Location = new System.Drawing.Point(150, 270);
            this.numMax.Maximum = 1000;
            this.numMax.ValueChanged += new System.EventHandler(this.numMax_ValueChanged);

            this.txtPercentage.Location = new System.Drawing.Point(150, 310);
            this.txtPercentage.ReadOnly = true;
            this.txtPercentage.Width = 250;

            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(150, 360);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(250, 360);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // Form
            // 
            this.ClientSize = new System.Drawing.Size(450, 420);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.txtEmployee);
            this.Controls.Add(this.txtManager);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.numTotal);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.txtPercentage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Text = "Edit Evaluation Scores";
            this.StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
