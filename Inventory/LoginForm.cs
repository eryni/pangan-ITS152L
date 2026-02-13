using System;
using System.Windows.Forms;
using Inventory.Api;

namespace Inventory
{
    public partial class LoginForm : Form
    {
        // fields
        private readonly LoginClient _loginClient = new("https://localhost:7203/");

        // getter setter
        public string LoggedInUser { get; private set; }

        // ctor
        public LoginForm()
        {
            InitializeComponent();
        }

        // input events
        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }

        // button events
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text.Trim();
            var password = passwordTextBox.Text;

            var isAuthenticated = await _loginClient.LoginAsync(username, password);

            if (!isAuthenticated)
            {
                MessageBox.Show("Invalid credentials.");
                passwordTextBox.Clear();
                passwordTextBox.Focus();
                return;
            }

            LoggedInUser = username;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // designer empty handlers
        private void label1_Click(object sender, EventArgs e) { }
    }
}
