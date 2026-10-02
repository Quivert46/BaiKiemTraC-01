using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp7 
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Label lblProductId, lblProductName, lblUnitPrice, lblQuantity, lblCategory, lblSearch;
        private System.Windows.Forms.TextBox txtProductId, txtProductName, txtUnitPrice, txtQuantity, txtSearch;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChooseImage, btnAdd, btnUpdate, btnDelete;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId, colProductName, colCategory, colUnitPrice, colQuantity;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exportCSVToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutMain = new TableLayoutPanel();
            panelInput = new Panel();
            lblProductId = new Label();
            lblProductName = new Label();
            lblUnitPrice = new Label();
            lblQuantity = new Label();
            lblCategory = new Label();
            txtProductId = new TextBox();
            txtProductName = new TextBox();
            txtUnitPrice = new TextBox();
            txtQuantity = new TextBox();
            cboCategory = new ComboBox();
            picAvatar = new PictureBox();
            btnChooseImage = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panelData = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            dgvProducts = new DataGridView();
            errorProvider = new ErrorProvider(components);
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            tableLayoutMain.SuspendLayout();
            panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1200, 28);
            menuStrip1.TabIndex = 2;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportCSVToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // exportCSVToolStripMenuItem
            // 
            exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            exportCSVToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            exportCSVToolStripMenuItem.Size = new Size(215, 26);
            exportCSVToolStripMenuItem.Text = "Export CSV";
            exportCSVToolStripMenuItem.Click += exportCSVToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            exitToolStripMenuItem.Size = new Size(215, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.ColumnCount = 2;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutMain.Controls.Add(panelInput, 0, 0);
            tableLayoutMain.Controls.Add(panelData, 1, 0);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 28);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 1;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.Size = new Size(1200, 638);
            tableLayoutMain.TabIndex = 0;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(txtSearch);
            panelInput.Controls.Add(lblSearch);
            panelInput.Controls.Add(lblProductId);
            panelInput.Controls.Add(lblProductName);
            panelInput.Controls.Add(lblUnitPrice);
            panelInput.Controls.Add(lblQuantity);
            panelInput.Controls.Add(lblCategory);
            panelInput.Controls.Add(txtProductId);
            panelInput.Controls.Add(txtProductName);
            panelInput.Controls.Add(txtUnitPrice);
            panelInput.Controls.Add(txtQuantity);
            panelInput.Controls.Add(cboCategory);
            panelInput.Controls.Add(picAvatar);
            panelInput.Controls.Add(btnChooseImage);
            panelInput.Controls.Add(btnAdd);
            panelInput.Controls.Add(btnUpdate);
            panelInput.Controls.Add(btnDelete);
            panelInput.Dock = DockStyle.Fill;
            panelInput.Location = new Point(3, 3);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(15);
            panelInput.Size = new Size(414, 632);
            panelInput.TabIndex = 0;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(18, 18);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(53, 20);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Mã SP:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(18, 58);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(55, 20);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Tên SP:";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(18, 98);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(65, 20);
            lblUnitPrice.TabIndex = 2;
            lblUnitPrice.Text = "Đơn giá:";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(18, 138);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(72, 20);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Số lượng:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(18, 178);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 20);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Danh mục:";
            // 
            // txtProductId
            // 
            txtProductId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProductId.Location = new Point(105, 15);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(180, 27);
            txtProductId.TabIndex = 5;
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProductName.Location = new Point(105, 55);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(180, 27);
            txtProductName.TabIndex = 6;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUnitPrice.Location = new Point(105, 95);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(180, 27);
            txtUnitPrice.TabIndex = 7;
            // 
            // txtQuantity
            // 
            txtQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtQuantity.Location = new Point(105, 135);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(180, 27);
            txtQuantity.TabIndex = 8;
            // 
            // cboCategory
            // 
            cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Location = new Point(105, 175);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(180, 28);
            cboCategory.TabIndex = 9;
            // 
            // picAvatar
            // 
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(105, 215);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(180, 150);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 10;
            picAvatar.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(105, 375);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(180, 32);
            btnChooseImage.TabIndex = 11;
            btnChooseImage.Text = "Chọn ảnh";
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(18, 425);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(130, 425);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(242, 425);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa";
            btnDelete.Click += btnDelete_Click;
            // 
            // panelData
            // 
            panelData.Controls.Add(dgvProducts);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(423, 3);
            panelData.Name = "panelData";
            panelData.Padding = new Padding(10);
            panelData.Size = new Size(774, 632);
            panelData.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(0, 578);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(73, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            lblSearch.Click += lblSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(79, 575);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(335, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(10, 10);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(754, 612);
            dgvProducts.TabIndex = 2;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 666);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1200, 26);
            statusStrip1.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(145, 20);
            lblStatus.Text = "Tổng số sản phẩm: 0";
            // 
            // Form1
            // 
            ClientSize = new Size(1200, 692);
            Controls.Add(tableLayoutMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(900, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TechMart Product Manager";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutMain.ResumeLayout(false);
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
