using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System.Data;

namespace app_qlKhachSan.BUS
{
    public class DanhSachKhachOBUS
    {
        DanhSachKhachODAL dal =
        new DanhSachKhachODAL();


        // ================= INSERT =================

        public int Insert(DanhSachKhachODTO ds)
        {
            return dal.Insert(ds);
        }


        // ================= GET ALL =================

        public DataTable GetDanhSach()
        {
            return dal.GetDanhSach();
        }


        // ================= GET THEO MÃ ĐẶT PHÒNG =================

        public DataTable GetByMaDatPhong(string maDatPhong)
        {
            return dal.GetByMaDatPhong(maDatPhong);
        }


        // ================= DELETE THEO MÃ ĐẶT PHÒNG =================

        public int Delete(string maDatPhong)
        {
            return dal.Delete(maDatPhong);
        }
    }
}