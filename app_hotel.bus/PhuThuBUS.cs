using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System.Data;

namespace app_qlKhachSan.BUS
{
    public class PhuThuBUS
    {
        PhuThuDAL dal = new PhuThuDAL();

        public bool Insert(PhuThuDTO pt)
        {
            return dal.InsertPhuThu(pt);
        }

        public DataTable GetDanhSach()
        {
            return dal.GetDanhSach();
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public bool Update(PhuThuDTO pt)
        {
            return dal.UpdatePhuThu(pt);
        }

        public bool Delete(int ma)
        {
            return dal.DeletePhuThu(ma);
        }
    }
}