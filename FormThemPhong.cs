using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    

    public partial class FormThemPhong : Form
    {
        private string CONNECTION_STRING = @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True;";
        public FormThemPhong()
        {
            InitializeComponent();
        }

        private void FormThemPhong_Load(object sender, EventArgs e)
        {
            LoadLoaiPhong();
        }
        void LoadLoaiPhong()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string query = "SELECT MaLoaiPhong, TenLoaiPhong FROM LoaiPhong";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbLoaiPhong.DataSource = dt;
                cbLoaiPhong.DisplayMember = "TenLoaiPhong";
                cbLoaiPhong.ValueMember = "MaLoaiPhong";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text == "" || txtGia.Text == "" || cbLoaiPhong.Text == "" || cbTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                string query = @"INSERT INTO Phong
                (SoPhong, MaLoaiPhong, TrangThai)
                VALUES
                (@SoPhong, @MaLoaiPhong, @TrangThai)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@SoPhong", txtSoPhong.Text);
                cmd.Parameters.AddWithValue("@MaLoaiPhong", cbLoaiPhong.SelectedValue);
                cmd.Parameters.AddWithValue("@TrangThai", cbTrangThai.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm phòng thành công");

            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
