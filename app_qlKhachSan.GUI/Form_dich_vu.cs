using app_qlKhachSan.BUS;
using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class Form_dich_vu : Form
    {
        DichVuBUS dichVuBUS = new DichVuBUS();

        SuDungDichVuBUS suDungBUS =
        new SuDungDichVuBUS();

        string maDichVuDangChon = "";
        long maDatPhong = 0;

        public Form_dich_vu()
        {
            InitializeComponent();
        }
        public Form_dich_vu(long maDatPhong)
        {
            InitializeComponent();

            this.maDatPhong = maDatPhong;
        }


        // ================= LOAD FORM =================

        private void Form_dich_vu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            LoadDanhSachDichVu();

            KhoaThongTin();
        }


        // ================= LOAD DATA =================

        void LoadDanhSachDichVu()
        {
            dgvDichVu.DataSource =
            dichVuBUS.GetDanhSach();
        }


        void LoadLichSuSuDung()
        {
            if (maDichVuDangChon == "")
                return;

            dgvLichSu.DataSource =
            suDungBUS.GetByMaDichVu(
            maDichVuDangChon);
        }


        // ================= CLICK GRID =================

        private void dgvDichVu_CellClick(
        object sender,
        DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
            dgvDichVu.Rows[e.RowIndex];

            maDichVuDangChon =
            row.Cells["MaDichVu"].Value.ToString();

            txtMaDV.Text =
            maDichVuDangChon;

            txtTenDV.Text =
            row.Cells["TenDichVu"].Value.ToString();

            txtGia.Text =
            row.Cells["DonGia"].Value.ToString();


            // xử lý checkbox trạng thái

            object trangThaiValue =
row.Cells["TrangThai"].Value;

            if (trangThaiValue != DBNull.Value)
            {
                chkTrangThai.Checked =
                Convert.ToBoolean(trangThaiValue);
            }
            else
            {
                chkTrangThai.Checked = false;
            }


            LoadLichSuSuDung();

            KhoaThongTin();
        }


        // ================= KHÓA PANEL =================

        void KhoaThongTin()
        {
            txtMaDV.Enabled = false;
            txtTenDV.Enabled = false;
            txtGia.Enabled = false;
            chkTrangThai.Enabled = false;
        }


        void MoKhoaThongTin()
        {
            txtTenDV.Enabled = true;
            txtGia.Enabled = true;
            chkTrangThai.Enabled = true;
        }


        // ================= NÚT SỬA =================

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDichVuDangChon == "")
                return;

            MoKhoaThongTin();
        }


        // ================= NÚT LƯU =================

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (maDichVuDangChon == "")
                return;

            DichVuDTO dv =
            new DichVuDTO();

            dv.MaDichVu =
            txtMaDV.Text;

            dv.TenDichVu =
            txtTenDV.Text;

            dv.DonGia =
            decimal.Parse(txtGia.Text);


            // chuyển checkbox -> text DB

            dv.TrangThai =
 chkTrangThai.Checked;


            dichVuBUS.Update(dv);

            MessageBox.Show(
            "Cập nhật dịch vụ thành công!");

            LoadDanhSachDichVu();

            KhoaThongTin();
        }


        // ================= NÚT XÓA =================

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDichVuDangChon == "")
                return;

            DialogResult rs =
            MessageBox.Show(
            "Bạn có chắc muốn xóa?",
            "Xác nhận",
            MessageBoxButtons.YesNo);

            if (rs != DialogResult.Yes)
                return;


            // xóa lịch sử sử dụng trước

            suDungBUS.DeleteByMaDichVu(
            maDichVuDangChon);


            // xóa dịch vụ

            dichVuBUS.Delete(
            maDichVuDangChon);


            MessageBox.Show(
            "Xóa dịch vụ thành công!");

            LoadDanhSachDichVu();


            txtMaDV.Clear();
            txtTenDV.Clear();
            txtGia.Clear();

            chkTrangThai.Checked = false;

            maDichVuDangChon = "";
        }


        // ================= NÚT HỦY =================

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtGia.Clear();

            chkTrangThai.Checked = false;

            maDichVuDangChon = "";

            KhoaThongTin();
        }


        private void dgvDichVu_CellContentClick(
        object sender,
        DataGridViewCellEventArgs e)
        {

        }


        private void chkTrangThai_CheckedChanged(
        object sender,
        EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Form_them_dich_vu f =
   new Form_them_dich_vu();

            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachDichVu();
            }
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            if (maDichVuDangChon == "")
            {
                MessageBox.Show("Chọn dịch vụ trước!");
                return;
            }

            Form_them_su_dung_dich_vu f =
            new Form_them_su_dung_dich_vu(
            maDichVuDangChon);

            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadLichSuSuDung(); // reload tại đây mới đúng
            }
        }

        
    }
}