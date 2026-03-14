using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan
{

    public partial class Form_quan_ly_phong : Form
    {
        private string CONNECTION_STRING = @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True;";
        string maPhongDangChon = "";
        bool dangSua = false;

        public Form_quan_ly_phong()
        {
            InitializeComponent();

        }
      

        private void Form_quan_ly_phong_Load(object sender, EventArgs e)
        {
            LoadPhong();
            txt_so_phong.Visible = false;
            txt_gia.Visible = false;
     
            cb_loai_phong.Visible = false;
            cb_trang_thai.Visible = false;

        }
        void LoadPhong()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string query = @"SELECT 
                        p.MaPhong,
                        p.SoPhong,
                        lp.TenLoaiPhong,
                        lp.GiaTheoNgay,
                        p.TrangThai,
                        p.GhiChu
                        FROM Phong p
                        JOIN LoaiPhong lp 
                        ON p.MaLoaiPhong = lp.MaLoaiPhong";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                tabel_phong.DataSource = dt;

            }
        }
        void TimPhong(string keyword)
        {
            if (keyword == "")
            {
                LoadPhong();
                return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string query = @"SELECT 
                p.MaPhong,
                p.SoPhong,
                lp.TenLoaiPhong,
                lp.GiaTheoNgay,
                p.TrangThai
                FROM Phong p
                JOIN LoaiPhong lp
                ON p.MaLoaiPhong = lp.MaLoaiPhong
                WHERE p.SoPhong LIKE @kw
                OR lp.TenLoaiPhong LIKE @kw";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                tabel_phong.DataSource = dt;
            }
        }



        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_show_tim_kiem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void text_box_tim_kiem_Load(object sender, EventArgs e)
        {
          
        }

        private void text_box_tim_kiem_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_bieu_do_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            FormLoaiPhong f = new FormLoaiPhong();
            f.ShowDialog();

            LoadPhong();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            TimPhong(txtTimKiem.Text);
        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tabel_phong.Rows[e.RowIndex];

                maPhongDangChon = row.Cells["MaPhong"].Value.ToString();

                label_ma_phong.Text = maPhongDangChon;
                label_so_phong.Text = row.Cells["SoPhong"].Value.ToString();
                label_loai_phong.Text = row.Cells["TenLoaiPhong"].Value.ToString();
                label_gia.Text = row.Cells["GiaTheoNgay"].Value.ToString();
                label_trang_thai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            FormThemPhong f = new FormThemPhong();
            f.ShowDialog();

            LoadPhong(); 
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void label_dich_vu_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel14_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel15_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel16_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel17_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(maPhongDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa");
                return;
            }
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn sửa thông tin phòng này?", "Xác nhận sửa", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    string query = "DELETE FROM Phong WHERE MaPhong=@MaPhong";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhong", maPhongDangChon);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa phòng thành công");

                LoadPhong();
            }
        }

        private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            txt_so_phong.Visible = true;
            txt_gia.Visible = true;
            
            cb_loai_phong.Visible = true;
            cb_trang_thai.Visible = true;

            label_so_phong.Visible = false;
            label_loai_phong.Visible = false;
            label_gia.Visible = false;
            label_trang_thai.Visible = false;

            txt_so_phong.Text = label_so_phong.Text;
            txt_gia.Text = label_gia.Text;
        }

        private void guna2Button_luu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu rỗng
            if (string.IsNullOrWhiteSpace(txt_so_phong.Text) ||
                string.IsNullOrWhiteSpace(cb_trang_thai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string query = @"UPDATE Phong 
                         SET SoPhong=@SoPhong,
                             TrangThai=@TrangThai
                         WHERE MaPhong=@MaPhong";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@SoPhong", txt_so_phong.Text);
                cmd.Parameters.AddWithValue("@TrangThai", cb_trang_thai.Text);
                cmd.Parameters.AddWithValue("@MaPhong", label_ma_phong.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật thành công");

            LoadPhong();

            txt_so_phong.Visible = false;
            txt_gia.Visible = false;
            cb_loai_phong.Visible = false;
            cb_trang_thai.Visible = false;

            label_so_phong.Visible = true;
            label_loai_phong.Visible = true;
            label_gia.Visible = true;
            label_trang_thai.Visible = true;
        }

        private void guna2Button_huy_Click(object sender, EventArgs e)
        {
            dangSua = false;

            label_ma_phong.Text = "";
            label_so_phong.Text = "";
            label_loai_phong.Text = "";
            label_gia.Text = "";
            label_trang_thai.Text = "";

            maPhongDangChon = "";
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_so_phong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
