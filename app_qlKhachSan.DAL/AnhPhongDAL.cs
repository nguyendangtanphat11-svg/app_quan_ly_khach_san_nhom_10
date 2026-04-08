using System.Data.SqlClient;
using app_qlKhachSan.DTO;

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
    }
}