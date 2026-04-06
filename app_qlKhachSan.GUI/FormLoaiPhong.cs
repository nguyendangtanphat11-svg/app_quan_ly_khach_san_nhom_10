using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class FormLoaiPhong : Form
    {
        LoaiPhongBUS bus = new LoaiPhongBUS();
        bool dangSua = false;

        public FormLoaiPhong()
        {
            InitializeComponent();
        }

        private void FormLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadLoaiPhong();
        }

        void LoadLoaiPhong()
        {
            try
            {
                dgvLoaiPhong.DataSource = bus.GetLoaiPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // CLICK TABLE
        private void dgvLoaiPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLoaiPhong.Rows[e.RowIndex];

            txtMaLoai.Text = row.Cells["MaLoaiPhong"].Value.ToString();
            txtTenLoai.Text = row.Cells["TenLoaiPhong"].Value.ToString();
            txtGiaTheoNgay.Text = row.Cells["GiaTheoNgay"].Value.ToString();
            txtGiaTheoGio.Text = row.Cells["GiaTheoGio"].Value.ToString();
            txtSoNguoi.Text = row.Cells["SoNguoiToiDa"].Value.ToString();
            txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
        }

        // LƯU (UPDATE)
        private void guna2Button_luu_Click(object sender,
EventArgs e)
        {
            try
            {
                LoaiPhongDTO lp =
                new LoaiPhongDTO()
                {
                    MaLoaiPhong = txtMaLoai.Text,
                    TenLoaiPhong = txtTenLoai.Text,
                    GiaTheoNgay = decimal.Parse(txtGiaTheoNgay.Text),
                    GiaTheoGio = decimal.Parse(txtGiaTheoGio.Text),
                    SoNguoiToiDa = int.Parse(txtSoNguoi.Text),
                    MoTa = txtMoTa.Text
                };

                bool result = bus.UpdateLoaiPhong(lp);

                if (result)
                {
                    // cập nhật bảng BangGiaPhong
                    BangGiaPhongBUS bangGiaBUS =
                    new BangGiaPhongBUS();

                    bangGiaBUS.InsertGiaMoi(
                        lp.MaLoaiPhong,
                        lp.GiaTheoNgay,
                        "Cập nhật từ Form Loại Phòng"
                    );

                    MessageBox.Show("Cập nhật thành công");

                    LoadLoaiPhong();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // XÓA
        private void guna2Button_xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Chọn loại phòng trước!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    bool result = bus.DeleteLoaiPhong(txtMaLoai.Text);

                    if (result)
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadLoaiPhong();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Chọn loại phòng trước!");
                return;
            }

            dangSua = true;
            SetEditMode(true);

        }

        private void guna2Button_huy_Click(object sender, EventArgs e)
        {

            this.Close();

        }


        void SetEditMode(bool edit)
        {
            txtTenLoai.ReadOnly = !edit;
            txtGiaTheoNgay.ReadOnly = !edit;
            txtGiaTheoGio.ReadOnly = !edit;
            txtSoNguoi.ReadOnly = !edit;
            txtMoTa.ReadOnly = !edit;

         
            txtTenLoai.BackColor = edit ? Color.White : Color.LightGray;
            txtGiaTheoNgay.BackColor = edit ? Color.White : Color.LightGray;
            txtGiaTheoGio.BackColor = edit ? Color.White : Color.LightGray;
            txtSoNguoi.BackColor = edit ? Color.White : Color.LightGray;
            txtMoTa.BackColor = edit ? Color.White : Color.LightGray;
        }


    }
}