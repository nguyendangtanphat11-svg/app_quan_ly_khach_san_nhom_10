using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_thanh_toan : Form
    {
        DatPhongBUS datPhongBUS =
        new DatPhongBUS();

        SuDungDichVuBUS suDungBUS =
        new SuDungDichVuBUS();
        long maDatPhong;
        HoaDonBUS hoaDonBUS =
        new HoaDonBUS();
        ThanhToanBUS thanhToanBUS = new ThanhToanBUS();


        public Form_thanh_toan()
        {
            InitializeComponent();
        }
        public Form_thanh_toan(long maDatPhong)
        {
            InitializeComponent();

            this.maDatPhong = maDatPhong;
        }


        // ================= LOAD FORM =================

        private void Form_thanh_toan_Load(
        object sender,
        EventArgs e)
        {
            this.ControlBox = false;

            LoadPhongDangO();
            LoadTatCaLichSuThanhToan();
        }


        // ================= LOAD PHÒNG ĐANG Ở =================

        void LoadPhongDangO()
        {
            cbMaDatPhong.DataSource =
            datPhongBUS.GetPhongDangO();

            cbMaDatPhong.DisplayMember =
            "MaDatPhong";

            cbMaDatPhong.ValueMember =
            "MaDatPhong";
        }
        void LoadThongTinDatPhong(long maDatPhong)
        {
            DataRow row =
            datPhongBUS.GetThongTinThanhToan(maDatPhong);

            if (row == null)
                return;

            txtPhong.Text =
            row["SoPhong"].ToString();

            txtKhachHang.Text =
            row["HoTen"].ToString();

            dtpNgayNhan.Value =
            Convert.ToDateTime(row["NgayNhanPhong"]);

            dtpNgayTra.Value =
            Convert.ToDateTime(row["NgayTraPhong"]);
        }
        void LoadLichSuThanhToan(long maDatPhong)
        {
            dgvLichSuThanhToan.DataSource =
            thanhToanBUS.GetByMaDatPhong(maDatPhong);
        }
        void LoadTatCaLichSuThanhToan()
        {
            dgvLichSuThanhToan.DataSource =
            thanhToanBUS.GetAll();
        }

        // ================= CHỌN MÃ ĐẶT PHÒNG =================

        private void cbMaDatPhong_SelectedIndexChanged(
object sender,
EventArgs e)
        {
            if (!(cbMaDatPhong.SelectedValue is long maDatPhong))
                return;

            LoadThongTinDatPhong(maDatPhong);

            LoadTienPhong(maDatPhong);

            LoadTienDichVu(maDatPhong);

            LoadDanhSachDichVu(maDatPhong);

            LoadLichSuThanhToan(maDatPhong);
        }


        // ================= LOAD TIỀN PHÒNG =================

        void LoadTienPhong(long maDatPhong)
        {
            decimal tienPhong =
            datPhongBUS.GetTienPhong(maDatPhong);

            txtTienPhong.Text =
            tienPhong.ToString("N0");
        }


        // ================= LOAD TIỀN DỊCH VỤ =================

        void LoadTienDichVu(long maDatPhong)
        {
            decimal tienDV =
            suDungBUS.GetTongTienDichVu(maDatPhong);

            txtTienDichVu.Text =
            tienDV.ToString("N0");
        }


        // ================= LOAD GRID DỊCH VỤ =================

        void LoadDanhSachDichVu(long maDatPhong)
        {
            dgvDichVuDaDung.DataSource =
            suDungBUS.GetByMaDatPhong(maDatPhong);
        }


        // ================= TÍNH TIỀN =================

        private void btnTinhTien_Click(
        object sender,
        EventArgs e)
        {
            decimal tienPhong =
            string.IsNullOrEmpty(txtTienPhong.Text)
            ? 0
            : decimal.Parse(txtTienPhong.Text);

            decimal tienDV =
            string.IsNullOrEmpty(txtTienDichVu.Text)
            ? 0
            : decimal.Parse(txtTienDichVu.Text);

            decimal vat =
            string.IsNullOrEmpty(txtVAT.Text)
            ? 0
            : decimal.Parse(txtVAT.Text);

            decimal giamGia =
            string.IsNullOrEmpty(txtGiamGia.Text)
            ? 0
            : decimal.Parse(txtGiamGia.Text);


            decimal tongTien =
            tienPhong + tienDV + vat - giamGia;


            txtTongTien.Text =
            tongTien.ToString("N0");
        }


        // ================= THANH TOÁN =================

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!(cbMaDatPhong.SelectedValue is long maDatPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            decimal tienPhong =
            string.IsNullOrEmpty(txtTienPhong.Text)
            ? 0 : decimal.Parse(txtTienPhong.Text);

            decimal tienDV =
            string.IsNullOrEmpty(txtTienDichVu.Text)
            ? 0 : decimal.Parse(txtTienDichVu.Text);

            decimal tongTien =
            string.IsNullOrEmpty(txtTongTien.Text)
            ? 0 : decimal.Parse(txtTongTien.Text);


            // ===== TẠO HÓA ĐƠN =====

            if (!hoaDonBUS.Exists(maDatPhong))
            {
                HoaDonDTO hd = new HoaDonDTO();

                hd.MaDatPhong = maDatPhong;
                hd.TienPhong = tienPhong;
                hd.TienDichVu = tienDV;
                hd.TongTien = tongTien;

                hoaDonBUS.Insert(hd);
            }


            // ===== LẤY MÃ HÓA ĐƠN =====

            int maHoaDon =
            hoaDonBUS.GetMaHoaDonByMaDatPhong(maDatPhong);


            // ===== MỞ FORM THANH TOÁN =====

            Form_them_thanh_toan popup =
            new Form_them_thanh_toan(
                maHoaDon,
                maDatPhong,
                tongTien
            );

            if (popup.ShowDialog() == DialogResult.OK)
            {
                // reload lịch sử thanh toán toàn bộ
                LoadTatCaLichSuThanhToan();

                // reload combobox phòng đang ở
                LoadPhongDangO();
            }
        }


        // ================= LÀM MỚI =================

        private void btnLamMoi_Click(
        object sender,
        EventArgs e)
        {
            txtTienPhong.Clear();
            txtTienDichVu.Clear();
            txtVAT.Clear();
            txtGiamGia.Clear();
            txtTongTien.Clear();

            dgvDichVuDaDung.DataSource = null;

            cbMaDatPhong.SelectedIndex = -1;
        }
    }
}