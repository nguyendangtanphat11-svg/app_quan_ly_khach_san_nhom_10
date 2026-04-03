using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;

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
    }
}