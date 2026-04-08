using System;
using System.Windows.Forms;
using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;

namespace app_qlKhachSan
{
    public partial class Form_tai_khoan : Form
    {
        TaiKhoanBUS bus = new TaiKhoanBUS();

        public Form_tai_khoan()
        {
            InitializeComponent();
        }

        void LoadDanhSach()
        {
            dgvTaiKhoan.DataSource = bus.GetDanhSach();
        }

        private void Form_tai_khoan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            LoadDanhSach();
        }

        private void dgvTaiKhoan_CellClick(object sender,
        DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtMaTaiKhoan.Text =
            dgvTaiKhoan.CurrentRow.Cells["MaTaiKhoan"].Value.ToString();

            txtTenDangNhap.Text =
            dgvTaiKhoan.CurrentRow.Cells["TenDangNhap"].Value.ToString();

            txtHoTen.Text =
            dgvTaiKhoan.CurrentRow.Cells["HoTen"].Value.ToString();

            txtSDT.Text =
            dgvTaiKhoan.CurrentRow.Cells["SDT"].Value.ToString();

            txtMaNhanVien.Text =
            dgvTaiKhoan.CurrentRow.Cells["MaNhanVien"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();

            tk.MaTaiKhoan = txtMaTaiKhoan.Text;
            tk.TenDangNhap = txtTenDangNhap.Text;
            tk.MatKhauHash = txtMatKhau.Text;
            tk.HoTen = txtHoTen.Text;
            tk.SDT = txtSDT.Text;
            tk.TrangThai = "1";
            tk.NgayTao = DateTime.Now;
            tk.MaNhanVien = txtMaNhanVien.Text;

            if (bus.Insert(tk))
            {
                MessageBox.Show("Thêm tài khoản thành công");

                LoadDanhSach();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();

            tk.MaTaiKhoan = txtMaTaiKhoan.Text;
            tk.TenDangNhap = txtTenDangNhap.Text;
            tk.HoTen = txtHoTen.Text;
            tk.SDT = txtSDT.Text;
            tk.TrangThai = "1";
            tk.MaNhanVien = txtMaNhanVien.Text;

            if (bus.Update(tk))
            {
                MessageBox.Show("Cập nhật thành công");

                LoadDanhSach();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bus.Delete(txtMaTaiKhoan.Text))
            {
                MessageBox.Show("Xóa thành công");

                LoadDanhSach();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaTaiKhoan.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtMaNhanVien.Clear();

            txtMaTaiKhoan.Focus();
        }
    }
}