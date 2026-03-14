using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class FormLoaiPhong : Form
    {
        private string CONNECTION_STRING = @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True;";
        public FormLoaiPhong()
        {
            InitializeComponent();

        }
        void laodLoaiPhong()
        {
            using(SqlConnection conn =new SqlConnection (CONNECTION_STRING))
            {
               conn.Open();
                string query = "SELECT MaLoaiPhong, TenLoaiPhong FROM LoaiPhong";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLoaiPhong.DataSource = dt;
            }
        }

        private void FormLoaiPhong_Load(object sender, EventArgs e)
        {

        }

        private void keo_tha_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabel_phong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                txtMaLoai.Text = dgvLoaiPhong.Rows[row].Cells["MaLoaiPhong"].Value.ToString();
                txtTenLoai.Text = dgvLoaiPhong.Rows[row].Cells["TenLoaiPhong"].Value.ToString();
                txtGiaTheoNgay.Text = dgvLoaiPhong.Rows[row].Cells["GiaTheoNgay"].Value.ToString();
                txtGiaTheoGio.Text = dgvLoaiPhong.Rows[row].Cells["GiaTheoGio"].Value.ToString();
                txtSoNguoi.Text = dgvLoaiPhong.Rows[row].Cells["SoNguoiToiDa"].Value.ToString();
                txtMoTa.Text = dgvLoaiPhong.Rows[row].Cells["MoTa"].Value.ToString();
            }
        }

        private void guna2Button_luu_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=QLKhachSan;Integrated Security=True");

            string sql = @"UPDATE LoaiPhong 
                   SET TenLoaiPhong=@ten,
                       GiaTheoNgay=@ngay,
                       GiaTheoGio=@gio,
                       SoNguoiToiDa=@songuoi,
                       MoTa=@mota
                   WHERE MaLoaiPhong=@ma";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma", txtMaLoai.Text);
            cmd.Parameters.AddWithValue("@ten", txtTenLoai.Text);
            cmd.Parameters.AddWithValue("@ngay", txtGiaTheoNgay.Text);
            cmd.Parameters.AddWithValue("@gio", txtGiaTheoGio.Text);
            cmd.Parameters.AddWithValue("@songuoi", txtSoNguoi.Text);
            cmd.Parameters.AddWithValue("@mota", txtMoTa.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Cập nhật thành công");
            this.Close();

        }

        private void guna2Button_xoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=QLKhachSan;Integrated Security=True");

            string sql = "DELETE FROM LoaiPhong WHERE MaLoaiPhong=@ma";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma", txtMaLoai.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Đã xóa");
            this.Close();



        }
    }
}
