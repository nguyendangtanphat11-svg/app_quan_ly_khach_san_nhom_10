using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_them_phu_thu : Form
    {
        public Form_them_phu_thu()
        {
            InitializeComponent();
        }

        PhuThuBUS phuThuBUS = new PhuThuBUS();

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenPhuThu.Text == "")
            {
                MessageBox.Show("Nhập tên phụ thu!");
                return;
            }

            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Nhập đơn giá!");
                return;
            }

            PhuThuDTO pt = new PhuThuDTO();

            pt.TenPhuThu = txtTenPhuThu.Text;

            pt.DonGia = decimal.Parse(txtDonGia.Text);

            // chuyển Text -> bool
            pt.TrangThai =
          cbTrangThai.Text == "Hoạt động";

            if (phuThuBUS.Insert(pt))
            {
                MessageBox.Show("Thêm phụ thu thành công 🎉");

                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm phụ thu thất bại ❌");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form_them_phu_thu_Load(object sender, EventArgs e)
        {
            cbTrangThai.Items.Add("Hoạt động");
            cbTrangThai.Items.Add("Ngưng");

            cbTrangThai.SelectedIndex = 0;
        }
    }
}
