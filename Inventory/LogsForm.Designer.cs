namespace Inventory
{
    partial class LogsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnRefresh = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitle.Location = new Point(280, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(230, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "System Logs";

            // btnRefresh
            btnRefresh.BackColor = Color.FromArgb(230, 230, 230);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(310, 400);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(183, 34);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            // dataGridView1
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White; dataGridView1.DefaultCellStyle.BackColor = Color.White; dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245,245,245);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235,235,235);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black; dataGridView1.GridColor = Color.FromArgb(220,220,220);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Location = new Point(40, 90);
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(720, 300);
            dataGridView1.Name = "dataGridView1";

            // LogsForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitle);
            Controls.Add(btnRefresh);
            Controls.Add(dataGridView1);
            Name = "LogsForm";
            Text = "Logs";
            Load += LogsForm_Load;

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnRefresh;
        private DataGridView dataGridView1;
    }
}
