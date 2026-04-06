using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class SuDungDichVuDAL
    {
        // ================= LẤY DANH SÁCH THEO MÃ DỊCH VỤ =================

        public DataTable GetByMaDichVu(string maDichVu)
        {
            string sql = @"
            SELECT *
            FROM SuDungDichVu
            WHERE MaDichVu = @MaDichVu";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaDichVu", maDichVu)
            };

            return DBHelper.ExecuteQuery(sql, parameters);
        }


        // ================= XÓA THEO MÃ DỊCH VỤ =================

        public int DeleteByMaDichVu(string maDichVu)
        {
            string sql = @"
            DELETE FROM SuDungDichVu
            WHERE MaDichVu = @MaDichVu";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaDichVu", maDichVu)
            };

            return DBHelper.ExecuteNonQuery(sql, parameters);
        }


        // ================= LẤY DANH SÁCH THEO MÃ ĐẶT PHÒNG =================

        public DataTable GetByMaDatPhong(long maDatPhong)
        {
            string sql = @"
            SELECT *
            FROM SuDungDichVu
            WHERE MaDatPhong = @MaDatPhong";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaDatPhong", maDatPhong)
            };

            return DBHelper.ExecuteQuery(sql, parameters);
        }


        // ================= THÊM DỊCH VỤ SỬ DỤNG =================

        public int Insert(SuDungDichVuDTO dv)
        {
            string sql = @"
            INSERT INTO SuDungDichVu
            (
                MaDatPhong,
                MaDichVu,
                SoLuong,
                ThoiGianSuDung,
                GhiChu
            )
            VALUES
            (
                @MaDatPhong,
                @MaDichVu,
                @SoLuong,
                GETDATE(),
                @GhiChu
            )";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaDatPhong", dv.MaDatPhong),
                new SqlParameter("@MaDichVu", dv.MaDichVu),
                new SqlParameter("@SoLuong", dv.SoLuong),
                new SqlParameter("@GhiChu", dv.GhiChu)
            };

            return DBHelper.ExecuteNonQuery(sql, parameters);
        }


        // ================= TÍNH TỔNG TIỀN DỊCH VỤ =================

        public decimal GetTongTienDichVu(long maDatPhong)
        {
            string sql = @"
            SELECT ISNULL(
                SUM(sd.SoLuong * dv.DonGia), 0)
            FROM SuDungDichVu sd
            JOIN DichVu dv
                ON sd.MaDichVu = dv.MaDichVu
            WHERE sd.MaDatPhong = @MaDatPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatPhong", maDatPhong)
            };

            object result =
            DBHelper.ExecuteScalar(sql, param);

            return Convert.ToDecimal(result);
        }
    }
}