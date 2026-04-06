using System.Data;
using app_qlKhachSan.DAL;

namespace app_qlKhachSan.BUS
{
    public class LoaiKhachHangBUS
    {
        LoaiKhachHangDAL dal =
            new LoaiKhachHangDAL();

        public DataTable GetDanhSach()
        {
            return dal.GetDanhSach();
        }
    }
}