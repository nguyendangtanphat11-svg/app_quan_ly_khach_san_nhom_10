using System;

namespace app_qlKhachSan.DTO
{
    public class DatPhongDTO
    {
        public string MaDatPhong { get; set; }

        public string MaKhachHang { get; set; }

        public string MaPhong { get; set; }

        public DateTime NgayNhanPhong { get; set; }

        public DateTime NgayTraPhong { get; set; }

        public string TrangThai { get; set; }

        public DateTime NgayTao { get; set; }

        public string GhiChu { get; set; }
    }
}