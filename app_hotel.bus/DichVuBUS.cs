using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System.Data;

namespace app_qlKhachSan.BUS
{
    public class DichVuBUS
    {
        DichVuDAL dal = new DichVuDAL();

        public DataTable GetDanhSach()
        {
            return dal.GetDanhSach();
        }

        public int Insert(DichVuDTO dv)
        {
            return dal.Insert(dv);
        }

        public int Update(DichVuDTO dv)
        {
            return dal.Update(dv);
        }

        public int Delete(string maDV)
        {
            return dal.Delete(maDV);
        }
    }
}