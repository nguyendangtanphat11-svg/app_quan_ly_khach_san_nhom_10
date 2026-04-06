using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_them_dich_vu : Form
    {
        DichVuBUS dichVuBUS =
        new DichVuBUS();

        public Form_them_dich_vu()
        {
            InitializeComponent();
        }


        private void Form_them_dich_vu_Load(object sender, EventArgs e)
        {
            chkTrangThai.Checked = true;

            txtTenDV.Focus();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDV.Text))
            {
                MessageBox.Show("Nhập tên dịch vụ!");
                return;
            }

            if (!decimal.TryParse(txtGia.Text, out decimal gia))
            {
                MessageBox.Show("Giá phải là số!");
                return;
            }


            DichVuDTO dv =
            new DichVuDTO();

            dv.TenDichVu =
            txtTenDV.Text.Trim();

            dv.DonGia =
            gia;

            dv.TrangThai =
            chkTrangThai.Checked;


            int kq =
            dichVuBUS.Insert(dv);


            if (kq > 0)
            {
                MessageBox.Show("Thêm dịch vụ thành công!");

                DialogResult =
                DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}