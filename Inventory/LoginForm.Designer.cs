namespace Inventory
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        // ui init
        private void InitializeComponent()
        {
            titleLabel = new Label();
            subtitleLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            cancelButton = new Button();
            fieldsLayout = new TableLayoutPanel();
            actionsLayout = new TableLayoutPanel();
            fieldsLayout.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(103, 80, 164);
            titleLabel.Location = new Point(260, 40);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(281, 60);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Storage Den";
            titleLabel.Click += label1_Click;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            subtitleLabel.ForeColor = Color.FromArgb(80, 60, 150);
            subtitleLabel.Location = new Point(185, 100);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(458, 41);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Inventory Management System";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            usernameLabel.ForeColor = Color.FromArgb(80, 60, 150);
            usernameLabel.Location = new Point(3, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(101, 25);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username";
            usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            passwordLabel.ForeColor = Color.FromArgb(80, 60, 150);
            passwordLabel.Location = new Point(3, 41);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(97, 25);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password";
            passwordLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // usernameTextBox
            // 
            usernameTextBox.BackColor = Color.FromArgb(248, 247, 253);
            usernameTextBox.Dock = DockStyle.Fill;
            usernameTextBox.ForeColor = Color.FromArgb(33, 33, 33);
            usernameTextBox.Location = new Point(123, 3);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(234, 27);
            usernameTextBox.TabIndex = 1;
            usernameTextBox.TextChanged += txtUsername_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(248, 247, 253);
            passwordTextBox.Dock = DockStyle.Fill;
            passwordTextBox.ForeColor = Color.FromArgb(33, 33, 33);
            passwordTextBox.Location = new Point(123, 44);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(234, 27);
            passwordTextBox.TabIndex = 2;
            passwordTextBox.TextChanged += txtPassword_TextChanged;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(103, 80, 164);
            loginButton.Dock = DockStyle.Fill;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(366, 0);
            loginButton.Margin = new Padding(6, 0, 0, 0);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(134, 41);
            loginButton.TabIndex = 3;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += btnLogin_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(248, 247, 253);
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelButton.ForeColor = Color.FromArgb(103, 80, 164);
            cancelButton.Location = new Point(366, 41);
            cancelButton.Margin = new Padding(6, 0, 0, 0);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(134, 41);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += btnCancel_Click;
            // 
            // fieldsLayout
            // 
            fieldsLayout.BackColor = Color.FromArgb(245, 244, 250);
            fieldsLayout.ColumnCount = 3;
            fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
            fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            fieldsLayout.Controls.Add(usernameLabel, 0, 0);
            fieldsLayout.Controls.Add(usernameTextBox, 1, 0);
            fieldsLayout.Controls.Add(loginButton, 2, 0);
            fieldsLayout.Controls.Add(passwordLabel, 0, 1);
            fieldsLayout.Controls.Add(passwordTextBox, 1, 1);
            fieldsLayout.Controls.Add(cancelButton, 2, 1);
            fieldsLayout.Location = new Point(170, 206);
            fieldsLayout.Name = "fieldsLayout";
            fieldsLayout.RowCount = 2;
            fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            fieldsLayout.Size = new Size(500, 82);
            fieldsLayout.TabIndex = 2;
            // 
            // actionsLayout
            // 
            actionsLayout.Location = new Point(0, 0);
            actionsLayout.Name = "actionsLayout";
            actionsLayout.Size = new Size(200, 100);
            actionsLayout.TabIndex = 0;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 244, 250);
            ClientSize = new Size(800, 504);
            Controls.Add(fieldsLayout);
            Controls.Add(subtitleLabel);
            Controls.Add(titleLabel);
            ForeColor = Color.FromArgb(40, 40, 60);
            Name = "LoginForm";
            Text = "Login";
            fieldsLayout.ResumeLayout(false);
            fieldsLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label titleLabel;
        private Label subtitleLabel;

        private Label usernameLabel;
        private Label passwordLabel;

        private TextBox usernameTextBox;
        private TextBox passwordTextBox;

        private Button loginButton;
        private Button cancelButton;

        private TableLayoutPanel fieldsLayout;
        private TableLayoutPanel actionsLayout;
    }
}
