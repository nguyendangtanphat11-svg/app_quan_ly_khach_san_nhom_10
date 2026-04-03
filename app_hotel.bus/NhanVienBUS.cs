using System.Data;
using app_qlKhachSan.DAL;

namespace app_qlKhachSan.BUS
{
    public class NhanVienBUS
    {
        NhanVienDAL dal = new NhanVienDAL();

        public DataTable GetNhanVien()
        {
            return dal.GetNhanVien();
        }
    }
}