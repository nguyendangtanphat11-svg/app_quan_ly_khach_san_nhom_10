using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app_qlKhachSan.DAL;

namespace app_qlKhachSan
{
    public partial class From_HoaDon : Form
    {
        HoaDonDAL hoaDonDAL = new HoaDonDAL();
        public From_HoaDon()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dataGridView1.DataSource = hoaDonDAL.GetAllHoaDon();
        }
        private void From_HoaDon_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtMaHD.Text = dataGridView1.CurrentRow.Cells["MaHoaDon"].Value.ToString();
                txtTongTien.Text = dataGridView1.CurrentRow.Cells["TongTien"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int maHD = int.Parse(txtMaHD.Text);
            decimal tongTien = decimal.Parse(txtTongTien.Text);

            bool result = hoaDonDAL.UpdateHoaDon(maHD, tongTien);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công");
                LoadData(); 
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int maHD = int.Parse(txtMaHD.Text);
            decimal tongTien = decimal.Parse(txtTongTien.Text);

            bool result = hoaDonDAL.UpdateHoaDon(maHD, tongTien);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công");
                LoadData(); 
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }
    }
}
