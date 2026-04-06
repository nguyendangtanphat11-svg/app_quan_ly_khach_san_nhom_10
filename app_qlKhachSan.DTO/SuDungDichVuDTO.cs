using System;

namespace app_qlKhachSan.DTO
{
    public class SuDungDichVuDTO
    {
        public int MaSuDung { get; set; }

        public string MaDatPhong { get; set; }

        public int MaDichVu { get; set; }

        public int SoLuong { get; set; }

        public DateTime ThoiGianSuDung { get; set; }

        public string GhiChu { get; set; }
    }
}