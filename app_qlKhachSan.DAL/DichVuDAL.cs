using app_qlKhachSan.DTO;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class DichVuDAL
    {
        public DataTable GetDanhSach()
        {
            string sql = "SELECT * FROM DichVu";
            return DBHelper.ExecuteQuery(sql);
        }

        public int Insert(DichVuDTO dv)
        {
            string sql = @"
    INSERT INTO DichVu
    (
        TenDichVu,
        DonGia,
        TrangThai
    )
    VALUES
    (
        @TenDichVu,
        @DonGia,
        @TrangThai
    )";

            SqlParameter[] parameters =
            {
        new SqlParameter("@TenDichVu", dv.TenDichVu),
        new SqlParameter("@DonGia", dv.DonGia),
        new SqlParameter("@TrangThai", dv.TrangThai)
    };

            return DBHelper.ExecuteNonQuery(sql, parameters);
        }
        public int Update(DichVuDTO dv)
        {
            string sql = @"UPDATE DichVu
            SET TenDichVu=@TenDichVu,
                DonGia=@DonGia,
                TrangThai=@TrangThai
            WHERE MaDichVu=@MaDichVu";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenDichVu", dv.TenDichVu),
                new SqlParameter("@DonGia", dv.DonGia),
                new SqlParameter("@TrangThai", dv.TrangThai),
                new SqlParameter("@MaDichVu", dv.MaDichVu)
            };

            return DBHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Delete(string maDV)
        {
            string sql = "DELETE FROM DichVu WHERE MaDichVu=@MaDV";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaDV", maDV)
            };

            return DBHelper.ExecuteNonQuery(sql, parameters);
        }
    }
}