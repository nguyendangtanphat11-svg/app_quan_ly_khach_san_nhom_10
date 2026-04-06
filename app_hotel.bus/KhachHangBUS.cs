using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System.Data;

namespace app_qlKhachSan.BUS
{
    public class KhachHangBUS
    {
        KhachHangDAL dal = new KhachHangDAL();

        public DataTable GetDanhSach()
        {
            return dal.GetDanhSach();
        }

        public bool Them(KhachHangDTO kh)
        {
            return dal.Them(kh);
        }

        public bool Xoa(int maKH)
        {
            return dal.Xoa(maKH);
        }

        public bool Sua(KhachHangDTO kh)
        {
            return dal.Sua(kh);
        }
    }
}