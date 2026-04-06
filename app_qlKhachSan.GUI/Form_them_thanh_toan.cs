using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_them_thanh_toan : Form
    {
        ThanhToanBUS thanhToanBUS =
        new ThanhToanBUS();

        DatPhongBUS datPhongBUS =
        new DatPhongBUS();
        PhongBUS phongBUS = new PhongBUS();
        DonPhongBUS donPhongBUS = new DonPhongBUS();


        int maHoaDon;
        long maDatPhong;
        decimal tongTien;


        public Form_them_thanh_toan(
        int maHD,
        long maDP,
        decimal tong)
        {
            InitializeComponent();

            maHoaDon = maHD;
            maDatPhong = maDP;
            tongTien = tong;
        }


        // ================= LOAD FORM =================

        private void Form_them_thanh_toan_Load(
        object sender,
        EventArgs e)
        {
            cbPhuongThuc.Items.Clear();

            cbPhuongThuc.Items.Add("TIỀN MẶT");
            cbPhuongThuc.Items.Add("CHUYỂN KHOẢN");
            cbPhuongThuc.Items.Add("MOMO");

            txtTongTien.Text =
            tongTien.ToString("N0");
        }


        // ================= NÚT LƯU =================

        private void btnLuu_Click(
        object sender,
        EventArgs e)
        {
            if (string.IsNullOrEmpty(cbPhuongThuc.Text))
            {
                MessageBox.Show(
                "Chọn phương thức thanh toán!");
                return;
            }


            ThanhToanDTO tt =
            new ThanhToanDTO();

            tt.MaHoaDon =
            maHoaDon;

            tt.SoTienThanhToan =
            tongTien;

            tt.PhuongThuc =
            cbPhuongThuc.Text;


            thanhToanBUS.Insert(tt);


            // update trạng thái đặt phòng

            datPhongBUS.UpdateTrangThai(
            maDatPhong,
            "ĐÃ TRẢ");
            string maPhong =
            datPhongBUS.GetMaPhongByMaDatPhong(maDatPhong);

            // chuyển phòng sang cần dọn

            phongBUS.UpdateTrangThai(
            maPhong,
            "CẦN DỌN");

            // tạo đơn dọn phòng

            donPhongBUS.TaoDonPhong(maPhong);


            MessageBox.Show(
            "Thanh toán thành công!");


            this.DialogResult =
            DialogResult.OK;

            Close();
        }


        // ================= NÚT HỦY =================

        private void btnHuy_Click(
        object sender,
        EventArgs e)
        {
            Close();
        }
    }
}