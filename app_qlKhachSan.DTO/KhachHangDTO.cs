using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_qlKhachSan.DTO
{
    public class KhachHangDTO
    {
        public int MaKhachHang { get; set; }
        public int MaLoaiKH { get; set; }
        public string HoTen { get; set; }
        public string CCCD_Passport { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string QuocTich { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
