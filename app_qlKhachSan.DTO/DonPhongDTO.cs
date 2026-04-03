using System;

namespace app_qlKhachSan.DTO
{
    public class DonPhongDTO
    {
        public int MaDonPhong { get; set; }

        public int MaPhong { get; set; }

        public int? MaNhanVien { get; set; }

        public string TrangThai { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime? NgayHoanThanh { get; set; }

        public string GhiChu { get; set; }
    }
}