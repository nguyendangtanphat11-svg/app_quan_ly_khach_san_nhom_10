using app_qlKhachSan.BUS;
using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_them_su_dung_dich_vu : Form
    {
        SuDungDichVuBUS suDungBUS =
        new SuDungDichVuBUS();

        DichVuBUS dichVuBUS =
        new DichVuBUS();

        DatPhongBUS datPhongBUS =
        new DatPhongBUS();

        string maDichVuDuocChon = "";


        // ================= CONSTRUCTOR =================

        public Form_them_su_dung_dich_vu()
        {
            InitializeComponent();
        }

        public Form_them_su_dung_dich_vu(string maDichVu)
        {
            InitializeComponent();

            maDichVuDuocChon = maDichVu;
        }


        // ================= LOAD FORM =================

        private void Form_them_su_dung_dich_vu_Load(
        object sender,
        EventArgs e)
        {
            LoadPhongDangO();

            LoadDanhSachDichVu();

            // auto chọn dịch vụ nếu được truyền từ form trước
            if (maDichVuDuocChon != "")
            {
                cbDichVu.SelectedValue =
                maDichVuDuocChon;
            }
        }


        // ================= LOAD PHÒNG ĐANG Ở =================

        void LoadPhongDangO()
        {
            cbMaDatPhong.DataSource =
            datPhongBUS.GetPhongDangO();

            cbMaDatPhong.DisplayMember =
            "MaDatPhong";

            cbMaDatPhong.ValueMember =
            "MaDatPhong";
        }


        // ================= LOAD DANH SÁCH DỊCH VỤ =================

        void LoadDanhSachDichVu()
        {
            cbDichVu.DataSource =
            dichVuBUS.GetDanhSach();

            cbDichVu.DisplayMember =
            "TenDichVu";

            cbDichVu.ValueMember =
            "MaDichVu";
        }


        // ================= NÚT THÊM =================

        private void btnThem_Click(
        object sender,
        EventArgs e)

        {
            if (cbMaDatPhong.SelectedValue == null)
            {
                MessageBox.Show("Chọn mã đặt phòng!");
                return;
            }

            if (cbDichVu.SelectedValue == null)
            {
                MessageBox.Show("Chọn dịch vụ!");
                return;
            }

            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                return;
            }


            SuDungDichVuDTO dv =
            new SuDungDichVuDTO();

            dv.MaDatPhong =
            cbMaDatPhong.SelectedValue.ToString();

            dv.MaDichVu =
            Convert.ToInt32(cbDichVu.SelectedValue);

            dv.SoLuong =
            (int)numSoLuong.Value;

            dv.ThoiGianSuDung =
            DateTime.Now;

            dv.GhiChu =
            txtGhiChu.Text;


            int kq =
            suDungBUS.Insert(dv);


            if (kq > 0)
            {
                MessageBox.Show("Thêm dịch vụ thành công!");

                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }


        }


        // ================= NÚT HỦY =================

        private void btnHuy_Click(
        object sender,
        EventArgs e)
        {
            Close();
        }
    }
}