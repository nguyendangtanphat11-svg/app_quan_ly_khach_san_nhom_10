using System.Data;

namespace app_qlKhachSan.DAL
{
    public class LoaiKhachHangDAL
    {
        public DataTable GetDanhSach()
        {
            string sql =
            "SELECT * FROM LoaiKhachHang";

            return DBHelper.ExecuteQuery(sql);
        }
    }
}