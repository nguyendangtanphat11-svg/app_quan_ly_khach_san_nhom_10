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
using System.Windows.Forms.DataVisualization.Charting;

namespace app_qlKhachSan
{
    public partial class Form_trang_chu : Form
    {
        private string CONNECTION_STRING = @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True;";
        SqlConnection conn;
        string ten;
        string sdt;
        string vaitro;
        public Form_trang_chu(string ten,string sdt,string vaitro)
        {
            InitializeComponent();
            this.ten = ten;
            this.sdt= sdt;
            this.vaitro = vaitro;
            hienthithongtin();
        }
        void hienthithongtin()
        {
            label_kq_ho_ten.Text = ten;
            label_kq_sdt.Text = sdt;
            label_kq_vai_tro.Text = vaitro;
        }
        

        private void Form_trang_chu_Load(object sender, EventArgs e)
        {
            this.ControlBox= false;
            conn = new SqlConnection(CONNECTION_STRING);
            LoadTongPhong();
            LoadPhongTrong();
            LoadPhongDangO();
            LoadDoanhThuHomNay();
            LoadSuDungDichVu();
            LoadBieuDoDoanhThuThang();

        }
        void LoadTongPhong()
        {
            string query = "SELECT COUNT(*) FROM Phong";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                int tongPhong = (int)cmd.ExecuteScalar();

                label_so_luong__so_phong.Text = tongPhong.ToString();
            }
        }
        void LoadPhongTrong()
        {
            string query = "SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Trống'";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                int phongTrong = (int)cmd.ExecuteScalar();

                label_so_luong_phong_trong.Text = phongTrong.ToString();
            }
        }
        void LoadPhongDangO()
        {
            string query = "SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Đang ở'";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                int phongDangO = (int)cmd.ExecuteScalar();

                label_so_luong__phong_o.Text = phongDangO.ToString();
            }
        }
        void LoadDoanhThuHomNay()
        {
            string query = @"SELECT ISNULL(SUM(TongTien),0)
                     FROM HoaDon
                     WHERE TrangThaiThanhToan = N'ĐÃ THANH TOÁN'
                     AND CAST(NgayTao AS DATE) = CAST(GETDATE() AS DATE)";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                decimal doanhThu = Convert.ToDecimal(cmd.ExecuteScalar());

                label_so_luong_doang_thu.Text = doanhThu.ToString("N0");
            }
        }
        void LoadSuDungDichVu()
        {
            string query = @"SELECT ISNULL(COUNT(MaSuDung),0)
                     FROM SuDungDichVu
                     WHERE CAST(ThoiGianSuDung AS DATE) = CAST(GETDATE() AS DATE)";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                int suDungDichVu = (int)cmd.ExecuteScalar();

                label_so_luong_dich_vu.Text = suDungDichVu.ToString();
            }
        }
        void LoadBieuDoDoanhThuThang()
        {
            chartDoanhThu.Series.Clear();
            Series series = new Series("Doanh Thu");

            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(52, 152, 219);
            series.IsValueShownAsLabel = true;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string query = @"
        SELECT 
        DAY(NgayTao) AS Ngay,
        SUM(TongTien) AS DoanhThu
        FROM HoaDon
        WHERE 
        MONTH(NgayTao) = MONTH(GETDATE())
        AND YEAR(NgayTao) = YEAR(GETDATE())
        AND TrangThaiThanhToan = N'ĐÃ THANH TOÁN'
        GROUP BY DAY(NgayTao)
        ORDER BY Ngay";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    series.Points.AddXY(reader["Ngay"], reader["DoanhThu"]);
                }
            }

            chartDoanhThu.Series.Add(series);
       
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel19_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {


        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel14_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel15_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel16_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel17_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel20_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel21_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel22_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel23_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel24_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel25_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel26_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel27_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel28_Click(object sender, EventArgs e)
        {

        }
    }
}
