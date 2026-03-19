using app_qlKhachSan.DTO;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_Them_Loai_Phong : Form
    {
        LoaiPhongBUS bus = new LoaiPhongBUS();

        public Form_Them_Loai_Phong()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // ===== VALIDATE =====
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text) ||
                string.IsNullOrWhiteSpace(txtGiaTheoNgay.Text) ||
                string.IsNullOrWhiteSpace(txtGiaTheoGio.Text) ||
                string.IsNullOrWhiteSpace(txtSoNguoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                // 👉 parse an toàn hơn
                decimal giaNgay = decimal.Parse(txtGiaTheoNgay.Text, CultureInfo.InvariantCulture);
                decimal giaGio = decimal.Parse(txtGiaTheoGio.Text, CultureInfo.InvariantCulture);
                int soNguoi = int.Parse(txtSoNguoi.Text);

                LoaiPhongDTO lp = new LoaiPhongDTO()
                {
                    TenLoaiPhong = txtTenLoai.Text.Trim(),
                    GiaTheoNgay = giaNgay,
                    GiaTheoGio = giaGio,
                    SoNguoiToiDa = soNguoi,
                    MoTa = txtMoTa.Text.Trim()
                };

                bool result = bus.InsertLoaiPhong(lp);

                if (result)
                {
                    MessageBox.Show("Thêm loại phòng thành công");
                    this.DialogResult = DialogResult.OK; // 🔥 xịn hơn
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá hoặc số người phải là số hợp lệ!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // 🔥 chuyên nghiệp
            this.Close();
        }
    }
}