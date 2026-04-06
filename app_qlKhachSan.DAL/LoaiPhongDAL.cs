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
        using (SqlConnection conn =
               new SqlConnection(connectionString))
        {
            conn.Open();

            SqlTransaction tran =
            conn.BeginTransaction();

            try
            {
                // UPDATE thông tin loại phòng
                string updateLoaiPhong =
                @"UPDATE LoaiPhong
              SET TenLoaiPhong=@ten,
                  GiaTheoGio=@gio,
                  SoNguoiToiDa=@songuoi,
                  MoTa=@mota
              WHERE MaLoaiPhong=@ma";

                SqlCommand cmd1 =
                new SqlCommand(updateLoaiPhong,
                               conn,
                               tran);

                cmd1.Parameters.AddWithValue("@ma",
                                            lp.MaLoaiPhong);

                cmd1.Parameters.AddWithValue("@ten",
                                            lp.TenLoaiPhong);

                cmd1.Parameters.AddWithValue("@gio",
                                            lp.GiaTheoGio);

                cmd1.Parameters.AddWithValue("@songuoi",
                                            lp.SoNguoiToiDa);

                cmd1.Parameters.AddWithValue("@mota",
                                            lp.MoTa);

                cmd1.ExecuteNonQuery();


                // INSERT giá mới vào BangGiaPhong
                string insertGia =
                @"INSERT INTO BangGiaPhong
              (MaLoaiPhong,
               NgayApDung,
               GiaTheoNgay,
               GhiChu)
              VALUES
              (@MaLoaiPhong,
               GETDATE(),
               @GiaTheoNgay,
               N'Cập nhật giá')";

                SqlCommand cmd2 =
                new SqlCommand(insertGia,
                               conn,
                               tran);

                cmd2.Parameters.AddWithValue("@MaLoaiPhong",
                                            lp.MaLoaiPhong);

                cmd2.Parameters.AddWithValue("@GiaTheoNgay",
                                            lp.GiaTheoNgay);

                cmd2.ExecuteNonQuery();


                tran.Commit();

                return true;
            }
            catch
            {
                tran.Rollback();

                return false;
            }
        }
    }

    public bool DeleteLoaiPhong(string maLoaiPhong)
    {
        using (SqlConnection conn =
               new SqlConnection(connectionString))
        {
            conn.Open();

            SqlTransaction tran =
            conn.BeginTransaction();

            try
            {
                // XÓA bảng giá trước
                SqlCommand cmd1 =
                new SqlCommand(
                @"DELETE FROM BangGiaPhong
              WHERE MaLoaiPhong=@MaLoaiPhong",
                conn, tran);

                cmd1.Parameters.AddWithValue("@MaLoaiPhong",
                                            maLoaiPhong);

                cmd1.ExecuteNonQuery();


                // XÓA phòng thuộc loại phòng
                SqlCommand cmd2 =
                new SqlCommand(
                @"DELETE FROM Phong
              WHERE MaLoaiPhong=@MaLoaiPhong",
                conn, tran);

                cmd2.Parameters.AddWithValue("@MaLoaiPhong",
                                            maLoaiPhong);

                cmd2.ExecuteNonQuery();


                // CUỐI CÙNG mới xóa loại phòng
                SqlCommand cmd3 =
                new SqlCommand(
                @"DELETE FROM LoaiPhong
              WHERE MaLoaiPhong=@MaLoaiPhong",
                conn, tran);

                cmd3.Parameters.AddWithValue("@MaLoaiPhong",
                                            maLoaiPhong);

                cmd3.ExecuteNonQuery();


                tran.Commit();

                return true;
            }
            catch
            {
                tran.Rollback();

                return false;
            }
        }
    }
    public bool InsertLoaiPhong(LoaiPhongDTO lp)
    {
        using (SqlConnection conn =
               new SqlConnection(connectionString))
        {
            conn.Open();

            SqlTransaction tran =
            conn.BeginTransaction();

            try
            {
                // INSERT LoaiPhong
                string insertLoaiPhong =
                @"INSERT INTO LoaiPhong
              (TenLoaiPhong,
               GiaTheoNgay,
               GiaTheoGio,
               SoNguoiToiDa,
               MoTa)
              VALUES
              (@ten,
               @ngay,
               @gio,
               @songuoi,
               @mota);

              SELECT SCOPE_IDENTITY();";

                SqlCommand cmdLoaiPhong =
                new SqlCommand(insertLoaiPhong,
                               conn,
                               tran);

                cmdLoaiPhong.Parameters.AddWithValue("@ten",
                                                     lp.TenLoaiPhong);

                cmdLoaiPhong.Parameters.AddWithValue("@ngay",
                                                     lp.GiaTheoNgay);

                cmdLoaiPhong.Parameters.AddWithValue("@gio",
                                                     lp.GiaTheoGio);

                cmdLoaiPhong.Parameters.AddWithValue("@songuoi",
                                                     lp.SoNguoiToiDa);

                cmdLoaiPhong.Parameters.AddWithValue("@mota",
                                                     lp.MoTa);


                object result =
                cmdLoaiPhong.ExecuteScalar();


                string maLoaiPhong =
                result.ToString();


                // INSERT BangGiaPhong luôn
                string insertBangGia =
                @"INSERT INTO BangGiaPhong
              (MaLoaiPhong,
               NgayApDung,
               GiaTheoNgay,
               GhiChu)
              VALUES
              (@MaLoaiPhong,
               GETDATE(),
               @GiaTheoNgay,
               N'Giá khởi tạo')";

                SqlCommand cmdBangGia =
                new SqlCommand(insertBangGia,
                               conn,
                               tran);

                cmdBangGia.Parameters.AddWithValue("@MaLoaiPhong",
                                                   maLoaiPhong);

                cmdBangGia.Parameters.AddWithValue("@GiaTheoNgay",
                                                   lp.GiaTheoNgay);

                cmdBangGia.ExecuteNonQuery();


                tran.Commit();

                return true;
            }
            catch
            {
                tran.Rollback();

                return false;
            }
        }
    }
}