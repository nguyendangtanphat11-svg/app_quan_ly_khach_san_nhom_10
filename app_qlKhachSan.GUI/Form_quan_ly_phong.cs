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

        string maPhongDangChon = "";
        bool dangSua = false;

        public Form_quan_ly_phong()
        {
            InitializeComponent();
        }

        private void Form_quan_ly_phong_Load(object sender, EventArgs e)
        {
            LoadPhong();
            LoadLoaiPhong();
            SetEditMode(false);

            txt_gia.ReadOnly = true;
            txt_gia.BackColor = Color.LightGray;

            // chỉ add event 1 lần duy nhất
            cb_loai_phong.SelectedIndexChanged += cb_loai_phong_SelectedIndexChanged;
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

        // ================= AUTO GIÁ =================
        private void cb_loai_phong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_loai_phong.SelectedValue == null) return;

            DataRowView row = cb_loai_phong.SelectedItem as DataRowView;

            if (row != null)
            {
                txt_gia.Text = row["GiaTheoNgay"].ToString();
            }
        }

        // ================= SEARCH =================
        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                LoadPhong();
            else
                tabel_phong.DataSource = bus.TimPhong(txtTimKiem.Text);
        }

        // ================= CLICK TABLE =================
        private void tabel_phong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = tabel_phong.Rows[e.RowIndex];

            maPhongDangChon = row.Cells["MaPhong"].Value.ToString();

            label_ma_phong.Text = maPhongDangChon;
            label_so_phong.Text = row.Cells["SoPhong"].Value.ToString();
            label_loai_phong.Text = row.Cells["TenLoaiPhong"].Value.ToString();
            label_gia.Text = row.Cells["GiaTheoNgay"].Value.ToString();
            label_trang_thai.Text = row.Cells["TrangThai"].Value.ToString();
        }

        // ================= THÊM =================
        private void guna2PictureBox_them_phong_Click(object sender, EventArgs e)
        {
            FormThemPhong f = new FormThemPhong();

            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadPhong();
            }
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
                int maPhong =
                int.Parse(maPhongDangChon);

                if (bus.DeletePhong(maPhong))
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

            txt_so_phong.Text = label_so_phong.Text;
            cb_trang_thai.Text = label_trang_thai.Text;
            cb_loai_phong.Text = label_loai_phong.Text;
        }

        // ================= LƯU =================
        private void guna2Button_luu_Click(object sender, EventArgs e)
        {
            if (!dangSua) return;

            if (string.IsNullOrWhiteSpace(txt_so_phong.Text) ||
                string.IsNullOrWhiteSpace(cb_trang_thai.Text))
            {
                MessageBox.Show("Nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                bool result = bus.UpdatePhong(
                maPhongDangChon,
                txt_so_phong.Text,
                 cb_loai_phong.SelectedValue.ToString(), // 🔥 thêm dòng này
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
            txt_so_phong.Visible = edit;
            cb_trang_thai.Visible = edit;
            cb_loai_phong.Visible = edit;
            txt_gia.Visible = edit;

            label_so_phong.Visible = !edit;
            label_trang_thai.Visible = !edit;
            label_loai_phong.Visible = !edit;
            label_gia.Visible = !edit;
        }

        void ClearData()
        {
            label_ma_phong.Text = "";
            label_so_phong.Text = "";
            label_loai_phong.Text = "";
            label_gia.Text = "";
            label_trang_thai.Text = "";

            maPhongDangChon = "";
        }

        // ================= MỞ FORM LOẠI PHÒNG =================
        private void guna2PictureBox_Role_Phong_Click(object sender, EventArgs e)
        {
            FormLoaiPhong f = new FormLoaiPhong();
            f.ShowDialog();
            LoadLoaiPhong(); // reload lại combo
        }

        // ================= THÊM LOẠI PHÒNG =================
        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Form_Them_Loai_Phong f = new Form_Them_Loai_Phong();

            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadLoaiPhong();
            }
        }

        
    }
}