using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System.Data;

namespace app_qlKhachSan.BUS
{
    public class SuDungDichVuBUS
    {
        SuDungDichVuDAL dal =
        new SuDungDichVuDAL();


        public int Insert(SuDungDichVuDTO dv)
        {
            return dal.Insert(dv);
        }


        public DataTable GetByMaDatPhong(long maDatPhong)
        {
            return dal.GetByMaDatPhong(maDatPhong);
        }


        public DataTable GetByMaDichVu(string maDichVu)
        {
            return dal.GetByMaDichVu(maDichVu);
        }


        public int DeleteByMaDichVu(string maDichVu)
        {
            return dal.DeleteByMaDichVu(maDichVu);
        }
        public decimal GetTongTienDichVu(long maDatPhong)
        {
            return dal.GetTongTienDichVu(maDatPhong);
        }
    }
}