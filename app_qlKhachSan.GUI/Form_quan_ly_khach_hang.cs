using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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
            StyleButtonsLoaiPhong();
            LoadDanhSach();
            LoadLoaiKhach();
            
            KhoaTextBox(false);
            StyleDataGridView(dgvKhachHang);
            
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
        private void StyleDataGridView(DataGridView dgv)
        {
            // reset theme Guna tránh override style
            if (dgv is Guna.UI2.WinForms.Guna2DataGridView gunaDgv)
            {
                gunaDgv.Theme =
                Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            }

            dgv.EnableHeadersVisualStyles = false;


            // HEADER STYLE
            dgv.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(55, 65, 81);

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
            Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
            new Font("Segoe UI", 10F, FontStyle.Bold);

            dgv.ColumnHeadersDefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersHeight = 45;

            dgv.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // ROW STYLE
            dgv.DefaultCellStyle.BackColor =
            Color.FromArgb(249, 250, 251);

            dgv.DefaultCellStyle.ForeColor =
            Color.FromArgb(31, 41, 55);

            dgv.DefaultCellStyle.Font =
            new Font("Segoe UI", 10F);

            dgv.RowTemplate.Height = 40;


            // ALTERNATE ROW COLOR
            dgv.AlternatingRowsDefaultCellStyle.BackColor =
            Color.FromArgb(243, 244, 246);


            // SELECTED ROW STYLE
            dgv.DefaultCellStyle.SelectionBackColor =
            Color.FromArgb(107, 114, 128);

            dgv.DefaultCellStyle.SelectionForeColor =
            Color.White;


            // GRID STYLE
            dgv.GridColor =
            Color.FromArgb(229, 231, 235);

            dgv.BorderStyle = BorderStyle.None;

            dgv.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;


            // AUTO SIZE FIX lỗi chữ chồng
            dgv.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            dgv.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.None;


            // TABLE BEHAVIOR
            dgv.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dgv.MultiSelect = false;

            dgv.AllowUserToAddRows = false;

            dgv.AllowUserToResizeRows = false;

            dgv.RowHeadersVisible = false;

            dgv.BackgroundColor = Color.White;


            // FIX FONT TOÀN BỘ COLUMN (tránh header dính chữ)
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

                col.HeaderCell.Style.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
            }
        }
        private void StyleButtonsLoaiPhong()
        {
            guna2Button_sua.BorderRadius = 14;
            guna2Button_luu.BorderRadius = 14;
            guna2Button_xoa.BorderRadius = 14;
            guna2Button_huy.BorderRadius = 14;


            guna2Button_sua.FillColor =
            Color.FromArgb(75, 85, 99);

            guna2Button_luu.FillColor =
            Color.FromArgb(107, 114, 128);

            guna2Button_xoa.FillColor =
            Color.FromArgb(156, 163, 175);

            guna2Button_huy.FillColor =
            Color.FromArgb(209, 213, 219);


            guna2Button_sua.ForeColor = Color.White;
            guna2Button_luu.ForeColor = Color.White;
            guna2Button_xoa.ForeColor = Color.White;
            guna2Button_huy.ForeColor = Color.Black;


            guna2Button_sua.Font =
            new Font("Segoe UI", 10, FontStyle.Bold);

            guna2Button_luu.Font =
            new Font("Segoe UI", 10, FontStyle.Bold);

            guna2Button_xoa.Font =
            new Font("Segoe UI", 10, FontStyle.Bold);

            guna2Button_huy.Font =
            new Font("Segoe UI", 10, FontStyle.Bold);


            guna2Button_sua.Animated = true;
            guna2Button_luu.Animated = true;
            guna2Button_xoa.Animated = true;
            guna2Button_huy.Animated = true;
        }

        private void btnPhuthu_Click(object sender, EventArgs e)
        {
            Form_them_phu_thu f = new Form_them_phu_thu();

            f.Show();
        }
    }
}