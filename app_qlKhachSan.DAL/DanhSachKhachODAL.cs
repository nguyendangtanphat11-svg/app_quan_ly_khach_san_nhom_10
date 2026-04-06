using app_qlKhachSan.DTO;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class DanhSachKhachODAL
    {
        public int Insert(DanhSachKhachODTO ds)
        {
            string sql =
            @"INSERT INTO DanhSachKhachO
              (
                MaDatPhong,
                TenKhach,
                CCCD_Passport,
                QuocTich
              )
              VALUES
              (
                @MaDatPhong,
                @TenKhach,
                @CCCD,
                @QuocTich
              )";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatPhong", ds.MaDatPhong),
                new SqlParameter("@TenKhach", ds.TenKhach),
                new SqlParameter("@CCCD", ds.CCCD),
                new SqlParameter("@QuocTich", ds.QuocTich)
            };

            return DBHelper.ExecuteNonQuery(sql, param);
        }


        public DataTable GetDanhSach()
        {
            string sql =
            "SELECT * FROM DanhSachKhachO";

            return DBHelper.ExecuteQuery(sql);
        }


        public DataTable GetByMaDatPhong(string maDatPhong)
        {
            string sql =
            @"SELECT *
              FROM DanhSachKhachO
              WHERE MaDatPhong = @MaDatPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatPhong", maDatPhong)
            };

            return DBHelper.ExecuteQuery(sql, param);
        }


        public int Delete(string maDatPhong)
        {
            string sql =
            @"DELETE FROM DanhSachKhachO
              WHERE MaDatPhong = @MaDatPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatPhong", maDatPhong)
            };

            return DBHelper.ExecuteNonQuery(sql, param);
        }
    }
}