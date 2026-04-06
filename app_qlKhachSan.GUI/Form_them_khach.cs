using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_them_khach : Form
    {
        KhachHangBUS bus = new KhachHangBUS();

        LoaiKhachHangBUS loaiBUS = new LoaiKhachHangBUS();


        public Form_them_khach()
        {
            InitializeComponent();
        }


        private void Form_them_khach_Load(object sender, EventArgs e)
        {
            cboLoaiKH.DataSource = loaiBUS.GetDanhSach();

            cboLoaiKH.DisplayMember = "TenLoaiKH";

            cboLoaiKH.ValueMember = "MaLoaiKH";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();

       

            kh.MaLoaiKH =
                Convert.ToInt32(cboLoaiKH.SelectedValue);

            kh.HoTen = txtHoTen.Text;

            kh.CCCD_Passport = txtCCCD.Text;

            kh.SDT = txtSDT.Text;

            kh.Email = txtEmail.Text;

            kh.DiaChi = txtDiaChi.Text;

            kh.QuocTich = txtQuocTich.Text;

            kh.NgayTao = DateTime.Now;


            if (bus.Them(kh))
            {
                MessageBox.Show("Thêm khách thành công 🎉");

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm thất bại ❌");
            }
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}