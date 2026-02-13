namespace Inventory
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            gridItems = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtId = new TextBox();
            txtName = new TextBox();
            txtCode = new TextBox();
            txtBrand = new TextBox();
            txtUnitPrice = new TextBox();
            label6 = new Label();
            lblSupervisor = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnExport = new Button();
            btnLogs = new Button();
            lblTotalItems = new Label();
            lblTotalValue = new Label();
            lblMostExpensive = new Label();
            splitMain = new SplitContainer();
            leftLayout = new TableLayoutPanel();
            headerLayout = new TableLayoutPanel();
            searchLayout = new TableLayoutPanel();
            statsLayout = new FlowLayoutPanel();
            inputsLayout = new TableLayoutPanel();
            crudLayout = new TableLayoutPanel();
            toolsLayout = new TableLayoutPanel();
            rightLayout = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            leftLayout.SuspendLayout();
            headerLayout.SuspendLayout();
            searchLayout.SuspendLayout();
            statsLayout.SuspendLayout();
            inputsLayout.SuspendLayout();
            crudLayout.SuspendLayout();
            toolsLayout.SuspendLayout();
            rightLayout.SuspendLayout();
            SuspendLayout();
            // 
            // gridItems
            // 
            gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridItems.BackgroundColor = Color.FromArgb(245, 244, 250);
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Dock = DockStyle.Fill;
            gridItems.GridColor = Color.FromArgb(210, 200, 240);
            gridItems.Location = new Point(3, 21);
            gridItems.MultiSelect = false;
            gridItems.Name = "gridItems";
            gridItems.RowHeadersWidth = 51;
            gridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridItems.ShowRowErrors = false;
            gridItems.Size = new Size(576, 978);
            gridItems.TabIndex = 0;
            gridItems.CellContentClick += gridItems_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(80, 60, 150);
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(33, 28);
            label1.TabIndex = 0;
            label1.Text = "ID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(80, 60, 150);
            label2.Location = new Point(3, 43);
            label2.Name = "label2";
            label2.Size = new Size(68, 28);
            label2.TabIndex = 2;
            label2.Text = "Name";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(80, 60, 150);
            label3.Location = new Point(3, 76);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 4;
            label3.Text = "Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(80, 60, 150);
            label4.Location = new Point(3, 109);
            label4.Name = "label4";
            label4.Size = new Size(68, 28);
            label4.TabIndex = 6;
            label4.Text = "Brand";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(80, 60, 150);
            label5.Location = new Point(3, 142);
            label5.Name = "label5";
            label5.Size = new Size(105, 28);
            label5.TabIndex = 8;
            label5.Text = "Unit Price";
            label5.Click += label5_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(103, 80, 164);
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(0, 0);
            btnAdd.Margin = new Padding(0, 0, 0, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(629, 49);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Insert";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(55, 125, 255);
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(0, 57);
            btnUpdate.Margin = new Padding(0, 0, 0, 8);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(629, 45);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(198, 62, 62);
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(0, 110);
            btnDelete.Margin = new Padding(0, 0, 0, 8);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(629, 47);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(248, 222, 222);
            btnClear.Dock = DockStyle.Fill;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.FromArgb(120, 50, 60);
            btnClear.Location = new Point(0, 165);
            btnClear.Margin = new Padding(0, 0, 0, 10);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(629, 49);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtId
            // 
            txtId.BackColor = Color.FromArgb(248, 247, 253);
            txtId.Dock = DockStyle.Fill;
            txtId.ForeColor = Color.FromArgb(33, 33, 33);
            txtId.Location = new Point(267, 13);
            txtId.Name = "txtId";
            txtId.Size = new Size(359, 27);
            txtId.TabIndex = 1;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(248, 247, 253);
            txtName.Dock = DockStyle.Fill;
            txtName.ForeColor = Color.FromArgb(33, 33, 33);
            txtName.Location = new Point(267, 46);
            txtName.Name = "txtName";
            txtName.Size = new Size(359, 27);
            txtName.TabIndex = 3;
            txtName.TextChanged += textBox2_TextChanged;
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(248, 247, 253);
            txtCode.Dock = DockStyle.Fill;
            txtCode.ForeColor = Color.FromArgb(33, 33, 33);
            txtCode.Location = new Point(267, 79);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(359, 27);
            txtCode.TabIndex = 5;
            txtCode.TextChanged += txtCode_TextChanged;
            // 
            // txtBrand
            // 
            txtBrand.BackColor = Color.FromArgb(248, 247, 253);
            txtBrand.Dock = DockStyle.Fill;
            txtBrand.ForeColor = Color.FromArgb(33, 33, 33);
            txtBrand.Location = new Point(267, 112);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(359, 27);
            txtBrand.TabIndex = 7;
            txtBrand.TextChanged += txtBrand_TextChanged;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BackColor = Color.FromArgb(248, 247, 253);
            txtUnitPrice.Dock = DockStyle.Fill;
            txtUnitPrice.ForeColor = Color.FromArgb(33, 33, 33);
            txtUnitPrice.Location = new Point(267, 145);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(359, 27);
            txtUnitPrice.TabIndex = 9;
            txtUnitPrice.TextChanged += txtUnitPrice_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(103, 80, 164);
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(175, 41);
            label6.TabIndex = 0;
            label6.Text = "Hi, [name]!";
            label6.Click += label6_Click;
            // 
            // lblSupervisor
            // 
            lblSupervisor.AutoSize = true;
            lblSupervisor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSupervisor.ForeColor = Color.FromArgb(80, 60, 150);
            lblSupervisor.Location = new Point(3, 41);
            lblSupervisor.Name = "lblSupervisor";
            lblSupervisor.Size = new Size(163, 28);
            lblSupervisor.TabIndex = 1;
            lblSupervisor.Text = "Supervisor view";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.ForeColor = Color.FromArgb(80, 60, 150);
            lblSearch.Location = new Point(3, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(63, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(248, 247, 253);
            txtSearch.Dock = DockStyle.Top;
            txtSearch.ForeColor = Color.FromArgb(33, 33, 33);
            txtSearch.Location = new Point(0, 26);
            txtSearch.Margin = new Padding(0, 3, 0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(629, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(255, 183, 77);
            btnExport.Dock = DockStyle.Fill;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.FromArgb(66, 40, 14);
            btnExport.Location = new Point(322, 0);
            btnExport.Margin = new Padding(8, 0, 0, 0);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(307, 49);
            btnExport.TabIndex = 1;
            btnExport.Text = "Export Data";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += button1_Click;
            // 
            // btnLogs
            // 
            btnLogs.BackColor = Color.FromArgb(248, 247, 253);
            btnLogs.Dock = DockStyle.Fill;
            btnLogs.FlatStyle = FlatStyle.Flat;
            btnLogs.ForeColor = Color.FromArgb(103, 80, 164);
            btnLogs.Location = new Point(0, 0);
            btnLogs.Margin = new Padding(0, 0, 8, 0);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(306, 49);
            btnLogs.TabIndex = 0;
            btnLogs.Text = "Logs";
            btnLogs.UseVisualStyleBackColor = false;
            btnLogs.Click += btnLogs_Click;
            // 
            // lblTotalItems
            // 
            lblTotalItems.AutoSize = true;
            lblTotalItems.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalItems.ForeColor = Color.FromArgb(80, 60, 150);
            lblTotalItems.Location = new Point(3, 0);
            lblTotalItems.Name = "lblTotalItems";
            lblTotalItems.Size = new Size(111, 28);
            lblTotalItems.TabIndex = 0;
            lblTotalItems.Text = "TotalItems";
            lblTotalItems.Click += lblTotalItems_Click;
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalValue.ForeColor = Color.FromArgb(80, 60, 150);
            lblTotalValue.Location = new Point(3, 28);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(110, 28);
            lblTotalValue.TabIndex = 1;
            lblTotalValue.Text = "TotalValue";
            lblTotalValue.Click += lblTotalValue_Click;
            // 
            // lblMostExpensive
            // 
            lblMostExpensive.AutoSize = true;
            lblMostExpensive.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMostExpensive.ForeColor = Color.FromArgb(80, 60, 150);
            lblMostExpensive.Location = new Point(3, 56);
            lblMostExpensive.Name = "lblMostExpensive";
            lblMostExpensive.Size = new Size(154, 28);
            lblMostExpensive.TabIndex = 2;
            lblMostExpensive.Text = "MostExpensive";
            lblMostExpensive.Click += lblMostExpensive_Click;
            // 
            // splitMain
            // 
            splitMain.BackColor = Color.FromArgb(245, 244, 250);
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 0);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(leftLayout);
            splitMain.Panel1MinSize = 300;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(rightLayout);
            splitMain.Panel2MinSize = 600;
            splitMain.Size = new Size(1269, 1020);
            splitMain.SplitterDistance = 665;
            splitMain.TabIndex = 0;
            // 
            // leftLayout
            // 
            leftLayout.BackColor = Color.FromArgb(245, 244, 250);
            leftLayout.ColumnCount = 1;
            leftLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftLayout.Controls.Add(headerLayout, 0, 0);
            leftLayout.Controls.Add(searchLayout, 0, 1);
            leftLayout.Controls.Add(statsLayout, 0, 2);
            leftLayout.Controls.Add(inputsLayout, 0, 3);
            leftLayout.Controls.Add(crudLayout, 0, 4);
            leftLayout.Dock = DockStyle.Fill;
            leftLayout.Location = new Point(0, 0);
            leftLayout.Name = "leftLayout";
            leftLayout.Padding = new Padding(18);
            leftLayout.RowCount = 5;
            leftLayout.RowStyles.Add(new RowStyle());
            leftLayout.RowStyles.Add(new RowStyle());
            leftLayout.RowStyles.Add(new RowStyle());
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftLayout.RowStyles.Add(new RowStyle());
            leftLayout.Size = new Size(665, 1020);
            leftLayout.TabIndex = 0;
            // 
            // headerLayout
            // 
            headerLayout.BackColor = Color.FromArgb(245, 244, 250);
            headerLayout.ColumnCount = 1;
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headerLayout.Controls.Add(label6, 0, 0);
            headerLayout.Controls.Add(lblSupervisor, 0, 1);
            headerLayout.Dock = DockStyle.Top;
            headerLayout.Location = new Point(21, 21);
            headerLayout.Name = "headerLayout";
            headerLayout.RowCount = 2;
            headerLayout.RowStyles.Add(new RowStyle());
            headerLayout.RowStyles.Add(new RowStyle());
            headerLayout.Size = new Size(623, 100);
            headerLayout.TabIndex = 0;
            // 
            // searchLayout
            // 
            searchLayout.BackColor = Color.FromArgb(245, 244, 250);
            searchLayout.ColumnCount = 1;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.Controls.Add(lblSearch, 0, 0);
            searchLayout.Controls.Add(txtSearch, 0, 1);
            searchLayout.Dock = DockStyle.Top;
            searchLayout.Location = new Point(18, 127);
            searchLayout.Margin = new Padding(0, 3, 0, 0);
            searchLayout.Name = "searchLayout";
            searchLayout.RowCount = 2;
            searchLayout.RowStyles.Add(new RowStyle());
            searchLayout.RowStyles.Add(new RowStyle());
            searchLayout.Size = new Size(629, 63);
            searchLayout.TabIndex = 1;
            // 
            // statsLayout
            // 
            statsLayout.AutoSize = true;
            statsLayout.BackColor = Color.FromArgb(245, 244, 250);
            statsLayout.Controls.Add(lblTotalItems);
            statsLayout.Controls.Add(lblTotalValue);
            statsLayout.Controls.Add(lblMostExpensive);
            statsLayout.Dock = DockStyle.Top;
            statsLayout.FlowDirection = FlowDirection.TopDown;
            statsLayout.Location = new Point(18, 202);
            statsLayout.Margin = new Padding(0, 12, 0, 0);
            statsLayout.Name = "statsLayout";
            statsLayout.Size = new Size(629, 84);
            statsLayout.TabIndex = 2;
            statsLayout.WrapContents = false;
            // 
            // inputsLayout
            // 
            inputsLayout.BackColor = Color.FromArgb(245, 244, 250);
            inputsLayout.ColumnCount = 2;
            inputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            inputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            inputsLayout.Controls.Add(label1, 0, 0);
            inputsLayout.Controls.Add(txtId, 1, 0);
            inputsLayout.Controls.Add(label2, 0, 1);
            inputsLayout.Controls.Add(txtName, 1, 1);
            inputsLayout.Controls.Add(label3, 0, 2);
            inputsLayout.Controls.Add(txtCode, 1, 2);
            inputsLayout.Controls.Add(label4, 0, 3);
            inputsLayout.Controls.Add(txtBrand, 1, 3);
            inputsLayout.Controls.Add(label5, 0, 4);
            inputsLayout.Controls.Add(txtUnitPrice, 1, 4);
            inputsLayout.Dock = DockStyle.Fill;
            inputsLayout.Location = new Point(18, 300);
            inputsLayout.Margin = new Padding(0, 14, 0, 28);
            inputsLayout.Name = "inputsLayout";
            inputsLayout.Padding = new Padding(0, 10, 0, 18);
            inputsLayout.RowCount = 5;
            inputsLayout.RowStyles.Add(new RowStyle());
            inputsLayout.RowStyles.Add(new RowStyle());
            inputsLayout.RowStyles.Add(new RowStyle());
            inputsLayout.RowStyles.Add(new RowStyle());
            inputsLayout.RowStyles.Add(new RowStyle());
            inputsLayout.Size = new Size(629, 401);
            inputsLayout.TabIndex = 3;
            // 
            // crudLayout
            // 
            crudLayout.AutoSize = true;
            crudLayout.BackColor = Color.FromArgb(245, 244, 250);
            crudLayout.ColumnCount = 1;
            crudLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            crudLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            crudLayout.Controls.Add(btnAdd, 0, 0);
            crudLayout.Controls.Add(btnUpdate, 0, 1);
            crudLayout.Controls.Add(btnDelete, 0, 2);
            crudLayout.Controls.Add(btnClear, 0, 3);
            crudLayout.Controls.Add(toolsLayout, 0, 4);
            crudLayout.Dock = DockStyle.Bottom;
            crudLayout.Location = new Point(18, 729);
            crudLayout.Margin = new Padding(0);
            crudLayout.Name = "crudLayout";
            crudLayout.RowCount = 5;
            crudLayout.RowStyles.Add(new RowStyle());
            crudLayout.RowStyles.Add(new RowStyle());
            crudLayout.RowStyles.Add(new RowStyle());
            crudLayout.RowStyles.Add(new RowStyle());
            crudLayout.RowStyles.Add(new RowStyle());
            crudLayout.Size = new Size(629, 273);
            crudLayout.TabIndex = 4;
            // 
            // toolsLayout
            // 
            toolsLayout.AutoSize = true;
            toolsLayout.BackColor = Color.FromArgb(245, 244, 250);
            toolsLayout.ColumnCount = 2;
            toolsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            toolsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            toolsLayout.Controls.Add(btnLogs, 0, 0);
            toolsLayout.Controls.Add(btnExport, 1, 0);
            toolsLayout.Dock = DockStyle.Fill;
            toolsLayout.Location = new Point(0, 224);
            toolsLayout.Margin = new Padding(0);
            toolsLayout.Name = "toolsLayout";
            toolsLayout.RowCount = 1;
            toolsLayout.RowStyles.Add(new RowStyle());
            toolsLayout.Size = new Size(629, 49);
            toolsLayout.TabIndex = 4;
            // 
            // rightLayout
            // 
            rightLayout.BackColor = Color.FromArgb(245, 244, 250);
            rightLayout.ColumnCount = 1;
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightLayout.Controls.Add(gridItems, 0, 0);
            rightLayout.Dock = DockStyle.Fill;
            rightLayout.Location = new Point(0, 0);
            rightLayout.Name = "rightLayout";
            rightLayout.Padding = new Padding(0, 18, 18, 18);
            rightLayout.RowCount = 1;
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rightLayout.Size = new Size(600, 1020);
            rightLayout.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 244, 250);
            ClientSize = new Size(1269, 1020);
            Controls.Add(splitMain);
            ForeColor = Color.FromArgb(40, 40, 60);
            Name = "MainForm";
            Text = "Inventory";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            leftLayout.ResumeLayout(false);
            leftLayout.PerformLayout();
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            searchLayout.ResumeLayout(false);
            searchLayout.PerformLayout();
            statsLayout.ResumeLayout(false);
            statsLayout.PerformLayout();
            inputsLayout.ResumeLayout(false);
            inputsLayout.PerformLayout();
            crudLayout.ResumeLayout(false);
            crudLayout.PerformLayout();
            toolsLayout.ResumeLayout(false);
            rightLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        private DataGridView gridItems;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtCode;
        private TextBox txtBrand;
        private TextBox txtUnitPrice;

        private Label label6;
        private Label lblSupervisor;

        private Label lblSearch;
        private TextBox txtSearch;

        private Label lblTotalItems;
        private Label lblTotalValue;
        private Label lblMostExpensive;

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;

        private Button btnExport;
        private Button btnLogs;

        private SplitContainer splitMain;

        private TableLayoutPanel leftLayout;
        private TableLayoutPanel headerLayout;
        private TableLayoutPanel searchLayout;

        private FlowLayoutPanel statsLayout;
        private TableLayoutPanel inputsLayout;

        private TableLayoutPanel crudLayout;
        private TableLayoutPanel toolsLayout;

        private TableLayoutPanel rightLayout;
    }
}
