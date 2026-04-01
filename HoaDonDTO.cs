using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_qlKhachSan.DTO
{
    public class HoaDonDTO
    {
        public long MaHoaDon { get; set; }
        public long MaDatPhong { get; set; }
        public int? MaKhuyenMai { get; set; }

        public decimal TienPhong { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TienPhuThu { get; set; }
        public decimal GiamGia { get; set; }
        public decimal VAT { get; set; }
        public decimal TongTien { get; set; }

        public string TrangThaiThanhToan { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
