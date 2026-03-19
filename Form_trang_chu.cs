using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;

namespace app_qlKhachSan

{
    public partial class Form_trang_chu : Form
    {
        string ten;
        string sdt;
        string vaitro;

        TrangChuBUS bus = new TrangChuBUS();

        public Form_trang_chu(string ten, string sdt, string vaitro)
        {
            InitializeComponent();
            this.ten = ten;
            this.sdt = sdt;
            this.vaitro = vaitro;

            HienThiThongTin();
        }

        // ================= HIỂN THỊ USER =================
        void HienThiThongTin()
        {
            label_kq_ho_ten.Text = ten;
            label_kq_sdt.Text = sdt;
            label_kq_vai_tro.Text = vaitro;
        }

        // ================= LOAD =================
        private void Form_trang_chu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            LoadThongKe();
            LoadChart();
            this.Dock = DockStyle.Fill;
        }



        // ================= LOAD THỐNG KÊ =================
        void LoadThongKe()
        {
            label_so_luong__so_phong.Text = bus.TongPhong().ToString();
            label_so_luong_phong_trong.Text = bus.PhongTrong().ToString();
            label_so_luong__phong_o.Text = bus.PhongDangO().ToString();
            label_so_luong_doang_thu.Text = bus.DoanhThuHomNay().ToString("N0");
            label_so_luong_dich_vu.Text = bus.SuDungDichVu().ToString();
        }

        // ================= BIỂU ĐỒ =================
        void LoadChart()
        {
            chartDoanhThu.Series.Clear();

            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(52, 152, 219);
            series.IsValueShownAsLabel = true;

            var data = bus.DoanhThuThang();

            foreach (var item in data)
            {
                series.Points.AddXY(item.Ngay, item.DoanhThu);
            }

            chartDoanhThu.Series.Add(series);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_so_luong_phong_trong_Click(object sender, EventArgs e)
        {

        }

        private void panel_phong_trong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartDoanhThu_Click(object sender, EventArgs e)
        {

        }

        private void label_bieu_do_Click(object sender, EventArgs e)
        {

        }

        private void label_so_luong_doang_thu_Click(object sender, EventArgs e)
        {

        }

        private void label_doang_thu_Click(object sender, EventArgs e)
        {

        }

        private void panel_dich_vu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_so_luong_dich_vu_Click(object sender, EventArgs e)
        {

        }

        private void label_dich_vu_Click(object sender, EventArgs e)
        {

        }

        private void label_chu_thich__phong_o_Click(object sender, EventArgs e)
        {

        }

        private void label_so_luong__phong_o_Click(object sender, EventArgs e)
        {

        }

        private void label_chu_thich_doang_thu_Click(object sender, EventArgs e)
        {

        }

        private void label__phong_o_Click(object sender, EventArgs e)
        {

        }

        private void label_chuthich__so_phong_Click(object sender, EventArgs e)
        {

        }

        private void label_so_luong__so_phong_Click(object sender, EventArgs e)
        {

        }

        private void lablel_so_phong_Click(object sender, EventArgs e)
        {

        }

        private void label_tieude_Click(object sender, EventArgs e)
        {

        }

        private void panel_cha_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_kq_sdt_Click(object sender, EventArgs e)
        {

        }

        private void label_kq_ho_ten_Click(object sender, EventArgs e)
        {

        }

        private void label_sdt_Click(object sender, EventArgs e)
        {

        }

        private void label_hoten_Click(object sender, EventArgs e)
        {

        }

        private void label_kq_vai_tro_Click(object sender, EventArgs e)
        {

        }

        private void label_taikhoan_Click(object sender, EventArgs e)
        {

        }

        private void label_vai_tro_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel21_Click(object sender, EventArgs e)
        {

        }

        private void label_chu_thich_phong_trong_Click(object sender, EventArgs e)
        {

        }

        private void label_phong_trong_Click(object sender, EventArgs e)
        {

        }

        private void panel_doang_thu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_sophong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_tai_khoan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_bieu_do_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_phong_o_Paint(object sender, PaintEventArgs e)
        {

        }

        private void icon_phong_o_Click(object sender, EventArgs e)
        {

        }

        private void icon_dich_vu_Click(object sender, EventArgs e)
        {

        }

        private void icon_phong_trong_Click(object sender, EventArgs e)
        {

        }

        private void icon_tai_khoan_Click(object sender, EventArgs e)
        {

        }

        private void icon_so_phong_Click(object sender, EventArgs e)
        {

        }

        private void icon_doanh_thu_Click(object sender, EventArgs e)
        {

        }
    }
}