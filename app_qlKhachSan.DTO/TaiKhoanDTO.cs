using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_qlKhachSan.DTO
{
    public class TaiKhoanDTO
    {
        public string MaTaiKhoan { get; set; }

        public string TenDangNhap { get; set; }

        public string MatKhauHash { get; set; }

        public string HoTen { get; set; }

        public string SDT { get; set; }

        public string TrangThai { get; set; }

        public DateTime NgayTao { get; set; }

        public string MaNhanVien { get; set; }

        public string VaiTro { get; set; } // dùng cho login
    }
}
