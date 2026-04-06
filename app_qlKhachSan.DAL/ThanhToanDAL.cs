using app_qlKhachSan.DTO;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class ThanhToanDAL
    {
        public int Insert(ThanhToanDTO tt)
        {
            string sql = @"
            INSERT INTO ThanhToan
            (
                MaHoaDon,
                SoTienThanhToan,
                PhuongThuc,
                ThoiGianThanhToan
            )
            VALUES
            (
                @MaHoaDon,
                @SoTien,
                @PhuongThuc,
                GETDATE()
            )";

            SqlParameter[] param =
            {
                new SqlParameter("@MaHoaDon", tt.MaHoaDon),
                new SqlParameter("@SoTien", tt.SoTienThanhToan),
                new SqlParameter("@PhuongThuc", tt.PhuongThuc)
            };

            return DBHelper.ExecuteNonQuery(sql, param);
        }
        public DataTable GetByMaDatPhong(long maDatPhong)
        {
            string sql = @"
    SELECT 
        tt.MaThanhToan,
        tt.MaHoaDon,
        tt.SoTienThanhToan,
        tt.PhuongThuc,
        tt.ThoiGianThanhToan,
        tt.GhiChu
    FROM ThanhToan tt
    JOIN HoaDon hd
        ON tt.MaHoaDon = hd.MaHoaDon
    WHERE hd.MaDatPhong = @MaDatPhong";

            SqlParameter[] param =
            {
        new SqlParameter("@MaDatPhong", maDatPhong)
    };

            return DBHelper.ExecuteQuery(sql, param);
        }
        public DataTable GetAll()
        {
            string sql = @"
    SELECT 
        tt.MaThanhToan,
        hd.MaDatPhong,
        tt.MaHoaDon,
        tt.SoTienThanhToan,
        tt.PhuongThuc,
        tt.ThoiGianThanhToan,
        tt.GhiChu
    FROM ThanhToan tt
    JOIN HoaDon hd
        ON tt.MaHoaDon = hd.MaHoaDon
    ORDER BY tt.ThoiGianThanhToan DESC";

            return DBHelper.ExecuteQuery(sql);
        }

    }
}