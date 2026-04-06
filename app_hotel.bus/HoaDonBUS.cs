using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System.Data;

namespace app_qlKhachSan.BUS
{
    public class HoaDonBUS
    {
        HoaDonDAL dal =
        new HoaDonDAL();


        public int Insert(HoaDonDTO hd)
        {
            return dal.Insert(hd);
        }


        public int GetLastHoaDonID()
        {
            return dal.GetLastHoaDonID();
        }
        public DataTable GetAllHoaDon()
        {
            return dal.GetAllHoaDon();
        }
        public int UpdateHoaDon(int maHoaDon, string trangThai)
        {
            return dal.UpdateHoaDon(maHoaDon, trangThai);
        }
        public bool Exists(long maDatPhong)
        {
            return dal.Exists(maDatPhong);
        }
        public int GetMaHoaDonByMaDatPhong(long maDatPhong)
        {
            return dal.GetMaHoaDonByMaDatPhong(maDatPhong);
        }
    }
}