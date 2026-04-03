using app_qlKhachSan.BUS;
using System;
using System.Data;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_don_phong : Form
    {
        // ===== BUS =====
        DonPhongBUS donPhongBUS = new DonPhongBUS();
        NhanVienBUS nhanVienBUS = new NhanVienBUS();


        public Form_don_phong()
        {
            InitializeComponent();
        }


        // ===== LOAD FORM =====
        private void Form_don_phong_Load(object sender, EventArgs e)
        {
            LoadDanhSachDonPhong();
            LoadNhanVien();
        }


        // ===== LOAD DANH SÁCH PHÒNG CẦN DỌN =====
        void LoadDanhSachDonPhong()
        {
            dgvDonPhong.DataSource =
                donPhongBUS.GetDonPhongCanDon();

            dgvDonPhong.ClearSelection();
        }


        // ===== LOAD NHÂN VIÊN =====
        void LoadNhanVien()
        {
            cmbNhanVien.DataSource =
                nhanVienBUS.GetNhanVien();

            cmbNhanVien.DisplayMember =
                "TenNhanVien";

            cmbNhanVien.ValueMember =
                "MaNhanVien";

            cmbNhanVien.SelectedIndex = -1;
        }


        // ===== CHỌN NHÂN VIÊN → HIỂN THỊ THÔNG TIN =====
        private void cmbNhanVien_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbNhanVien.SelectedItem == null) return;

            DataRowView row =
                cmbNhanVien.SelectedItem as DataRowView;

            if (row == null) return;

            txtTenNhanVien.Text =
                row["TenNhanVien"].ToString();

            txtSDT.Text =
                row["DienThoai"].ToString();

            txtChucVu.Text =
                row["ChucVu"].ToString();

            txtTrangThai.Text =
                row["TrangThai"].ToString();
        }


        // ===== CLICK DÒNG PHÒNG =====
        private void dgvDonPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtGhiChu.Text =
                dgvDonPhong.Rows[e.RowIndex]
                .Cells["GhiChu"]
                .Value?.ToString();
        }


        // ===== NHẬN ĐƠN =====
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dgvDonPhong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn phòng.");
                return;
            }

            if (cmbNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.");
                return;
            }

            int maDonPhong =
                Convert.ToInt32(
                dgvDonPhong.CurrentRow
                .Cells["MaDonPhong"].Value);

            int maNhanVien =
                Convert.ToInt32(
                cmbNhanVien.SelectedValue);

            bool ketQua =
                donPhongBUS.NhanDon(
                    maDonPhong,
                    maNhanVien);

            if (ketQua)
            {
                MessageBox.Show("Nhận đơn thành công.");

                LoadDanhSachDonPhong();
            }
            else
            {
                MessageBox.Show("Nhận đơn thất bại.");
            }
        }


        // ===== HOÀN THÀNH DỌN =====
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgvDonPhong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn phòng.");
                return;
            }

            int maDonPhong =
                Convert.ToInt32(
                dgvDonPhong.CurrentRow
                .Cells["MaDonPhong"].Value);

            string ghiChu =
                txtGhiChu.Text.Trim();

            bool ketQua =
                donPhongBUS.HoanThanhDon(
                    maDonPhong,
                    ghiChu);

            if (ketQua)
            {
                MessageBox.Show("Hoàn thành dọn phòng.");

                LoadDanhSachDonPhong();

                txtGhiChu.Clear();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
        }


        // ===== RELOAD =====
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadDanhSachDonPhong();

            LoadNhanVien();

            txtTenNhanVien.Clear();

            txtSDT.Clear();

            txtChucVu.Clear();

            txtTrangThai.Clear();

            txtGhiChu.Clear();
        }

      
    }
}