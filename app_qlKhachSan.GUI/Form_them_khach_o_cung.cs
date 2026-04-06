using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_them_khach_o_cung : Form
    {
        string maDatPhong = "";

        DanhSachKhachOBUS khachOBUS =
        new DanhSachKhachOBUS();

        public Form_them_khach_o_cung(string maDP)
        {
            InitializeComponent();

            maDatPhong = maDP;

            this.Load += Form_them_khach_o_cung_Load;
        }


        // ================= LOAD FORM =================

        private void Form_them_khach_o_cung_Load(object sender, EventArgs e)
        {
            cbMaDatPhong.Items.Clear();

            cbMaDatPhong.Items.Add(maDatPhong);

            cbMaDatPhong.SelectedIndex = 0;

            cbMaDatPhong.Enabled = false;
        }


        // ================= NÚT LƯU =================

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenKhach =
            txtTenKhach.Text.Trim();

            string cccd =
            txtCCCD.Text.Trim();

            string quocTich =
            txtQuocTich.Text.Trim();


            if (tenKhach == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách!");
                return;
            }


            DanhSachKhachODTO ds =
            new DanhSachKhachODTO();

            ds.MaDatPhong = maDatPhong;
            ds.TenKhach = tenKhach;
            ds.CCCD = cccd;
            ds.QuocTich = quocTich;


            int kq = khachOBUS.Insert(ds);


            if (kq > 0)
            {
                MessageBox.Show("Thêm khách ở cùng thành công!");

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }


        // ================= NÚT HỦY =================

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}