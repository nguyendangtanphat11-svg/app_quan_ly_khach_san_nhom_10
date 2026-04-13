using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_them_dat_phong : Form
    {
        DatPhongBUS datPhongBUS = new DatPhongBUS();
        KhachHangBUS khachBUS = new KhachHangBUS();
        PhongBUS phongBUS = new PhongBUS();
        LoaiKhachHangBUS loaiBUS = new LoaiKhachHangBUS();
        PhuThuBUS phuThuBUS = new PhuThuBUS();
        BangGiaPhongBUS bangGiaBUS = new BangGiaPhongBUS();
        DatCocBUS datCocBUS = new DatCocBUS();


        public Form_them_dat_phong()
        {
            InitializeComponent();
        }


        // ================= LOAD FORM =================

        private void Form_them_dat_phong_Load(object sender, EventArgs e)
        {
            LoadPhong();

            LoadKhachHang();

            LoadLoaiKhachHang();

            LoadPhuThu();
        }


        // ================= LOAD PHÒNG =================

        void LoadPhong()
        {
            cbPhong.DataSource =
            phongBUS.GetPhongTrong();

            cbPhong.DisplayMember =
            "SoPhong";

            cbPhong.ValueMember =
            "MaPhong";
        }


        // ================= LOAD KHÁCH =================

        void LoadKhachHang()
        {
            cbKhachHang.DataSource =
            khachBUS.GetDanhSach();

            cbKhachHang.DisplayMember =
            "HoTen";

            cbKhachHang.ValueMember =
            "MaKhachHang";
        }


        // ================= LOAD LOẠI KHÁCH =================

        void LoadLoaiKhachHang()
        {
            cbLoaiKH.DataSource =
            loaiBUS.GetDanhSach();

            cbLoaiKH.DisplayMember =
            "TenLoaiKH";

            cbLoaiKH.ValueMember =
            "MaLoaiKH";
        }


        // ================= LOAD PHỤ THU =================

        void LoadPhuThu()
        {
            cbPhuThu.DataSource =
            phuThuBUS.GetDanhSach();

            cbPhuThu.DisplayMember =
            "TenPhuThu";

            cbPhuThu.ValueMember =
            "DonGia";
        }


        // ================= AUTO LOAD LOẠI KHÁCH =================

        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhachHang.SelectedItem is DataRowView row)
            {
                cbLoaiKH.SelectedValue =
                row["MaLoaiKH"];
            }

            TinhTongTien();
        }


        // ================= LOAD GIÁ PHÒNG =================

        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
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
            giaPhong.ToString();

            TinhTongTien();
        }


        // ================= EVENT THAY ĐỔI NGÀY =================

        private void dtpNgayNhan_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }


        // ================= EVENT PHỤ THU =================

        private void cbPhuThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }


        // ================= EVENT TIỀN ĐẶT CỌC =================

        private void txtTienDatCoc_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }


        // ================= HÀM TÍNH TỔNG TIỀN =================

        void TinhTongTien()
        {
            if (txtGiaPhong.Text == "")
                return;

            int soNgay =
            (dtpNgayTra.Value -
             dtpNgayNhan.Value).Days;

            if (soNgay <= 0)
                soNgay = 1;


            decimal giaPhong =
            decimal.Parse(txtGiaPhong.Text);


            decimal giamGia = 0;

            if (cbLoaiKH.SelectedItem is DataRowView row)
            {
                giamGia =
                Convert.ToDecimal(
                row["TyLeGiamGia"]);
            }


            decimal phuThu = 0;

            if (cbPhuThu.SelectedValue != null &&
                !(cbPhuThu.SelectedValue is DataRowView))
            {
                decimal.TryParse(
                cbPhuThu.SelectedValue.ToString(),
                out phuThu);
            }


            decimal tienDatCoc = 0;

            decimal.TryParse(
            txtTienDatCoc.Text,
            out tienDatCoc);


            decimal tongTien =
            (soNgay * giaPhong *
            (1 - giamGia))
            + phuThu
            - tienDatCoc;


            if (tongTien < 0)
                tongTien = 0;


            txtTongTien.Text =
            tongTien.ToString("N0");
        }


        // ================= LƯU ĐẶT PHÒNG =================

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtpNgayNhan.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày nhận không hợp lệ");
                return;
            }

            if (dtpNgayTra.Value <= dtpNgayNhan.Value)
            {
                MessageBox.Show("Ngày trả phải lớn hơn ngày nhận");
                return;
            }
            DatPhongDTO dp =
            new DatPhongDTO();

            dp.MaPhong =
            cbPhong.SelectedValue.ToString();

            dp.MaKhachHang =
            cbKhachHang.SelectedValue.ToString();

            dp.NgayNhanPhong =
            dtpNgayNhan.Value;

            dp.NgayTraPhong =
            dtpNgayTra.Value;

            dp.TrangThai =
            "ĐÃ ĐẶT";

            dp.GhiChu = "";


            datPhongBUS.Insert(dp);


            string maDatPhong =
            phongBUS.GetMaDatPhongMoiNhat();


            decimal tienDatCoc = 0;

            decimal.TryParse(
            txtTienDatCoc.Text,
            out tienDatCoc);


            DatCocDTO dc =
            new DatCocDTO();

            dc.MaDatPhong =
            maDatPhong;

            dc.SoTien =
            tienDatCoc;

            dc.HinhThuc =
            "Tiền mặt";

            dc.GhiChu = "";


            datCocBUS.Insert(dc);


            dp.TrangThai = "ĐÃ ĐẶT";

            phongBUS.UpdateTrangThai(
            cbPhong.SelectedValue.ToString(),
            "ĐANG Ở");


            MessageBox.Show(
            "Đặt phòng thành công 🎉");


            this.DialogResult =
            DialogResult.OK;

            this.Close();
        }


        // ================= HỦY =================

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}