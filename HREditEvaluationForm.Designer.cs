namespace EmployeeManagementApp
{
    partial class HREditEvaluationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtEvaluationID;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.NumericUpDown numTotalScore;
        private System.Windows.Forms.NumericUpDown numMaxScore;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblEvaluationID;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblTotalScore;
        private System.Windows.Forms.Label lblMaxScore;

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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtEvaluationID = new System.Windows.Forms.TextBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.numTotalScore = new System.Windows.Forms.NumericUpDown();
            this.numMaxScore = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblEvaluationID = new System.Windows.Forms.Label();
            this.lblComments = new System.Windows.Forms.Label();
            this.lblTotalScore = new System.Windows.Forms.Label();
            this.lblMaxScore = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxScore)).BeginInit();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.Location = new System.Drawing.Point(20, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 250);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // txtEvaluationID
            this.txtEvaluationID.Location = new System.Drawing.Point(150, 290);
            this.txtEvaluationID.Name = "txtEvaluationID";
            this.txtEvaluationID.ReadOnly = true;
            this.txtEvaluationID.Size = new System.Drawing.Size(200, 22);
            this.txtEvaluationID.TabIndex = 1;

            // txtComments
            this.txtComments.Location = new System.Drawing.Point(150, 320);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(300, 60);
            this.txtComments.TabIndex = 2;

            // numTotalScore
            this.numTotalScore.Location = new System.Drawing.Point(150, 390);
            this.numTotalScore.Maximum = new decimal(new int[] {
            1000, 0, 0, 0});
            this.numTotalScore.Name = "numTotalScore";
            this.numTotalScore.Size = new System.Drawing.Size(120, 22);
            this.numTotalScore.TabIndex = 3;

            // numMaxScore
            this.numMaxScore.Location = new System.Drawing.Point(150, 420);
            this.numMaxScore.Maximum = new decimal(new int[] {
            1000, 0, 0, 0});
            this.numMaxScore.Value = 100;
            this.numMaxScore.Name = "numMaxScore";
            this.numMaxScore.Size = new System.Drawing.Size(120, 22);
            this.numMaxScore.TabIndex = 4;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(150, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Labels
            this.lblEvaluationID.AutoSize = true;
            this.lblEvaluationID.Location = new System.Drawing.Point(20, 290);
            this.lblEvaluationID.Name = "lblEvaluationID";
            this.lblEvaluationID.Text = "Evaluation ID:";

            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(20, 320);
            this.lblComments.Name = "lblComments";
            this.lblComments.Text = "Comments:";

            this.lblTotalScore.AutoSize = true;
            this.lblTotalScore.Location = new System.Drawing.Point(20, 390);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Text = "Total Score:";

            this.lblMaxScore.AutoSize = true;
            this.lblMaxScore.Location = new System.Drawing.Point(20, 420);
            this.lblMaxScore.Name = "lblMaxScore";
            this.lblMaxScore.Text = "Max Score:";

            // HREditEvaluationForm
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtEvaluationID);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.numTotalScore);
            this.Controls.Add(this.numMaxScore);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblEvaluationID);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.lblTotalScore);
            this.Controls.Add(this.lblMaxScore);
            this.Name = "HREditEvaluationForm";
            this.Text = "HR - Edit Evaluations";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
