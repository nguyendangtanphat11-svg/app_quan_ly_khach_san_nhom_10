using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_qlKhachSan.DTO;
using app_qlKhachSan.DAL;

namespace app_hotel.bus
{
    public class HoaDonB
    {
        HoaDonDAL dal = new HoaDonDAL();

        public decimal TinhTongTien(HoaDonDTO hd)
        {
            decimal tong = hd.TienPhong + hd.TienDichVu + hd.TienPhuThu;

            // trừ giảm giá
            tong = tong - hd.GiamGia;

            // cộng VAT
            tong = tong + (tong * hd.VAT / 100);

            return tong;
        }

        public int InsertHoaDon(HoaDonDTO hd)
        {
            // check cơ bản
            if (hd.MaDatPhong <= 0)
                return 0;

            if (hd.TongTien < 0)
                return 0;

            return dal.InsertHoaDon(hd);
        }
        public bool UpdateHoaDon(int maHD, decimal tongTien)
        {
            return HoaDonDAL.UpdateHoaDon(maHD, tongTien);
        }
    }
}
