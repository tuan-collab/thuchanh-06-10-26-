namespace bai1_06_10_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            epCheck.Clear();

            bool hopLe = true;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                epCheck.SetError(txtUsername, "Tên đăng nhập không được để trống");
                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                epCheck.SetError(txtPassword, "Mật khẩu không được để trống");
                hopLe = false;
            }

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                epCheck.SetError(txtConfirmPassword, "Mật khẩu nhập lại không khớp");
                hopLe = false;
            }

            int tuoi = DateTime.Now.Year - dtpBirthDate.Value.Year;

            if (dtpBirthDate.Value.Date > DateTime.Now.AddYears(-tuoi).Date)
            {
                tuoi--;
            }

            if (tuoi < 18)
            {
                epCheck.SetError(dtpBirthDate, "Bạn phải đủ 18 tuổi");
                hopLe = false;
            }

            if (!chkTerms.Checked)
            {
                epCheck.SetError(chkTerms, "Bạn phải đồng ý với điều khoản dịch vụ");
                hopLe = false;
            }

            if (hopLe)
            {
                MessageBox.Show(
                    "Đăng ký tài khoản thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            dtpBirthDate.Value = DateTime.Now;

            rdoMale.Checked = false;
            rdoFemale.Checked = false;

            chkTerms.Checked = false;

            epCheck.Clear();

            txtUsername.Focus();
        }
    }
}
