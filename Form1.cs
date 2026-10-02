using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp7 
{
    public partial class Form1 : Form
    {
        private BindingList<Product> products = new BindingList<Product>();
        private BindingList<Product> displayedProducts = new BindingList<Product>();
        private BindingSource bindingSource = new BindingSource();
        private Product selectedProduct;

        public Form1()
        {
            InitializeComponent();
            bindingSource.DataSource = displayedProducts;
            dgvProducts.DataSource = bindingSource;
            LoadCategories();
            UpdateStatus();
        }

        private void LoadCategories()
        {
            var categories = new List<Category>
            {
                new Category(1, "Điện thoại"),
                new Category(2, "Laptop"),
                new Category(3, "Phụ kiện")
            };
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
        }

        private bool ValidateProduct()
        {
            errorProvider.Clear();
            bool ok = true;
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                ok = false;
            }
            if (!decimal.TryParse(txtUnitPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider.SetError(txtUnitPrice, "Đơn giá phải lớn hơn 0!");
                ok = false;
            }
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                errorProvider.SetError(txtQuantity, "Số lượng phải lớn hơn hoặc bằng 0!");
                ok = false;
            }
            return ok;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateProduct()) return;
            products.Add(new Product(txtProductId.Text.Trim(), txtProductName.Text.Trim(),
                (int)cboCategory.SelectedValue, cboCategory.Text,
                decimal.Parse(txtUnitPrice.Text), int.Parse(txtQuantity.Text),
                picAvatar.Tag?.ToString()));
            RefreshProductList();
            ClearInput();
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateProduct()) return;
            selectedProduct.ProductId = txtProductId.Text.Trim();
            selectedProduct.ProductName = txtProductName.Text.Trim();
            selectedProduct.CategoryId = (int)cboCategory.SelectedValue;
            selectedProduct.CategoryName = cboCategory.Text;
            selectedProduct.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            selectedProduct.Quantity = int.Parse(txtQuantity.Text);
            selectedProduct.ImagePath = picAvatar.Tag?.ToString();
            bindingSource.ResetBindings(false);
            RefreshProductList();
            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                products.Remove(selectedProduct);
                selectedProduct = null;
                RefreshProductList();
                ClearInput();
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Ảnh (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Bitmap (*.bmp)|*.bmp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadProductImage(dialog.FileName);
                    picAvatar.Tag = dialog.FileName;
                }
            }
        }

        private void LoadProductImage(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                picAvatar.Image = null;
                return;
            }
            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var temp = Image.FromStream(stream))
                    picAvatar.Image = new Bitmap(temp);
            }
            catch { picAvatar.Image = null; }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Product product = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (product == null) return;
            selectedProduct = product;
            txtProductId.Text = product.ProductId;
            txtProductName.Text = product.ProductName;
            txtUnitPrice.Text = product.UnitPrice.ToString();
            txtQuantity.Text = product.Quantity.ToString();
            cboCategory.SelectedValue = product.CategoryId;
            picAvatar.Tag = product.ImagePath;
            LoadProductImage(product.ImagePath);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => RefreshProductList();

        private void RefreshProductList()
        {
            string keyword = txtSearch.Text.Trim();
            displayedProducts.Clear();
            foreach (Product product in products)
            {
                if (string.IsNullOrWhiteSpace(keyword) ||
                    product.ProductName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    displayedProducts.Add(product);
            }
            UpdateStatus();
        }

        private void ClearInput()
        {
            txtProductId.Clear(); txtProductName.Clear(); txtUnitPrice.Clear(); txtQuantity.Clear();
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            picAvatar.Image = null; picAvatar.Tag = null; selectedProduct = null;
            errorProvider.Clear(); dgvProducts.ClearSelection();
        }

        private void UpdateStatus() => lblStatus.Text = $"Tổng số sản phẩm: {products.Count}";

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV Files (*.csv)|*.csv";
                dialog.FileName = "products.csv";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                StringBuilder csv = new StringBuilder();
                csv.AppendLine("Mã SP,Tên SP,Danh Mục,Đơn Giá,Số Lượng");
                foreach (Product product in products)
                    csv.AppendLine($"{EscapeCsv(product.ProductId)},{EscapeCsv(product.ProductName)},{EscapeCsv(product.CategoryName)},{product.UnitPrice:N0},{product.Quantity}");
                File.WriteAllText(dialog.FileName, csv.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string EscapeCsv(string value)
        {
            if (value == null) return "";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category(int id, string name) { Id = id; Name = name; }
    }

    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }

        public Product(string productId, string productName, int categoryId,
            string categoryName, decimal unitPrice, int quantity, string imagePath)
        {
            ProductId = productId; ProductName = productName; CategoryId = categoryId;
            CategoryName = categoryName; UnitPrice = unitPrice; Quantity = quantity;
            ImagePath = imagePath;
        }
    }

    