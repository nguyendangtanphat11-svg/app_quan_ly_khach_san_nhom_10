using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class KhachHangDAL
    {
        string connectionString =
        @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;
          Initial Catalog=HotelManager;
          Integrated Security=True";


        // ================= LẤY DANH SÁCH =================

        public DataTable GetDanhSach()
        {
            string sql =
            "SELECT * FROM KhachHang";

            return DBHelper.ExecuteQuery(sql);
        }


        // ================= THÊM KHÁCH =================

        public bool Them(KhachHangDTO kh)
        {
            string sql =
@"INSERT INTO KhachHang
(
    MaLoaiKH,
    HoTen,
    CCCD_Passport,
    SDT,
    Email,
    DiaChi,
    QuocTich,
    NgayTao
)
VALUES
(
    @MaLoaiKH,
    @HoTen,
    @CCCD,
    @SDT,
    @Email,
    @DiaChi,
    @QuocTich,
    @NgayTao
)";


            SqlParameter[] param =
            {
            

                new SqlParameter("@MaLoaiKH",
                                 kh.MaLoaiKH),

                new SqlParameter("@HoTen",
                                 kh.HoTen),

                new SqlParameter("@CCCD",
                                 kh.CCCD_Passport),

                new SqlParameter("@SDT",
                                 kh.SDT),

                new SqlParameter("@Email",
                                 kh.Email),

                new SqlParameter("@DiaChi",
                                 kh.DiaChi),

                new SqlParameter("@QuocTich",
                                 kh.QuocTich),

                new SqlParameter("@NgayTao",
                                 kh.NgayTao)
            };


            return DBHelper.ExecuteNonQuery(sql, param) > 0;
        }


        // ================= SỬA KHÁCH =================

        public bool Sua(KhachHangDTO kh)
        {
            string sql =
 @"UPDATE KhachHang
SET HoTen=@HoTen,
    SDT=@SDT,
    Email=@Email,
    DiaChi=@DiaChi,
    QuocTich=@QuocTich,
    MaLoaiKH=@MaLoaiKH
WHERE MaKhachHang=@MaKH";


            SqlParameter[] param =
            {
                new SqlParameter("@MaLoaiKH", 
                                kh.MaLoaiKH),

                new SqlParameter("@HoTen",
                                 kh.HoTen),

                new SqlParameter("@SDT",
                                 kh.SDT),

                new SqlParameter("@Email",
                                 kh.Email),

                new SqlParameter("@DiaChi",
                                 kh.DiaChi),

                new SqlParameter("@QuocTich",
                                 kh.QuocTich),

                new SqlParameter("@MaKH",
                                 kh.MaKhachHang)
            };


            return DBHelper.ExecuteNonQuery(sql, param) > 0;
        }


        // ================= XÓA CỨNG KHÁCH =================

        public bool Xoa(int maKH)
        {
            using (SqlConnection conn =
                   new SqlConnection(connectionString))
            {
                conn.Open();

                SqlTransaction tran =
                conn.BeginTransaction();

                try
                {
                    SqlCommand cmd1 =
                    new SqlCommand(
                    @"DELETE FROM DanhSachKhachO
              WHERE MaDatPhong IN
              (
                SELECT MaDatPhong
                FROM DatPhong
                WHERE MaKhachHang=@MaKH
              )",
                    conn, tran);

                    cmd1.Parameters.AddWithValue("@MaKH", maKH);
                    cmd1.ExecuteNonQuery();


                    SqlCommand cmd2 =
                    new SqlCommand(
                    @"DELETE FROM DatCoc
              WHERE MaDatPhong IN
              (
                SELECT MaDatPhong
                FROM DatPhong
                WHERE MaKhachHang=@MaKH
              )",
                    conn, tran);

                    cmd2.Parameters.AddWithValue("@MaKH", maKH);
                    cmd2.ExecuteNonQuery();


                    SqlCommand cmd3 =
                    new SqlCommand(
                    @"DELETE FROM DatPhong
              WHERE MaKhachHang=@MaKH",
                    conn, tran);

                    cmd3.Parameters.AddWithValue("@MaKH", maKH);
                    cmd3.ExecuteNonQuery();


                    SqlCommand cmd4 =
                    new SqlCommand(
                    @"DELETE FROM KhachHang
              WHERE MaKhachHang=@MaKH",
                    conn, tran);

                    cmd4.Parameters.AddWithValue("@MaKH", maKH);
                    cmd4.ExecuteNonQuery();


                    tran.Commit();

                    return true;
                }
                catch (Exception)
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

    }
}