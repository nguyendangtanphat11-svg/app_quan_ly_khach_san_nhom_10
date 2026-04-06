using app_qlKhachSan.BUS;
using System;
using System.Data;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_dat_phong : Form
    {
        string maDatPhongDangChon = "";

        DatPhongBUS datPhongBUS = new DatPhongBUS();
        DanhSachKhachOBUS khachOBUS = new DanhSachKhachOBUS();
        KhachHangBUS khachBUS = new KhachHangBUS();
        PhongBUS phongBUS = new PhongBUS();
        LoaiKhachHangBUS loaiBUS = new LoaiKhachHangBUS();
        PhuThuBUS phuThuBUS = new PhuThuBUS();
        BangGiaPhongBUS bangGiaBUS = new BangGiaPhongBUS();
        DatCocBUS datCocBUS = new DatCocBUS();
        DonPhongBUS donPhongBUS = new DonPhongBUS();


        public Form_dat_phong()
        {
            InitializeComponent();
        }


        // ================= LOAD FORM =================

        private void Form_dat_phong_Load(object sender, EventArgs e)
        {
            LoadTatCaPhong();

            LoadKhachHang();

            LoadLoaiKH();

            LoadPhuThu();

            LoadDanhSachDatPhong();

            LoadDanhSachKhachO();

            KhoaThongTin();
        }


        // ================= LOAD DATA =================
        void LoadTatCaPhong()
        {
            cbPhong.DataSource =
            phongBUS.GetDanhSach();

            cbPhong.DisplayMember =
            "SoPhong";

            cbPhong.ValueMember =
            "MaPhong";
        }
        void LoadPhongTrong()
        {
            cbPhong.DataSource = phongBUS.GetPhongTrong();
            cbPhong.DisplayMember = "SoPhong";
            cbPhong.ValueMember = "MaPhong";
        }

        void LoadKhachHang()
        {
            cbKhachHang.DataSource = khachBUS.GetDanhSach();
            cbKhachHang.DisplayMember = "HoTen";
            cbKhachHang.ValueMember = "MaKhachHang";
        }

        void LoadLoaiKH()
        {
            cbLoaiKH.DataSource = loaiBUS.GetDanhSach();
            cbLoaiKH.DisplayMember = "TenLoaiKH";
            cbLoaiKH.ValueMember = "MaLoaiKH";
        }

        void LoadPhuThu()
        {
            cbPhuThu.DataSource = phuThuBUS.GetDanhSach();
            cbPhuThu.DisplayMember = "TenPhuThu";
            cbPhuThu.ValueMember = "DonGia";
        }

        void LoadDanhSachDatPhong()
        {
            dgvDatPhong.DataSource = datPhongBUS.GetDanhSach();
        }

        void LoadDanhSachKhachO()
        {
            dgvKhachO.DataSource = khachOBUS.GetDanhSach();
        }


        // ================= KHÓA PANEL =================

        void KhoaThongTin()
        {
            cbPhong.Enabled = false;
            cbKhachHang.Enabled = false;
            cbLoaiKH.Enabled = false;
            cbPhuThu.Enabled = false;
            txtGiaPhong.Enabled = false;
            txtTienDatCoc.Enabled = false;
            dtpNgayNhan.Enabled = false;
            dtpNgayTra.Enabled = false;
        }

        void MoKhoaThongTin()
        {
            cbPhong.Enabled = true;
            cbKhachHang.Enabled = true;
            cbLoaiKH.Enabled = true;
            cbPhuThu.Enabled = true;
            txtTienDatCoc.Enabled = true;
            dtpNgayNhan.Enabled = true;
            dtpNgayTra.Enabled = true;
        }


        // ================= CLICK GRID =================

        private void dgvDatPhong_CellClick(object sender,
        DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row =
            dgvDatPhong.Rows[e.RowIndex];

            maDatPhongDangChon =
            row.Cells["MaDatPhong"].Value.ToString();

            txtMaDatPhong.Text =
            maDatPhongDangChon;

            cbPhong.SelectedValue =
            row.Cells["MaPhong"].Value.ToString();

            cbKhachHang.SelectedValue =
            row.Cells["MaKhachHang"].Value.ToString();

            dtpNgayNhan.Value =
            Convert.ToDateTime(row.Cells["NgayNhanPhong"].Value);

            dtpNgayTra.Value =
            Convert.ToDateTime(row.Cells["NgayTraPhong"].Value);

            LoadGiaPhong();
            LoadTienDatCoc();
            TinhTongTien();

            KhoaThongTin();
        }


        // ================= LOAD GIÁ PHÒNG =================

        void LoadGiaPhong()
        {
            if (cbPhong.SelectedValue == null ||
                cbPhong.SelectedValue is DataRowView)
                return;

            string maLoaiPhong =
            phongBUS.GetMaLoaiPhong(
            cbPhong.SelectedValue.ToString());

            decimal giaPhong =
            bangGiaBUS.GetGiaMoiNhat(maLoaiPhong);

            txtGiaPhong.Text =
            giaPhong.ToString("N0");
        }


        void LoadTienDatCoc()
        {
            decimal tien =
            datCocBUS.GetTienDatCoc(maDatPhongDangChon);

            txtTienDatCoc.Text =
            tien.ToString("N0");
        }


        // ================= TÍNH TỔNG TIỀN =================

        void TinhTongTien()
        {
            if (txtGiaPhong.Text == "") return;

            int soNgay =
            (dtpNgayTra.Value - dtpNgayNhan.Value).Days;

            if (soNgay <= 0) soNgay = 1;

            decimal giaPhong =
            decimal.Parse(txtGiaPhong.Text);

            decimal giamGia = 0;

            if (cbLoaiKH.SelectedItem is DataRowView row)
                giamGia =
                Convert.ToDecimal(row["TyLeGiamGia"]);

            decimal phuThu = 0;

            if (cbPhuThu.SelectedValue != null)
                decimal.TryParse(
                cbPhuThu.SelectedValue.ToString(),
                out phuThu);

            decimal tong =
            soNgay * giaPhong *
            (1 - giamGia) + phuThu;

            txtTongTien.Text =
            tong.ToString("N0");
        }


        // ================= EVENT =================

        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGiaPhong();
            TinhTongTien();
        }

        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhachHang.SelectedItem is DataRowView row)
                cbLoaiKH.SelectedValue =
                row["MaLoaiKH"];

            TinhTongTien();
        }

        private void cbPhuThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void dtpNgayNhan_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }


        // ================= NÚT SỬA =================

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDatPhongDangChon == "")
                return;

            MoKhoaThongTin();
        }


        // ================= NÚT XÓA =================

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDatPhongDangChon == "") return;

            datCocBUS.Delete(maDatPhongDangChon);

            datPhongBUS.Delete(maDatPhongDangChon);

            phongBUS.UpdateTrangThai(
            cbPhong.SelectedValue.ToString(),
            "TRỐNG");

            LoadDanhSachDatPhong();
        }


        // ================= NÚT HỦY =================

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (maDatPhongDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn đặt phòng cần sửa!");
                return;
            }

            string maPhong = cbPhong.SelectedValue.ToString();
            string maKhachHang = cbKhachHang.SelectedValue.ToString();
            DateTime ngayNhan = dtpNgayNhan.Value;
            DateTime ngayTra = dtpNgayTra.Value;

            bool kq = datPhongBUS.UpdateThongTin(
                maDatPhongDangChon,
                maPhong,
                maKhachHang,
                ngayNhan,
                ngayTra
            );

            if (kq)
            {
                MessageBox.Show("Cập nhật thành công!");

                LoadDanhSachDatPhong();

                KhoaThongTin();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }


        // ================= CHECKOUT =================

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (maDatPhongDangChon == "") return;

            datPhongBUS.UpdateTrangThai(
Convert.ToInt64(maDatPhongDangChon),
"ĐÃ HỦY");

            string maPhong =
 cbPhong.SelectedValue.ToString();

            phongBUS.UpdateTrangThai(
            maPhong,
            "CẦN DỌN");

            donPhongBUS.TaoDonPhong(maPhong);

            LoadDanhSachDatPhong();
        }


        // ================= LÀM MỚI =================

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDatPhong.Clear();
            txtGiaPhong.Clear();
            txtTienDatCoc.Clear();
            txtTongTien.Clear();

            maDatPhongDangChon = "";

            LoadDanhSachDatPhong();

            KhoaThongTin();
        }


        // ================= POPUP ĐẶT PHÒNG =================

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            Form_them_dat_phong f =
            new Form_them_dat_phong();

            if (f.ShowDialog() == DialogResult.OK)
                LoadDanhSachDatPhong();
        }

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            if (maDatPhongDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn đặt phòng trước!");
                return;
            }

            Form_them_khach_o_cung f =
            new Form_them_khach_o_cung(maDatPhongDangChon);

            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachKhachO();
            }
        }
    }
}