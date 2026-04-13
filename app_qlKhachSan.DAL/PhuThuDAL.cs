using app_qlKhachSan.DTO;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class PhuThuDAL
    {
        private string connStr =
        @"Data Source=.;Initial Catalog=HotelManager;Integrated Security=True";


        // ===============================
        // INSERT
        // ===============================
        public bool InsertPhuThu(PhuThuDTO pt)
        {
            string sql =
            @"INSERT INTO PhuThu
            (TenPhuThu, DonGia, TrangThai)
            VALUES
            (@TenPhuThu, @DonGia, @TrangThai)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenPhuThu", pt.TenPhuThu),
                new SqlParameter("@DonGia", pt.DonGia),
                new SqlParameter("@TrangThai", pt.TrangThai)
            };

            return DBHelper.ExecuteNonQuery(sql, parameters) > 0;
        }


        // ===============================
        // SELECT DANH SÁCH PHỤ THU ACTIVE
        // ===============================
        public DataTable GetDanhSach()
        {
            string sql =
            @"SELECT
                MaPhuThu,
                TenPhuThu,
                DonGia,
                TrangThai
            FROM PhuThu
            WHERE TrangThai = 1";

            return DBHelper.ExecuteQuery(sql);
        }


        // ===============================
        // SELECT ALL (phục vụ combobox)
        // ===============================
        public DataTable GetAll()
        {
            string sql =
            @"SELECT
                MaPhuThu,
                TenPhuThu,
                DonGia,
                TrangThai
            FROM PhuThu";

            return DBHelper.ExecuteQuery(sql);
        }


        // ===============================
        // UPDATE
        // ===============================
        public bool UpdatePhuThu(PhuThuDTO pt)
        {
            string sql =
            @"UPDATE PhuThu
            SET
                TenPhuThu = @TenPhuThu,
                DonGia = @DonGia,
                TrangThai = @TrangThai
            WHERE MaPhuThu = @MaPhuThu";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenPhuThu", pt.TenPhuThu),
                new SqlParameter("@DonGia", pt.DonGia),
                new SqlParameter("@TrangThai", pt.TrangThai),
                new SqlParameter("@MaPhuThu", pt.MaPhuThu)
            };

            return DBHelper.ExecuteNonQuery(sql, parameters) > 0;
        }


        // ===============================
        // DELETE (xóa mềm)
        // ===============================
        public bool DeletePhuThu(int maPhuThu)
        {
            string sql =
            @"UPDATE PhuThu
            SET TrangThai = 0
            WHERE MaPhuThu = @MaPhuThu";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaPhuThu", maPhuThu)
            };

            return DBHelper.ExecuteNonQuery(sql, parameters) > 0;
        }


        // ===============================
        // LẤY PHỤ THU THEO ID
        // ===============================
        public DataRow GetById(int maPhuThu)
        {
            string sql =
            @"SELECT *
            FROM PhuThu
            WHERE MaPhuThu = @MaPhuThu";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaPhuThu", maPhuThu)
            };

            DataTable dt =
            DBHelper.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count > 0)
                return dt.Rows[0];

            return null;
        }
    }
}