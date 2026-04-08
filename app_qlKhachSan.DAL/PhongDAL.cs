using app_qlKhachSan.DAL;
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

            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                // UPDATE bảng Phong
                string updatePhong = @"
            UPDATE Phong
            SET SoPhong = @SoPhong,
                MaLoaiPhong = @MaLoaiPhong,
                TrangThai = @TrangThai
            WHERE MaPhong = @MaPhong";

                SqlCommand cmd = new SqlCommand(updatePhong, conn, tran);

                cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                cmd.Parameters.AddWithValue("@MaLoaiPhong", maLoaiPhong);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);

                cmd.ExecuteNonQuery();


                // ================= TẠO PHIẾU DỌN PHÒNG =================
                if (trangThai == "CẦN DỌN")
                {
                    string checkDonPhong = @"
                SELECT COUNT(*)
                FROM DonPhong
                WHERE MaPhong = @MaPhong
                AND TrangThai = N'CẦN DỌN'
                AND NgayHoanThanh IS NULL";

                    SqlCommand checkCmd =
                        new SqlCommand(checkDonPhong, conn, tran);

                    checkCmd.Parameters.AddWithValue("@MaPhong", maPhong);

                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists == 0)
                    {
                        string insertDonPhong = @"
                    INSERT INTO DonPhong
                    (MaPhong, TrangThai, NgayTao)
                    VALUES
                    (@MaPhong, N'CẦN DỌN', GETDATE())";

                        SqlCommand cmdInsert =
                            new SqlCommand(insertDonPhong, conn, tran);

                        cmdInsert.Parameters.AddWithValue("@MaPhong", maPhong);

                        cmdInsert.ExecuteNonQuery();
                    }
                }


                // ================= TẠO PHIẾU BẢO TRÌ =================
                if (trangThai == "BẢO TRÌ")
                {
                    string checkBaoTri = @"
                SELECT COUNT(*)
                FROM BaoTriPhong
                WHERE MaPhong = @MaPhong
                AND TrangThai = N'BẢO TRÌ'
                AND NgayHoanThanh IS NULL";

                    SqlCommand checkCmd =
                        new SqlCommand(checkBaoTri, conn, tran);

                    checkCmd.Parameters.AddWithValue("@MaPhong", maPhong);

                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists == 0)
                    {
                        string insertBaoTri = @"
                    INSERT INTO BaoTriPhong
                    (MaPhong, TrangThai, NgayBaoTri)
                    VALUES
                    (@MaPhong, N'BẢO TRÌ', GETDATE())";

                        SqlCommand cmdInsert =
                            new SqlCommand(insertBaoTri, conn, tran);

                        cmdInsert.Parameters.AddWithValue("@MaPhong", maPhong);

                        cmdInsert.ExecuteNonQuery();
                    }
                }


                tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();

                throw new Exception("Lỗi UpdatePhong: " + ex.Message);
            }
        }
    }

    // ================= DELETE =================
    public bool DeletePhong(int maPhong)
    {
        string sql = "DELETE FROM Phong WHERE MaPhong=@MaPhong";

        SqlParameter[] param =
        {
        new SqlParameter("@MaPhong", maPhong)
    };

        return DBHelper.ExecuteNonQuery(sql, param) > 0;
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
    // ================= GET PHÒNG TRỐNG =================

    public DataTable GetPhongTrong()
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();

            string query =
            "SELECT MaPhong, SoPhong FROM Phong WHERE TrangThai=N'TRỐNG'";

            SqlDataAdapter da =
            new SqlDataAdapter(query, conn);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            return dt;
        }
    }


    // ================= LẤY MÃ LOẠI PHÒNG =================

    public string GetMaLoaiPhong(string maPhong)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();

            string query =
            @"SELECT MaLoaiPhong
          FROM Phong
          WHERE MaPhong=@MaPhong";

            SqlCommand cmd =
            new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@MaPhong",
                                       maPhong);

            return cmd.ExecuteScalar().ToString();
        }
    }


    // ================= UPDATE TRẠNG THÁI PHÒNG =================

    public void UpdateTrangThai(string maPhong,
                                string trangThai)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();

            string query =
            @"UPDATE Phong
          SET TrangThai=@TrangThai
          WHERE MaPhong=@MaPhong";

            SqlCommand cmd =
            new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TrangThai",
                                       trangThai);

            cmd.Parameters.AddWithValue("@MaPhong",
                                       maPhong);

            cmd.ExecuteNonQuery();
        }
    }


    // ================= LẤY MÃ ĐẶT PHÒNG MỚI NHẤT =================

    public string GetMaDatPhongMoiNhat()
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();

            string query =
            @"SELECT TOP 1 MaDatPhong
          FROM DatPhong
          ORDER BY NgayTao DESC";

            SqlCommand cmd =
            new SqlCommand(query, conn);

            return cmd.ExecuteScalar().ToString();
        }
    }
}