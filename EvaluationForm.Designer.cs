namespace EmployeeManagementApp
{
    partial class EvaluationForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmitEvaluation = new System.Windows.Forms.Button();
            this.lblTotalScore = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblMaxPossible = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblEvaluationTitle = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 80);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(760, 400);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txtComments
            // 
            this.txtComments.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtComments.Location = new System.Drawing.Point(20, 500);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtComments.Size = new System.Drawing.Size(760, 80);
            this.txtComments.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "ملاحظات:";
            // 
            // btnSubmitEvaluation
            // 
            this.btnSubmitEvaluation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSubmitEvaluation.FlatAppearance.BorderSize = 0;
            this.btnSubmitEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitEvaluation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmitEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnSubmitEvaluation.Location = new System.Drawing.Point(610, 600);
            this.btnSubmitEvaluation.Name = "btnSubmitEvaluation";
            this.btnSubmitEvaluation.Size = new System.Drawing.Size(170, 45);
            this.btnSubmitEvaluation.TabIndex = 3;
            this.btnSubmitEvaluation.Text = "إرسال التقييم";
            this.btnSubmitEvaluation.UseVisualStyleBackColor = false;
            this.btnSubmitEvaluation.Click += new System.EventHandler(this.btnSubmitEvaluation_Click);
            // 
            // lblTotalScore
            // 
            this.lblTotalScore.AutoSize = true;
            this.lblTotalScore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalScore.Location = new System.Drawing.Point(437, 610);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Size = new System.Drawing.Size(99, 25);
            this.lblTotalScore.TabIndex = 4;
            this.lblTotalScore.Text = "المجموع: 0";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPercentage.Location = new System.Drawing.Point(316, 611);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(98, 25);
            this.lblPercentage.TabIndex = 5;
            this.lblPercentage.Text = "النسبة: 0%";
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGrade.Location = new System.Drawing.Point(196, 611);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(81, 25);
            this.lblGrade.TabIndex = 6;
            this.lblGrade.Text = "التقدير: -";
            // 
            // lblMaxPossible
            // 
            this.lblMaxPossible.AutoSize = true;
            this.lblMaxPossible.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxPossible.Location = new System.Drawing.Point(29, 611);
            this.lblMaxPossible.Name = "lblMaxPossible";
            this.lblMaxPossible.Size = new System.Drawing.Size(122, 25);
            this.lblMaxPossible.TabIndex = 7;
            this.lblMaxPossible.Text = "أقصى درجة: 0";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelHeader.Controls.Add(this.lblEvaluationTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 60);
            this.panelHeader.TabIndex = 8;
            // 
            // lblEvaluationTitle
            // 
            this.lblEvaluationTitle.AutoSize = true;
            this.lblEvaluationTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEvaluationTitle.ForeColor = System.Drawing.Color.White;
            this.lblEvaluationTitle.Location = new System.Drawing.Point(300, 15);
            this.lblEvaluationTitle.Name = "lblEvaluationTitle";
            this.lblEvaluationTitle.Size = new System.Drawing.Size(253, 37);
            this.lblEvaluationTitle.TabIndex = 0;
            this.lblEvaluationTitle.Text = "نموذج تقييم الموظف";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 660);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(800, 40);
            this.panelFooter.TabIndex = 9;
            // 
            // EvaluationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblMaxPossible);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.lblTotalScore);
            this.Controls.Add(this.btnSubmitEvaluation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "EvaluationForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نموذج التقييم";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmitEvaluation;
        private System.Windows.Forms.Label lblTotalScore;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblMaxPossible;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblEvaluationTitle;
        private System.Windows.Forms.Panel panelFooter;
    }
}