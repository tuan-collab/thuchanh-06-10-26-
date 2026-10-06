using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace bai5._2
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string>> dichVu = new Dictionary<string, List<string>>();
        public Form1()
        {
            InitializeComponent();

            dichVu.Add("Khám bệnh", new List<string>
    {
            "Khám tổng quát - 200000",
            "Khám chuyên khoa - 300000"
    });

            dichVu.Add("Xét nghiệm", new List<string>
    {
            "Xét nghiệm máu - 150000",
            "Xét nghiệm nước tiểu - 100000"
    });

            dichVu.Add("Chụp X-Quang", new List<string>
    {
            "X-Quang phổi - 250000",
            "X-Quang xương - 300000"
    });

            dichVu.Add("Vắc-xin", new List<string>
    {
            "Vắc-xin cúm - 350000",
            "Vắc-xin viêm gan B - 400000"
    });

            cboCategory.Items.Add("Khám bệnh");
            cboCategory.Items.Add("Xét nghiệm");
            cboCategory.Items.Add("Chụp X-Quang");
            cboCategory.Items.Add("Vắc-xin");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableServices.Items.Clear();

            string loai = cboCategory.Text;

            if (dichVu.ContainsKey(loai))
            {
                foreach (string item in dichVu[loai])
                {
                    lstAvailableServices.Items.Add(item);
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Add(lstAvailableServices.SelectedItem);
                lstAvailableServices.Items.Remove(lstAvailableServices.SelectedItem);

                TinhTien();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.SelectedItem != null)
            {
                lstAvailableServices.Items.Add(lstSelectedServices.SelectedItem);
                lstSelectedServices.Items.Remove(lstSelectedServices.SelectedItem);

                TinhTien();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            while (lstSelectedServices.Items.Count > 0)
            {
                lstAvailableServices.Items.Add(lstSelectedServices.Items[0]);
                lstSelectedServices.Items.RemoveAt(0);
            }

            TinhTien();
        }

        private void lstAvailableServices_DoubleClick(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Add(lstAvailableServices.SelectedItem);
                lstAvailableServices.Items.Remove(lstAvailableServices.SelectedItem);

                TinhTien();
            }
        }
        private void TinhTien()
        {
            decimal tongTien = 0;

            foreach (string item in lstSelectedServices.Items)
            {
                int Vitri = item.LastIndexOf("-");
                
                string giatien = item.Substring(Vitri + 1).Trim();

                decimal gia = decimal.Parse(giatien);

                tongTien += gia;
            }

            lblTotal.Text = "Tổng tiền chưa giảm: " + tongTien.ToString("N0") + " VNĐ";
            lblPayment.Text = "Thành tiền thanh toán: " + tongTien.ToString("N0") + " VNĐ";
        }
    }
}
