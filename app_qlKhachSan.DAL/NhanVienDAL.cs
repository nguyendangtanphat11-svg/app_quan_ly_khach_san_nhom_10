using System.Data;

namespace app_qlKhachSan.DAL
{
    public class NhanVienDAL
    {
        public DataTable GetNhanVien()
        {
            string sql = @"
            SELECT
                MaNhanVien,
                TenNhanVien,
                DienThoai,
                ChucVu,
                TrangThai
            FROM NhanVien
            WHERE TrangThai = N'ĐANG LÀM'
            ";

            return DBHelper.ExecuteQuery(sql);
        }
    }
}