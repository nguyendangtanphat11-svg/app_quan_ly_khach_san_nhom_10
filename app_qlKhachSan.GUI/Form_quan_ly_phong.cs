using app_qlKhachSan.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_quan_ly_phong : Form
    {
        PhongBUS bus = new PhongBUS();
        LoaiPhongBUS loaiPhongBUS = new LoaiPhongBUS();
        AnhPhongBUS anhBUS = new AnhPhongBUS();

        string maPhongDangChon = "";
        bool dangSua = false;


        public Form_quan_ly_phong()
        {
            InitializeComponent();
        }

        private void Form_quan_ly_phong_Load(object sender, EventArgs e)
        {
            // ===== LOAD DATA =====
            LoadPhong();
            LoadLoaiPhong();

            SetEditMode(false);

            txtGia.ReadOnly = true;
            txtGia.BackColor = Color.LightGray;

            cb_loai_phong.SelectedIndexChanged += cb_loai_phong_SelectedIndexChanged;


            // ===== RESET THEME GUNA =====
            tabel_phong.Theme =
            Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;

            tabel_phong.EnableHeadersVisualStyles = false;


            // ===== HEADER STYLE =====
            tabel_phong.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(55, 65, 81);

            tabel_phong.ColumnHeadersDefaultCellStyle.ForeColor =
            Color.White;

            tabel_phong.ColumnHeadersDefaultCellStyle.Font =
            new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);

            tabel_phong.ColumnHeadersDefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;

            tabel_phong.ColumnHeadersDefaultCellStyle.SelectionBackColor =
            Color.FromArgb(55, 65, 81);

            tabel_phong.ColumnHeadersHeight = 45;


            // ===== ROW STYLE =====
            tabel_phong.DefaultCellStyle.BackColor =
            Color.FromArgb(249, 250, 251);

            tabel_phong.DefaultCellStyle.ForeColor =
            Color.FromArgb(31, 41, 55);

            tabel_phong.DefaultCellStyle.Font =
            new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            tabel_phong.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleLeft;

            tabel_phong.RowTemplate.Height = 45;


            // ===== ALTERNATE ROW COLOR =====
            tabel_phong.AlternatingRowsDefaultCellStyle.BackColor =
            Color.FromArgb(243, 244, 246);


            // ===== SELECTED ROW STYLE =====
            tabel_phong.DefaultCellStyle.SelectionBackColor =
            Color.FromArgb(107, 114, 128);

            tabel_phong.DefaultCellStyle.SelectionForeColor =
            Color.White;


            // ===== GRID STYLE =====
            tabel_phong.GridColor =
            Color.FromArgb(229, 231, 235);

            tabel_phong.BorderStyle = BorderStyle.None;

            tabel_phong.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;


            // ===== COLUMN SIZE =====
            tabel_phong.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            tabel_phong.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.None;


            // ===== TABLE BEHAVIOR =====
            tabel_phong.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            tabel_phong.MultiSelect = false;

            tabel_phong.AllowUserToAddRows = false;

            tabel_phong.AllowUserToResizeRows = false;

            tabel_phong.RowHeadersVisible = false;

            tabel_phong.BackgroundColor = Color.White;


            // ===== FIX FONT ALL COLUMNS (TRÁNH CHỮ TO NHỎ KHÁC NHAU) =====
            foreach (DataGridViewColumn col in tabel_phong.Columns)
            {
                col.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Regular);
            }


            // ===== FORMAT GIÁ =====
            if (tabel_phong.Columns.Contains("GiaTheoNgay"))
            {
                tabel_phong.Columns["GiaTheoNgay"]
                .DefaultCellStyle.Format = "0";
            }


            // ===== BUTTON STYLE =====
            guna2Button_sua.BorderRadius = 14;
            guna2Button_luu.BorderRadius = 14;
            guna2Button_xoa.BorderRadius = 14;
            guna2Button_huy.BorderRadius = 14;

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


            // ===== BUTTON COLOR =====
            guna2Button_sua.FillColor =
            Color.FromArgb(75, 85, 99);

            guna2Button_sua.ForeColor = Color.White;

            guna2Button_sua.HoverState.FillColor =
            Color.FromArgb(55, 65, 81);


            guna2Button_luu.FillColor =
            Color.FromArgb(107, 114, 128);

            guna2Button_luu.ForeColor = Color.White;

            guna2Button_luu.HoverState.FillColor =
            Color.FromArgb(75, 85, 99);


            guna2Button_xoa.FillColor =
            Color.FromArgb(156, 163, 175);

            guna2Button_xoa.ForeColor = Color.White;

            guna2Button_xoa.HoverState.FillColor =
            Color.FromArgb(107, 114, 128);


            guna2Button_huy.FillColor =
            Color.FromArgb(209, 213, 219);

            guna2Button_huy.ForeColor = Color.Black;

            guna2Button_huy.HoverState.FillColor =
            Color.FromArgb(156, 163, 175);


            // ===== REMOVE SHADOW =====
            guna2Button_sua.ShadowDecoration.Enabled = false;
            guna2Button_luu.ShadowDecoration.Enabled = false;
            guna2Button_xoa.ShadowDecoration.Enabled = false;
            guna2Button_huy.ShadowDecoration.Enabled = false;


            // ===== TEXTBOX STYLE =====
            txtMaPhong.FillColor =
            Color.FromArgb(243, 244, 246);

            txtSoPhong.FillColor =
            Color.FromArgb(243, 244, 246);


            // ===== AUTO SELECT FIRST ROW =====
            if (tabel_phong.Rows.Count > 0)
            {
                tabel_phong.Rows[0].Selected = true;

                tabel_phong_CellClick(
                tabel_phong,
                new DataGridViewCellEventArgs(0, 0));
            }
            tabel_phong.CellFormatting += tabel_phong_CellFormatting;
            Font tableFont =
            new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // áp dụng cho toàn bảng
            tabel_phong.Font = tableFont;

            // áp dụng cho header
            tabel_phong.ColumnHeadersDefaultCellStyle.Font = tableFont;

            // áp dụng cho tất cả column
            foreach (DataGridViewColumn col in tabel_phong.Columns)
            {
                col.DefaultCellStyle.Font = tableFont;
            }
            tabel_phong.RowTemplate.Height = 40;
            tabel_phong.ColumnHeadersHeight = 40;
        }
        

        // ================= LOAD =================

        void LoadPhong()
        {
            tabel_phong.DataSource = bus.GetPhong();
        }

        void LoadLoaiPhong()
        {
            cb_loai_phong.DataSource = loaiPhongBUS.GetLoaiPhong();
            cb_loai_phong.DisplayMember = "TenLoaiPhong";
            cb_loai_phong.ValueMember = "MaLoaiPhong";
        }
        private void tabel_phong_CellFormatting(
object sender,
DataGridViewCellFormattingEventArgs e)
        {
            if (tabel_phong.Columns[e.ColumnIndex].Name == "TrangThai"
                && e.Value != null)
            {
                string trangThai =
                e.Value.ToString().Trim().ToUpper();

                if (trangThai == "TRỐNG")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);
                }

                else if (trangThai == "CẦN DỌN")
                {
                    e.CellStyle.ForeColor = Color.DarkOrange;
                    e.CellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);
                }

                else if (trangThai == "ĐANG Ở")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }

        // ================= AUTO GIÁ =================

        private void cb_loai_phong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_loai_phong.SelectedItem == null) return;

            DataRowView row = cb_loai_phong.SelectedItem as DataRowView;

            if (row != null)
            {
                txtGia.Text = row["GiaTheoNgay"].ToString();
            }
        }

        // ================= SEARCH =================

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                LoadPhong();
            else
                tabel_phong.DataSource = bus.TimPhong(txtTimKiem.Text);
        }

        // ================= CLICK TABLE =================

        private void tabel_phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = tabel_phong.Rows[e.RowIndex];

            maPhongDangChon = row.Cells["MaPhong"].Value.ToString();

            txtMaPhong.Text = maPhongDangChon;
            txtSoPhong.Text = row.Cells["SoPhong"].Value.ToString();
            cb_loai_phong.Text = row.Cells["TenLoaiPhong"].Value.ToString();
            txtGia.Text = row.Cells["GiaTheoNgay"].Value.ToString();
            cb_trang_thai.Text = row.Cells["TrangThai"].Value.ToString();

            // ===== load ảnh phòng =====

            string tenLoaiPhong = row.Cells["TenLoaiPhong"].Value.ToString();

            string duongDanAnh = anhBUS.GetAnhTheoTenLoaiPhong(tenLoaiPhong);

            if (!string.IsNullOrEmpty(duongDanAnh))
            {
                picPhong.ImageLocation = duongDanAnh;
            }
            else
            {
                picPhong.Image = null;
            }
        }

        // ================= THÊM =================

        private void guna2PictureBox_them_phong_Click(object sender, EventArgs e)
        {
            FormThemPhong f = new FormThemPhong();

            if (f.ShowDialog() == DialogResult.OK)
                LoadPhong();
        }

        // ================= XÓA =================

        private void guna2Button_xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maPhongDangChon))
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                if (bus.DeletePhong(int.Parse(maPhongDangChon)))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadPhong();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        // ================= SỬA =================

        private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maPhongDangChon))
            {
                MessageBox.Show("Chọn phòng trước!");
                return;
            }

            dangSua = true;
            SetEditMode(true);
        }

        // ================= LƯU =================

        private void guna2Button_luu_Click(object sender, EventArgs e)
        {
            if (!dangSua) return;

            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Nhập số phòng!");
                return;
            }

            try
            {
                bool result = bus.UpdatePhong(
                    maPhongDangChon,
                    txtSoPhong.Text,
                    cb_loai_phong.SelectedValue.ToString(),
                    cb_trang_thai.Text
                );

                if (result)
                {
                    MessageBox.Show("Cập nhật thành công!");

                    LoadPhong();

                    SetEditMode(false);

                    dangSua = false;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= HỦY =================

        private void guna2Button_huy_Click(object sender, EventArgs e)
        {
            dangSua = false;
            SetEditMode(false);
            ClearData();
        }

        // ================= UI =================

        void SetEditMode(bool edit)
        {
            txtSoPhong.Enabled = edit;
            cb_loai_phong.Enabled = edit;
            cb_trang_thai.Enabled = edit;
            txtGia.Enabled = edit;
            txtMaPhong.Enabled =edit;

            guna2Button_luu.Enabled = edit;
            guna2Button_huy.Enabled = edit;

            guna2Button_sua.Enabled = !edit;
            guna2Button_xoa.Enabled = !edit;
        }

        void ClearData()
        {
            txtMaPhong.Clear();
            txtSoPhong.Clear();
            txtGia.Clear();

            cb_loai_phong.SelectedIndex = -1;
            cb_trang_thai.SelectedIndex = -1;

            maPhongDangChon = "";
        }

        // ================= FORM LOẠI PHÒNG =================

        private void guna2PictureBox_Role_Phong_Click(object sender, EventArgs e)
        {
            FormLoaiPhong f = new FormLoaiPhong();
            f.ShowDialog();

            LoadLoaiPhong();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Form_Them_Loai_Phong f = new Form_Them_Loai_Phong();

            if (f.ShowDialog() == DialogResult.OK)
                LoadLoaiPhong();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!dangSua)
            {
                LoadPhong();
            }

        }

        private void tabel_phong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabel_phong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}