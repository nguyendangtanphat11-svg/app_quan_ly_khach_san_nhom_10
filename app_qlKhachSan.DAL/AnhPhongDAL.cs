using app_qlKhachSan.DTO;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class AnhPhongDAL
    {
        public bool InsertAnhPhong(AnhPhongDTO a)
        {
            string sql = @"
            INSERT INTO AnhPhong(MaLoaiPhong, DuongDanAnh, MoTa)
            VALUES(@MaLoaiPhong, @DuongDanAnh, @MoTa)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaLoaiPhong", a.MaLoaiPhong),
                new SqlParameter("@DuongDanAnh", a.DuongDanAnh),
                new SqlParameter("@MoTa", a.MoTa)
            };

            return DBHelper.ExecuteNonQuery(sql, param) > 0;
        }
        public string GetAnhTheoTenLoaiPhong(string tenLoaiPhong)
        {
            string sql = @"
    SELECT TOP 1 DuongDanAnh
    FROM AnhPhong ap
    JOIN LoaiPhong lp
    ON ap.MaLoaiPhong = lp.MaLoaiPhong
    WHERE lp.TenLoaiPhong = @TenLoaiPhong";

            SqlParameter[] param =
            {
        new SqlParameter("@TenLoaiPhong", tenLoaiPhong)
    };

            DataTable dt = DBHelper.ExecuteQuery(sql, param);

            if (dt.Rows.Count > 0)
                return dt.Rows[0]["DuongDanAnh"].ToString();

            return "";
        }
    }
}