using System.Windows.Forms;

partial class LastEvaluationForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvLastEvaluations;
    private Button btnRefresh;

    private void InitializeComponent()
    {
        this.dgvLastEvaluations = new DataGridView();
        this.btnRefresh = new Button();

        // 
        // dgvLastEvaluations
        // 
        this.dgvLastEvaluations.Location = new System.Drawing.Point(12, 12);
        this.dgvLastEvaluations.Size = new System.Drawing.Size(760, 400);
        this.dgvLastEvaluations.ReadOnly = true;
        this.dgvLastEvaluations.AllowUserToAddRows = false;
        this.dgvLastEvaluations.AllowUserToDeleteRows = false;
        this.dgvLastEvaluations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // 
        // btnRefresh
        // 
        this.btnRefresh.Text = "Refresh";
        this.btnRefresh.Location = new System.Drawing.Point(12, 420);
        this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

        // 
        // LastEvaluationForm
        // 
        this.ClientSize = new System.Drawing.Size(784, 461);
        this.Controls.Add(this.dgvLastEvaluations);
        this.Controls.Add(this.btnRefresh);
        this.Text = "Last Evaluations";
    }
}
