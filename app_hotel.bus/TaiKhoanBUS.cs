using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_qlKhachSan.BUS  
{
    public class TaiKhoanBUS
    {
        TaiKhoanDAL dal = new TaiKhoanDAL();

        public TaiKhoanDTO DangNhap(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            return dal.DangNhap(username, password);
        }
        public DataTable GetDanhSach()
        {
            return dal.GetDanhSach();
        }

        public bool Insert(TaiKhoanDTO tk)
        {
            return dal.Insert(tk);
        }

        public bool Update(TaiKhoanDTO tk)
        {
            return dal.Update(tk);
        }

        public bool Delete(string ma)
        {
            return dal.Delete(ma);
        }
    }

}