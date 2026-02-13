using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory.Api;

namespace Inventory
{
    public partial class LogsForm : Form
    {
        private readonly LogsClient _client;
        private List<LogEntry> _cache = new();

        public LogsForm(string username)
        {
            InitializeComponent();
            _client = new LogsClient("https://localhost:7203/", username);
            Load += LogsForm_Load;
            btnRefresh.Click += btnRefresh_Click;
            dataGridView1.AutoGenerateColumns = false;
            ConfigureColumns();
            StyleGrid();
        }

        private async void LogsForm_Load(object sender, EventArgs e)
        {
            await LoadLogs();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadLogs();
        }

        private async Task LoadLogs()
        {
            try
            {
                var logs = await _client.GetAllAsync();
                _cache = logs?.OrderByDescending(l => l.TimestampUtc).ToList() ?? new List<LogEntry>();
                dataGridView1.DataSource = _cache.Select(l => new
                {
                    l.Id,
                    l.Action,
                    l.ItemId,
                    l.Username,
                    Timestamp = l.TimestampUtc.ToLocalTime(),
                    l.BeforeJson,
                    l.AfterJson
                }).ToList();
                if (dataGridView1.Columns.Contains("BeforeJson"))
                    dataGridView1.Columns["BeforeJson"].Visible = false;
                if (dataGridView1.Columns.Contains("AfterJson"))
                    dataGridView1.Columns["AfterJson"].Visible = false;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Cannot reach API.\n\n" + ex.Message);
            }
        }

        private void ConfigureColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "Id", FillWeight = 10 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Action", DataPropertyName = "Action", HeaderText = "Action", FillWeight = 20 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ItemId", DataPropertyName = "ItemId", HeaderText = "Item Id", FillWeight = 15 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", DataPropertyName = "Username", HeaderText = "User", FillWeight = 20 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Timestamp", DataPropertyName = "Timestamp", HeaderText = "When", FillWeight = 25, DefaultCellStyle = { Format = "g" } });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "BeforeJson", DataPropertyName = "BeforeJson", HeaderText = "Before", FillWeight = 5 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "AfterJson", DataPropertyName = "AfterJson", HeaderText = "After", FillWeight = 5 });
        }
        private void StyleGrid()
        {
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.GridColor = Color.FromArgb(220, 220, 220);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
