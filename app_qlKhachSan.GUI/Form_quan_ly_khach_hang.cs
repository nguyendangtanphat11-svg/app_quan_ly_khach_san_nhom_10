using System;
using System.Data;
using System.Windows.Forms;
using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;

namespace app_qlKhachSan
{
    public partial class Form_quan_ly_khach_hang : Form
    {
        KhachHangBUS bus = new KhachHangBUS();
        LoaiKhachHangBUS loaiBUS = new LoaiKhachHangBUS();
        void KhoaTextBox(bool trangThai)
        {
            txtMaKH.Enabled = false;
               // thường không cho sửa mã
            txtHoTen.Enabled = trangThai;
            txtCCCD.Enabled = trangThai;
            txtSDT.Enabled = trangThai;
            txtEmail.Enabled = trangThai;
            txtDiaChi.Enabled = trangThai;
            txtQuocTich.Enabled = trangThai;
            cbLoaiKH.Enabled = trangThai;
        }

        bool isAdding = false;

        public Form_quan_ly_khach_hang()
        {
            InitializeComponent();
        }

        private void Form_quan_ly_khach_hang_Load(object sender, EventArgs e)
        {

            this.ControlBox = false;

            LoadDanhSach();
            LoadLoaiKhach();

            KhoaTextBox(false);
        }


        // ================= LOAD DANH SÁCH =================

        void LoadDanhSach()
        {
            dgvKhachHang.DataSource = bus.GetDanhSach();
        }


        // ================= LOAD LOẠI KHÁCH =================

        void LoadLoaiKhach()
        {
            cbLoaiKH.DataSource = loaiBUS.GetDanhSach();

            cbLoaiKH.DisplayMember = "TenLoaiKH";

            cbLoaiKH.ValueMember = "MaLoaiKH";
        }


        // ================= CLICK GRID =================

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKH.Text =
                    dgvKhachHang.Rows[e.RowIndex]
                    .Cells["MaKhachHang"].Value.ToString();

                txtHoTen.Text =
                    dgvKhachHang.Rows[e.RowIndex]
                    .Cells["HoTen"].Value.ToString();

                txtCCCD.Text =
                dgvKhachHang.Rows[e.RowIndex]
                .Cells["CCCD_Passport"].Value.ToString();

                txtSDT.Text =
                    dgvKhachHang.Rows[e.RowIndex]
                    .Cells["SDT"].Value.ToString();

                txtEmail.Text =
                    dgvKhachHang.Rows[e.RowIndex]
                    .Cells["Email"].Value.ToString();

                txtDiaChi.Text =
                    dgvKhachHang.Rows[e.RowIndex]
                    .Cells["DiaChi"].Value.ToString();

                txtQuocTich.Text =
                    dgvKhachHang.Rows[e.RowIndex]
                    .Cells["QuocTich"].Value.ToString();

                cbLoaiKH.SelectedValue =
                    dgvKhachHang.Rows[e.RowIndex]
                    .Cells["MaLoaiKH"].Value;
            }
        }


        // ================= THÊM =================

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form_them_khach f = new Form_them_khach();

            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSach();
            }
        }


        // ================= SỬA =================

        private void btnSua_Click(object sender, EventArgs e)
        {
            isAdding = false;

            KhoaTextBox(true); // mở textbox để sửa
        }


        // ================= LƯU =================

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();

            kh.MaKhachHang = int.Parse(txtMaKH.Text);

            kh.MaLoaiKH =
                Convert.ToInt32(cbLoaiKH.SelectedValue);

            kh.HoTen = txtHoTen.Text;

            kh.CCCD_Passport = txtCCCD.Text;

            kh.SDT = txtSDT.Text;

            kh.Email = txtEmail.Text;

            kh.DiaChi = txtDiaChi.Text;

            kh.QuocTich = txtQuocTich.Text;

            kh.NgayTao = DateTime.Now;


            bool result;


            if (isAdding)
                result = bus.Them(kh);
            else
                result = bus.Sua(kh);


            if (result)
            {
                MessageBox.Show("Lưu thành công");

                LoadDanhSach();

                KhoaTextBox(false); // khóa lại
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }
        }


        // ================= XÓA =================

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Chưa chọn khách hàng cần xóa");
                return;
            }

            int maKH;

            if (!int.TryParse(txtMaKH.Text, out maKH))
            {
                MessageBox.Show("Mã khách hàng không hợp lệ");
                return;
            }

            if (bus.Xoa(maKH))
            {
                MessageBox.Show("Xóa thành công");

                LoadDanhSach();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }


        // ================= HỦY =================

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtQuocTich.Clear();

            KhoaTextBox(false);
        }

        
    }
}