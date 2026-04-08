using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;

namespace app_qlKhachSan.BUS
{
    public class AnhPhongBUS
    {
        AnhPhongDAL dal = new AnhPhongDAL();

        public bool InsertAnhPhong(AnhPhongDTO a)
        {
            return dal.InsertAnhPhong(a);
        }
        public string GetAnhTheoTenLoaiPhong(string tenLoaiPhong)
        {
            return dal.GetAnhTheoTenLoaiPhong(tenLoaiPhong);
        }
    }

}