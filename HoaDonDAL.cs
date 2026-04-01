using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_qlKhachSan.DTO;

namespace app_qlKhachSan.DAL
{
    public class HoaDonDAL
    {
        private string connectionString = @"Data Source=LAPTOP-URQTM56V\SQLEXPRESS;Initial Catalog=HotelManager;Integrated Security=True";
        SqlConnection conn;

        public int InsertHoaDon(HoaDonDTO hd)
        {
            string query = @"INSERT INTO HoaDon
            (MaDatPhong, MaKhuyenMai, TienPhong, TienDichVu, TienPhuThu, GiamGia, VAT, TongTien, TrangThaiThanhToan, NgayTao)
            VALUES
            (@MaDatPhong, @MaKhuyenMai, @TienPhong, @TienDichVu, @TienPhuThu, @GiamGia, @VAT, @TongTien, @TrangThaiThanhToan, @NgayTao)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@MaDatPhong", hd.MaDatPhong);
            cmd.Parameters.AddWithValue("@MaKhuyenMai", (object)hd.MaKhuyenMai ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@TienPhong", hd.TienPhong);
            cmd.Parameters.AddWithValue("@TienDichVu", hd.TienDichVu);
            cmd.Parameters.AddWithValue("@TienPhuThu", hd.TienPhuThu);
            cmd.Parameters.AddWithValue("@GiamGia", hd.GiamGia);
            cmd.Parameters.AddWithValue("@VAT", hd.VAT);
            cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
            cmd.Parameters.AddWithValue("@TrangThaiThanhToan", hd.TrangThaiThanhToan);
            cmd.Parameters.AddWithValue("@NgayTao", hd.NgayTao);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable GetAllHoaDon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM HoaDon";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int UpdateTrangThai(long maHoaDon, string trangThai)
        {
            string query = "UPDATE HoaDon SET TrangThaiThanhToan = @TrangThai WHERE MaHoaDon = @MaHoaDon";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TrangThai", trangThai);
            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public bool UpdateHoaDon(int maHD, decimal tongTien)
        {
            string sql = "UPDATE HoaDon SET TongTien = @TongTien WHERE MaHoaDon = @MaHD";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TongTien", tongTien);
            cmd.Parameters.AddWithValue("@MaHD", maHD);

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public HoaDonDAL()
        {
            conn = new SqlConnection(connectionString);
        }
    }
}
