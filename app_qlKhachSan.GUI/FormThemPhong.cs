using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.IO;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class FormThemPhong : Form
    {
        PhongBUS phongBUS = new PhongBUS();
        LoaiPhongBUS loaiPhongBUS = new LoaiPhongBUS();
        AnhPhongBUS anhBUS = new AnhPhongBUS();

        // biến lưu đường dẫn ảnh
        string duongDanAnh = "";

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

        // ================= CHỌN ẢNH =================
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string folder = Application.StartupPath + "\\Images\\Phong\\";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName = Path.GetFileName(ofd.FileName);

                string newPath = folder + fileName;

                File.Copy(ofd.FileName, newPath, true);

                duongDanAnh = newPath;

                picPhong.ImageLocation = newPath;
            }
        }

        // ================= LƯU =================
        private void btnLuu_Click(object sender, EventArgs e)
        {
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
                    // lưu ảnh phòng vào bảng AnhPhong
                    if (!string.IsNullOrEmpty(duongDanAnh))
                    {
                        AnhPhongDTO anh = new AnhPhongDTO()
                        {
                            MaLoaiPhong = cbLoaiPhong.SelectedValue.ToString(),
                            DuongDanAnh = duongDanAnh,
                            MoTa = "Ảnh phòng"
                        };

                        anhBUS.InsertAnhPhong(anh);
                    }

                    MessageBox.Show("Thêm phòng thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm phòng thất bại");
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