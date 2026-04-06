using app_qlKhachSan.DAL;
using System.Data;

namespace app_qlKhachSan.BUS
{
    public class PhuThuBUS
    {
        PhuThuDAL dal = new PhuThuDAL();

        public DataTable GetDanhSach()
        {
            return dal.GetDanhSach();
        }
    }
}