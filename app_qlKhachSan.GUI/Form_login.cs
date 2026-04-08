using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private async void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!");
                return;
            }

            try
            {
                TaiKhoanBUS bus = new TaiKhoanBUS();
                TaiKhoanDTO tk = bus.DangNhap(username, password);

                if (tk != null)
                {
                    MessageBox.Show($"{tk.HoTen} | {tk.SDT} | {tk.VaiTro}");
                    MessageBox.Show("Đăng nhập thành công!");

                    FormHome home = new FormHome(tk.HoTen, tk.SDT, tk.VaiTro);
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        bool isShowPassword = false;

        private void picShowHide_Click(object sender, EventArgs e)
        {
            isShowPassword = !isShowPassword;

            txtPassword.UseSystemPasswordChar = !isShowPassword;
        }
    }
}