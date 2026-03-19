using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

public class PhongDAL
{
    private readonly string connectionString =
        @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True";

    // ================= KẾT NỐI TEST =================
    private SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    // ================= GET ALL =================
    public DataTable GetAllPhong()
    {
        using (SqlConnection conn = GetConnection())
        {
            try
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
                                 ON p.MaLoaiPhong = lp.MaLoaiPhong";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi SQL (Load phòng): " + ex.Message);
            }
        }
    }

    // ================= SEARCH =================
    public DataTable TimPhong(string keyword)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
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

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi SQL (Tìm phòng): " + ex.Message);
            }
        }
    }

    // ================= UPDATE =================
    public bool UpdatePhong(string maPhong, string soPhong, string maLoaiPhong, string trangThai)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = @"UPDATE Phong 
                         SET SoPhong=@SoPhong,
                             MaLoaiPhong=@MaLoaiPhong,
                             TrangThai=@TrangThai
                         WHERE MaPhong=@MaPhong";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@SoPhong", soPhong);
            cmd.Parameters.AddWithValue("@MaLoaiPhong", maLoaiPhong);
            cmd.Parameters.AddWithValue("@TrangThai", trangThai);
            cmd.Parameters.AddWithValue("@MaPhong", maPhong);

            return cmd.ExecuteNonQuery() > 0;
        }
    }

    // ================= DELETE =================
    public bool DeletePhong(string maPhong)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "DELETE FROM Phong WHERE MaPhong=@MaPhong";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaPhong", maPhong);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
    // ================= them phong =================
    public bool InsertPhong(PhongDTO p)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = @"INSERT INTO Phong
                        (SoPhong, MaLoaiPhong, TrangThai)
                        VALUES (@SoPhong, @MaLoaiPhong, @TrangThai)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@SoPhong", p.SoPhong);
            cmd.Parameters.AddWithValue("@MaLoaiPhong", p.MaLoaiPhong);
            cmd.Parameters.AddWithValue("@TrangThai", p.TrangThai);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}