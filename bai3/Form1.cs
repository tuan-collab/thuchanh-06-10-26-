using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai5_3
{
    public partial class Form1 : Form
    {
        List<Product> products = new List<Product>();
        BindingSource bindingSource = new BindingSource();

        Product sanPhamDangChon = null;

        public Form1()
        {
            InitializeComponent();

            bindingSource.DataSource = products;
            dgvProducts.DataSource = bindingSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();

                product.ProductId = txtProductId.Text;
                product.ProductName = txtProductName.Text;
                product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                product.Quantity = Convert.ToInt32(txtQuantity.Text);
                product.Category = cboCategory.Text;

                products.Add(product);

                HienThiDanhSach();
                XoaTrang();
            }
            catch
            {
                MessageBox.Show("Đơn giá và số lượng phải nhập đúng định dạng.");
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Product product = (Product)dgvProducts.Rows[e.RowIndex].DataBoundItem;

                sanPhamDangChon = product;

                txtProductId.Text = product.ProductId;
                txtProductName.Text = product.ProductName;
                txtUnitPrice.Text = product.UnitPrice.ToString();
                txtQuantity.Text = product.Quantity.ToString();
                cboCategory.Text = product.Category;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (sanPhamDangChon != null)
            {
                try
                {
                    sanPhamDangChon.ProductId = txtProductId.Text;
                    sanPhamDangChon.ProductName = txtProductName.Text;
                    sanPhamDangChon.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                    sanPhamDangChon.Quantity = Convert.ToInt32(txtQuantity.Text);
                    sanPhamDangChon.Category = cboCategory.Text;

                    HienThiDanhSach();
                    XoaTrang();
                }
                catch
                {
                    MessageBox.Show("Đơn giá và số lượng phải nhập đúng định dạng.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (sanPhamDangChon != null)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa sản phẩm này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    products.Remove(sanPhamDangChon);
                    HienThiDanhSach();
                    XoaTrang();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtSearch.Text.ToLower();

            if (tuKhoa == "")
            {
                HienThiDanhSach();
                return;
            }

            List<Product> ketQua = new List<Product>();

            foreach (Product product in products)
            {
                if (product.ProductName.ToLower().Contains(tuKhoa))
                {
                    ketQua.Add(product);
                }
            }

            bindingSource.DataSource = ketQua;
            dgvProducts.DataSource = bindingSource;
            sanPhamDangChon = null;
        }

        private void HienThiDanhSach()
        {
            bindingSource.DataSource = null;
            bindingSource.DataSource = products;
            dgvProducts.DataSource = bindingSource;
        }

        private void XoaTrang()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();

            cboCategory.SelectedIndex = -1;
            sanPhamDangChon = null;
        }
    }
}
