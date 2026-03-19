using System.Data;
using System.Data.SqlClient;
using app_qlKhachSan.DTO;

public class LoaiPhongDAL
{
    private string connectionString =
        @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True";

    public DataTable GetLoaiPhong()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"SELECT * FROM LoaiPhong";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public bool UpdateLoaiPhong(LoaiPhongDTO lp)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = @"UPDATE LoaiPhong
                             SET TenLoaiPhong=@ten,
                                 GiaTheoNgay=@ngay,
                                 GiaTheoGio=@gio,
                                 SoNguoiToiDa=@songuoi,
                                 MoTa=@mota
                             WHERE MaLoaiPhong=@ma";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ma", lp.MaLoaiPhong);
            cmd.Parameters.AddWithValue("@ten", lp.TenLoaiPhong);
            cmd.Parameters.AddWithValue("@ngay", lp.GiaTheoNgay);
            cmd.Parameters.AddWithValue("@gio", lp.GiaTheoGio);
            cmd.Parameters.AddWithValue("@songuoi", lp.SoNguoiToiDa);
            cmd.Parameters.AddWithValue("@mota", lp.MoTa);

            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public bool DeleteLoaiPhong(string ma)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "DELETE FROM LoaiPhong WHERE MaLoaiPhong=@ma";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ma", ma);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
    public bool InsertLoaiPhong(LoaiPhongDTO lp)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = @"INSERT INTO LoaiPhong
                        (TenLoaiPhong, GiaTheoNgay, GiaTheoGio, SoNguoiToiDa, MoTa)
                        VALUES (@ten, @ngay, @gio, @songuoi, @mota)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ten", lp.TenLoaiPhong);
            cmd.Parameters.AddWithValue("@ngay", lp.GiaTheoNgay);
            cmd.Parameters.AddWithValue("@gio", lp.GiaTheoGio);
            cmd.Parameters.AddWithValue("@songuoi", lp.SoNguoiToiDa);
            cmd.Parameters.AddWithValue("@mota", lp.MoTa);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}