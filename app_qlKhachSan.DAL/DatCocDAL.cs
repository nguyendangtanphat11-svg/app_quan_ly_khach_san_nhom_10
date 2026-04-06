using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class DatCocDAL
    {
        public int Insert(DatCocDTO dc)
        {
            string sql = @"
            INSERT INTO DatCoc
            (
                MaDatPhong,
                SoTien,
                HinhThuc,
                NgayDatCoc,
                GhiChu
            )
            VALUES
            (
                @MaDatPhong,
                @SoTien,
                @HinhThuc,
                GETDATE(),
                @GhiChu
            )";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatPhong", dc.MaDatPhong),
                new SqlParameter("@SoTien", dc.SoTien),
                new SqlParameter("@HinhThuc", dc.HinhThuc),
                new SqlParameter("@GhiChu", dc.GhiChu)
            };

            return DBHelper.ExecuteNonQuery(sql, param);
        }
        public int Delete(string maDatPhong)
        {
            string sql =
            @"DELETE FROM DatCoc
      WHERE MaDatPhong=@MaDatPhong";

            SqlParameter[] param =
            {
        new SqlParameter(
        "@MaDatPhong",
        maDatPhong)
    };

            return DBHelper.ExecuteNonQuery(sql, param);
        }
        public decimal GetTienDatCoc(string maDatPhong)
        {
            string sql =
            @"SELECT ISNULL(SUM(SoTien),0)
      FROM DatCoc
      WHERE MaDatPhong=@MaDatPhong";

            SqlParameter[] param =
            {
        new SqlParameter(
        "@MaDatPhong",
        maDatPhong)
    };

            object result =
            DBHelper.ExecuteScalar(sql, param);

            return Convert.ToDecimal(result);
        }
    }
}