using System.Collections.Generic;
using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;

namespace app_qlKhachSan.BUS
{
    public class TrangChuBUS
    {
        TrangChuDAL dal = new TrangChuDAL();

        public int TongPhong() => dal.TongPhong();
        public int PhongTrong() => dal.PhongTrong();
        public int PhongDangO() => dal.PhongDangO();
        public decimal DoanhThuHomNay() => dal.DoanhThuHomNay();
        public int SuDungDichVu() => dal.SuDungDichVu();
        public List<DoanhThuDTO> DoanhThuThang() => dal.DoanhThuThang();
    }
}