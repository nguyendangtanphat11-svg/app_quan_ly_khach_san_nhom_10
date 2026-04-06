using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class HoaDonDAL
    {
        public int Insert(HoaDonDTO hd)
        {
            string sql = @"
            INSERT INTO HoaDon
            (
                MaDatPhong,
                TienPhong,
                TienDichVu,
                TongTien,
                TrangThaiThanhToan,
                NgayTao
            )
            VALUES
            (
                @MaDatPhong,
                @TienPhong,
                @TienDichVu,
                @TongTien,
                N'ĐÃ THANH TOÁN',
                GETDATE()
            )";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatPhong", hd.MaDatPhong),
                new SqlParameter("@TienPhong", hd.TienPhong),
                new SqlParameter("@TienDichVu", hd.TienDichVu),
                new SqlParameter("@TongTien", hd.TongTien)
            };

            return DBHelper.ExecuteNonQuery(sql, param);
        }


        public int GetLastHoaDonID()
        {
            string sql =
            "SELECT IDENT_CURRENT('HoaDon')";

            object result =
            DBHelper.ExecuteScalar(sql);

            return int.Parse(result.ToString());
        }
        public DataTable GetAllHoaDon()
        {
            string sql = @"
    SELECT *
    FROM HoaDon
    ORDER BY NgayTao DESC";

            return DBHelper.ExecuteQuery(sql);
        }
        public int UpdateHoaDon(int maHoaDon, string trangThai)
        {
            string sql = @"
    UPDATE HoaDon
    SET TrangThaiThanhToan = @TrangThai
    WHERE MaHoaDon = @MaHoaDon";

            SqlParameter[] param =
            {
        new SqlParameter("@TrangThai", trangThai),
        new SqlParameter("@MaHoaDon", maHoaDon)
    };

            return DBHelper.ExecuteNonQuery(sql, param);
        }
        public bool Exists(long maDatPhong)
        {
            string sql = @"
    SELECT COUNT(*)
    FROM HoaDon
    WHERE MaDatPhong = @MaDatPhong";

            SqlParameter[] param =
            {
        new SqlParameter("@MaDatPhong", maDatPhong)
    };

            int count =
            Convert.ToInt32(
            DBHelper.ExecuteScalar(sql, param));

            return count > 0;
        }
        public int GetMaHoaDonByMaDatPhong(long maDatPhong)
        {
            string sql = @"
    SELECT MaHoaDon
    FROM HoaDon
    WHERE MaDatPhong = @MaDatPhong";

            SqlParameter[] param =
            {
        new SqlParameter("@MaDatPhong", maDatPhong)
    };

            return Convert.ToInt32(
            DBHelper.ExecuteScalar(sql, param));
        }
    }
}