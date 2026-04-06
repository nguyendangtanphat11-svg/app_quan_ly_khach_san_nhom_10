using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System.Data;

namespace app_qlKhachSan.BUS
{
    public class ThanhToanBUS
    {
        ThanhToanDAL dal =
        new ThanhToanDAL();


        public int Insert(ThanhToanDTO tt)
        {
            return dal.Insert(tt);
        }
        public DataTable GetByMaDatPhong(long maDatPhong)
        {
            return dal.GetByMaDatPhong(maDatPhong);
        }
        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}