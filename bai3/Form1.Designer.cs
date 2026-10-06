namespace Bai5_3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpProductInfo;
        private GroupBox grpFunction;
        private Label lblProductId;
        private Label lblProductName;
        private Label lblUnitPrice;
        private Label lblQuantity;
        private Label lblCategory;
        private Label lblSearch;
        private TextBox txtProductId;
        private TextBox txtProductName;
        private TextBox txtUnitPrice;
        private TextBox txtQuantity;
        private TextBox txtSearch;
        private ComboBox cboCategory;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private DataGridView dgvProducts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpProductInfo = new GroupBox();
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

            grpFunction = new GroupBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSearch = new Button();

            dgvProducts = new DataGridView();

            grpProductInfo.SuspendLayout();
            grpFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();

            // Thông tin sản phẩm
            grpProductInfo.Text = "Thông tin sản phẩm";
            grpProductInfo.Location = new Point(20, 20);
            grpProductInfo.Size = new Size(450, 240);

            lblProductId.Text = "Mã SP:";
            lblProductId.Location = new Point(20, 35);
            lblProductId.Size = new Size(80, 25);

            txtProductId.Name = "txtProductId";
            txtProductId.Location = new Point(110, 32);
            txtProductId.Size = new Size(280, 27);

            lblProductName.Text = "Tên SP:";
            lblProductName.Location = new Point(20, 75);
            lblProductName.Size = new Size(80, 25);

            txtProductName.Name = "txtProductName";
            txtProductName.Location = new Point(110, 72);
            txtProductName.Size = new Size(280, 27);

            lblUnitPrice.Text = "Đơn giá:";
            lblUnitPrice.Location = new Point(20, 115);
            lblUnitPrice.Size = new Size(80, 25);

            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Location = new Point(110, 112);
            txtUnitPrice.Size = new Size(280, 27);

            lblQuantity.Text = "Số lượng:";
            lblQuantity.Location = new Point(20, 155);
            lblQuantity.Size = new Size(80, 25);

            txtQuantity.Name = "txtQuantity";
            txtQuantity.Location = new Point(110, 152);
            txtQuantity.Size = new Size(280, 27);

            lblCategory.Text = "Danh mục:";
            lblCategory.Location = new Point(20, 195);
            lblCategory.Size = new Size(80, 25);

            cboCategory.Name = "cboCategory";
            cboCategory.Location = new Point(110, 192);
            cboCategory.Size = new Size(280, 28);
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.AddRange(new object[] {
                "Điện thoại",
                "Laptop",
                "Phụ kiện"
            });

            grpProductInfo.Controls.Add(lblProductId);
            grpProductInfo.Controls.Add(txtProductId);
            grpProductInfo.Controls.Add(lblProductName);
            grpProductInfo.Controls.Add(txtProductName);
            grpProductInfo.Controls.Add(lblUnitPrice);
            grpProductInfo.Controls.Add(txtUnitPrice);
            grpProductInfo.Controls.Add(lblQuantity);
            grpProductInfo.Controls.Add(txtQuantity);
            grpProductInfo.Controls.Add(lblCategory);
            grpProductInfo.Controls.Add(cboCategory);

            // Chức năng
            grpFunction.Text = "Chức năng";
            grpFunction.Location = new Point(490, 20);
            grpFunction.Size = new Size(470, 240);

            lblSearch.Text = "Tìm theo tên:";
            lblSearch.Location = new Point(20, 40);
            lblSearch.Size = new Size(100, 25);

            txtSearch.Name = "txtSearch";
            txtSearch.Location = new Point(125, 37);
            txtSearch.Size = new Size(300, 27);

            btnAdd.Name = "btnAdd";
            btnAdd.Text = "Thêm";
            btnAdd.Location = new Point(20, 100);
            btnAdd.Size = new Size(90, 35);
            btnAdd.Click += btnAdd_Click;

            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Sửa";
            btnEdit.Location = new Point(125, 100);
            btnEdit.Size = new Size(90, 35);
            btnEdit.Click += btnEdit_Click;

            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Xóa";
            btnDelete.Location = new Point(230, 100);
            btnDelete.Size = new Size(90, 35);
            btnDelete.Click += btnDelete_Click;

            btnSearch.Name = "btnSearch";
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Location = new Point(335, 100);
            btnSearch.Size = new Size(90, 35);
            btnSearch.Click += btnSearch_Click;

            grpFunction.Controls.Add(lblSearch);
            grpFunction.Controls.Add(txtSearch);
            grpFunction.Controls.Add(btnAdd);
            grpFunction.Controls.Add(btnEdit);
            grpFunction.Controls.Add(btnDelete);
            grpFunction.Controls.Add(btnSearch);

            // DataGridView
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Location = new Point(20, 280);
            dgvProducts.Size = new Size(940, 320);
            dgvProducts.ReadOnly = true;
            dgvProducts.MultiSelect = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.CellClick += dgvProducts_CellClick;

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Text = "Quản lý sản phẩm";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(grpProductInfo);
            Controls.Add(grpFunction);
            Controls.Add(dgvProducts);

            grpProductInfo.ResumeLayout(false);
            grpProductInfo.PerformLayout();
            grpFunction.ResumeLayout(false);
            grpFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }
    }
}
