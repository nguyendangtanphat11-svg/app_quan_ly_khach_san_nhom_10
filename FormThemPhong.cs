using app_qlKhachSan.DTO;
using System;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class FormThemPhong : Form
    {
        PhongBUS phongBUS = new PhongBUS();
        LoaiPhongBUS loaiPhongBUS = new LoaiPhongBUS();

        public FormThemPhong()
        {
            InitializeComponent();
        }

        private void FormThemPhong_Load(object sender, EventArgs e)
        {
            LoadLoaiPhong();

            // gợi ý trạng thái mặc định
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Trống");
            cbTrangThai.Items.Add("Đang thuê");
            cbTrangThai.SelectedIndex = 0;
        }

        // ================= LOAD LOẠI PHÒNG =================
        void LoadLoaiPhong()
        {
            try
            {
                cbLoaiPhong.DataSource = loaiPhongBUS.GetLoaiPhong();
                cbLoaiPhong.DisplayMember = "TenLoaiPhong";
                cbLoaiPhong.ValueMember = "MaLoaiPhong";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load loại phòng: " + ex.Message);
            }
        }

        // ================= LƯU =================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate trước
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập số phòng");
                txtSoPhong.Focus();
                return;
            }

            if (cbLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng");
                return;
            }

            if (string.IsNullOrWhiteSpace(cbTrangThai.Text))
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
                return;
            }

            try
            {
                PhongDTO p = new PhongDTO()
                {
                    SoPhong = txtSoPhong.Text.Trim(),
                    MaLoaiPhong = cbLoaiPhong.SelectedValue.ToString(),
                    TrangThai = cbTrangThai.Text.Trim()
                };

                bool result = phongBUS.InsertPhong(p);

                if (result)
                {
                    MessageBox.Show("Thêm phòng thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // ================= HỦY =================
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}