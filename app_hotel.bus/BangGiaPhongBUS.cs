using app_qlKhachSan.DAL;

namespace app_qlKhachSan.BUS
{
    public class BangGiaPhongBUS
    {
        BangGiaPhongDAL dal =
        new BangGiaPhongDAL();

        public decimal GetGiaMoiNhat(string maLoaiPhong)
        {
            return dal.GetGiaMoiNhat(maLoaiPhong);
        }
        public bool InsertGiaMoi(string maLoaiPhong,
                         decimal giaTheoNgay,
                         string ghiChu = "")
        {
            return dal.InsertGiaMoi(
                   maLoaiPhong,
                   giaTheoNgay,
                   ghiChu);
        }
    }
}