using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32.SafeHandles;

namespace app_qlKhachSan
{
    public partial class FormLogin : Form
    {
        private string CONNECTION_STRING =@"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True;";
        public FormLogin()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel_Tieude1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel_HINHANH1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    string query = @"SELECT tk.HoTen, tk.SDT, vt.TenVaiTro
                 FROM TaiKhoan tk
                 JOIN PhanQuyen pq ON tk.MaTaiKhoan = pq.MaTaiKhoan
                 JOIN VaiTro vt ON pq.MaVaiTro = vt.MaVaiTro
                 WHERE tk.TenDangNhap = @username
                 AND tk.MatKhauHash = @password
                 AND tk.TrangThai = 1";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string ten = reader["HoTen"].ToString();
                        string sdt = reader["SDT"].ToString();
                        string vaitro = reader["TenVaiTro"].ToString();
                        MessageBox.Show(ten + " | " + sdt + " | " + vaitro);
                        MessageBox.Show("Đăng nhập thành công!");

                        FormHome home = new FormHome(ten, sdt, vaitro);
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void hinhanhlogin1_Click(object sender, EventArgs e)
        {

        }
    }
}
