using Inventory.Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class MainForm : Form
    {
        // fields
        private readonly ItemsClient _itemsClient;
        private readonly CultureInfo _phpCulture = new("en-PH");
        private readonly string _currentUsername;

        private List<Item> _itemCache = new();

        private bool _isUnitPriceSortAsc = true;
        private bool _isNameSortAsc = true;
        private bool _isCodeSortAsc = true;
        private bool _isBrandSortAsc = true;

        // ctor
        public MainForm(string username)
        {
            InitializeComponent();

            _currentUsername = username;
            _itemsClient = new ItemsClient("https://localhost:7203/", _currentUsername);

            ConfigureUi();
            WireEvents();
        }

        // ui setup
        private void ConfigureUi()
        {
            label6.Text = $"Hi, {_currentUsername}!";

            gridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridItems.MultiSelect = false;
            gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtId.ReadOnly = true;
        }

        // event wiring
        private void WireEvents()
        {
            Load += MainForm_Load;

            gridItems.ColumnHeaderMouseClick += gridItems_ColumnHeaderMouseClick;
            gridItems.CellContentClick += gridItems_CellContentClick;

            if (txtSearch != null) txtSearch.TextChanged += txtSearch_TextChanged;
            if (btnExport != null) btnExport.Click += btnExport_Click;
        }

        // form lifecycle
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await RefreshGridAsync();
        }

        // grid events
        private void gridItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridItems.CurrentRow?.DataBoundItem is Item item) PopulateInputs(item);
        }

        private void gridItems_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var clickedColumn = gridItems.Columns[e.ColumnIndex];
            var columnKey = !string.IsNullOrWhiteSpace(clickedColumn.DataPropertyName)
                ? clickedColumn.DataPropertyName
                : clickedColumn.Name;

            var currentItems = (gridItems.DataSource as IEnumerable<Item>)?.ToList() ?? new List<Item>();

            if (string.Equals(columnKey, "UnitPrice", StringComparison.OrdinalIgnoreCase))
            {
                currentItems = _isUnitPriceSortAsc
                    ? currentItems.OrderBy(i => i.UnitPrice).ToList()
                    : currentItems.OrderByDescending(i => i.UnitPrice).ToList();

                _isUnitPriceSortAsc = !_isUnitPriceSortAsc;
                BindGrid(currentItems);
                return;
            }

            if (string.Equals(columnKey, "Name", StringComparison.OrdinalIgnoreCase))
            {
                currentItems = _isNameSortAsc
                    ? currentItems.OrderBy(i => i.Name, StringComparer.CurrentCultureIgnoreCase).ToList()
                    : currentItems.OrderByDescending(i => i.Name, StringComparer.CurrentCultureIgnoreCase).ToList();

                _isNameSortAsc = !_isNameSortAsc;
                BindGrid(currentItems);
                return;
            }

            if (string.Equals(columnKey, "Code", StringComparison.OrdinalIgnoreCase))
            {
                currentItems = _isCodeSortAsc
                    ? currentItems.OrderBy(i => i.Code, StringComparer.CurrentCultureIgnoreCase).ToList()
                    : currentItems.OrderByDescending(i => i.Code, StringComparer.CurrentCultureIgnoreCase).ToList();

                _isCodeSortAsc = !_isCodeSortAsc;
                BindGrid(currentItems);
                return;
            }

            if (string.Equals(columnKey, "Brand", StringComparison.OrdinalIgnoreCase))
            {
                currentItems = _isBrandSortAsc
                    ? currentItems.OrderBy(i => i.Brand, StringComparer.CurrentCultureIgnoreCase).ToList()
                    : currentItems.OrderByDescending(i => i.Brand, StringComparer.CurrentCultureIgnoreCase).ToList();

                _isBrandSortAsc = !_isBrandSortAsc;
                BindGrid(currentItems);
                return;
            }
        }

        // button events
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var newItem = ReadFromInputs();
            var confirm = MessageBox.Show(
                $"Are you sure you want to add this item?\n\n{FormatItem(newItem)}",
                "Confirm Add",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            var createdItem = await _itemsClient.CreateAsync(newItem);

            await RefreshGridAsync();

            if (createdItem != null) SelectRowById(createdItem.Id);

            ClearInputs();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out var itemId))
            {
                MessageBox.Show("Select a row first.");
                return;
            }

            if (!ValidateInputs()) return;

            var beforeItem = _itemCache.FirstOrDefault(x => x.Id == itemId);

            var updatedItem = ReadFromInputs();
            updatedItem.Id = itemId;

            var confirm = MessageBox.Show(
                $"Are you sure you want to update item ID {itemId}?\n\nBefore:\n{FormatItem(beforeItem)}\n\nAfter:\n{FormatItem(updatedItem)}",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            await _itemsClient.UpdateAsync(updatedItem);

            await RefreshGridAsync();
            SelectRowById(itemId);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out var itemId))
            {
                MessageBox.Show("Select a row first.");
                return;
            }

            var beforeItem = _itemCache.FirstOrDefault(x => x.Id == itemId);

            var confirm = MessageBox.Show(
                $"Delete this item?\n\n{FormatItem(beforeItem)}",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            await _itemsClient.DeleteAsync(itemId);

            await RefreshGridAsync();
            ClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();

            if (txtSearch != null) txtSearch.Clear();

            BindGrid(_itemCache);
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            using var dialog = new LogsForm(_currentUsername);
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ShowDialog(this);
        }

        // search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var query = (txtSearch.Text ?? string.Empty).Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                BindGrid(_itemCache);
                return;
            }

            var filteredItems = _itemCache.Where(i =>
                (i.Name ?? string.Empty).ToLower().Contains(query) ||
                (i.Code ?? string.Empty).ToLower().Contains(query) ||
                (i.Brand ?? string.Empty).ToLower().Contains(query));

            BindGrid(filteredItems);
        }

        // export
        private void btnExport_Click(object sender, EventArgs e)
        {
            var items = (gridItems.DataSource as IEnumerable<Item>)?.ToList() ?? new List<Item>();
            if (items.Count == 0)
            {
                MessageBox.Show("Nothing to export.");
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = $"items_{DateTime.Now:yyyyMMdd_HHmm}.csv"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            using var writer = new StreamWriter(saveDialog.FileName, false, System.Text.Encoding.UTF8);

            writer.WriteLine("Id,Name,Code,Brand,UnitPrice");

            foreach (var item in items)
            {
                var line = $"{item.Id},\"{item.Name}\",\"{item.Code}\",\"{item.Brand}\",{item.UnitPrice.ToString("0.00", CultureInfo.InvariantCulture)}";
                writer.WriteLine(line);
            }

            MessageBox.Show("Exported.");
        }

        // api sync
        private async Task RefreshGridAsync()
        {
            try
            {
                var items = await _itemsClient.GetAllAsync();
                _itemCache = items?.ToList() ?? new List<Item>();
                BindGrid(_itemCache);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Cannot reach API.\n\n" + ex.Message);
            }
        }

        // binding
        private void BindGrid(IEnumerable<Item> items)
        {
            var list = items.ToList();

            gridItems.DataSource = list;

            ApplyGridFormatting();
            StyleGrid();

            UpdateStats(list);
        }

        // grid formatting
        private void ApplyGridFormatting()
        {
            var unitPriceColumn =
                gridItems.Columns["UnitPrice"] ??
                gridItems.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.DataPropertyName == "UnitPrice");

            if (unitPriceColumn == null) return;

            unitPriceColumn.DefaultCellStyle.FormatProvider = _phpCulture;
            unitPriceColumn.DefaultCellStyle.Format = "C2";
        }

        private void StyleGrid()
        {
            gridItems.BackgroundColor = Color.White;

            gridItems.DefaultCellStyle.BackColor = Color.White;
            gridItems.DefaultCellStyle.ForeColor = Color.Black;

            gridItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            gridItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            gridItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            gridItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            gridItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            gridItems.DefaultCellStyle.SelectionForeColor = Color.Black;

            gridItems.GridColor = Color.FromArgb(220, 220, 220);
            gridItems.RowHeadersVisible = false;
            gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // stats
        private void UpdateStats(IEnumerable<Item> items)
        {
            var list = items.ToList();

            var itemCount = list.Count;
            var totalValue = list.Sum(i => i.UnitPrice);
            var mostExpensive = list.OrderByDescending(i => i.UnitPrice).FirstOrDefault();

            if (lblTotalItems != null) lblTotalItems.Text = $"Items: {itemCount}";
            if (lblTotalValue != null) lblTotalValue.Text = $"Total: {totalValue.ToString("C2", _phpCulture)}";

            if (lblMostExpensive == null) return;

            lblMostExpensive.Text = mostExpensive == null
                ? "Most Expensive: —"
                : $"Most Expensive: {mostExpensive.Name} ({mostExpensive.UnitPrice.ToString("C2", _phpCulture)})";
        }

        // form io
        private Item ReadFromInputs()
        {
            decimal.TryParse(txtUnitPrice.Text, NumberStyles.Currency, _phpCulture, out var unitPrice);

            return new Item
            {
                Name = txtName.Text.Trim(),
                Code = txtCode.Text.Trim(),
                Brand = txtBrand.Text.Trim(),
                UnitPrice = unitPrice
            };
        }

        private void PopulateInputs(Item item)
        {
            txtId.Text = item.Id.ToString();
            txtName.Text = item.Name;
            txtCode.Text = item.Code;
            txtBrand.Text = item.Brand;
            txtUnitPrice.Text = $"\u20B1{item.UnitPrice:0.00}";
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtName.Clear();
            txtCode.Clear();
            txtBrand.Clear();
            txtUnitPrice.Clear();

            gridItems.ClearSelection();
        }

        private void SelectRowById(int id)
        {
            foreach (DataGridViewRow row in gridItems.Rows)
            {
                if (row.DataBoundItem is not Item item) continue;
                if (item.Id != id) continue;

                row.Selected = true;
                gridItems.CurrentCell = row.Cells[0];

                PopulateInputs(item);
                break;
            }
        }

        // validation
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Code is required.");
                txtCode.Focus();
                return false;
            }

            if (!decimal.TryParse(txtUnitPrice.Text, NumberStyles.Currency, _phpCulture, out var price) || price < 0)
            {
                MessageBox.Show("Unit Price must be a non-negative digit.");
                txtUnitPrice.Focus();
                return false;
            }

            return true;
        }

        // formatting helpers
        private string FormatItem(Item item)
        {
            if (item == null) return "(none)";

            return
                $"Name: {item.Name}\n" +
                $"Code: {item.Code}\n" +
                $"Brand: {item.Brand}\n" +
                $"Unit Price: {item.UnitPrice.ToString("C2", _phpCulture)}";
        }

        // designer empty handlers
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void txtId_TextChanged(object sender, EventArgs e) { }
        private void txtCode_TextChanged(object sender, EventArgs e) { }
        private void txtBrand_TextChanged(object sender, EventArgs e) { }
        private void txtUnitPrice_TextChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void lblTotalItems_Click(object sender, EventArgs e) { }
        private void lblTotalValue_Click(object sender, EventArgs e) { }
        private void lblMostExpensive_Click(object sender, EventArgs e) { }

        private void crudLayout_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
