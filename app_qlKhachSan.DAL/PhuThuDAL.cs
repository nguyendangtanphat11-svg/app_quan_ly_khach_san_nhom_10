using System.Data;

namespace app_qlKhachSan.DAL
{
    public class PhuThuDAL
    {
        public DataTable GetDanhSach()
        {
            string sql =
            "SELECT * FROM PhuThu WHERE TrangThai = 1";

            return DBHelper.ExecuteQuery(sql);
        }
    }
}