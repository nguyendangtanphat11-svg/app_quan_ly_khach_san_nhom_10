using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;

namespace app_qlKhachSan.BUS
{
    public class DatCocBUS
    {
        DatCocDAL dal = new DatCocDAL();

        public int Insert(DatCocDTO dc)
        {
            return dal.Insert(dc);
        }
        public int Delete(string maDatPhong)
        {
            return dal.Delete(maDatPhong);
        }
        public decimal GetTienDatCoc(string maDatPhong)
        {
            return dal.GetTienDatCoc(maDatPhong);
        }
    }
}