using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using app_qlKhachSan.DTO;

namespace app_qlKhachSan.DAL  
{
    public class TaiKhoanDAL
    {
        string connStr = @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True;";

        public TaiKhoanDTO DangNhap(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT tk.HoTen, tk.SDT, vt.TenVaiTro
                                 FROM TaiKhoan tk
                                 JOIN PhanQuyen pq ON tk.MaTaiKhoan = pq.MaTaiKhoan
                                 JOIN VaiTro vt ON pq.MaVaiTro = vt.MaVaiTro
                                 WHERE tk.TenDangNhap = @username
                                 AND tk.MatKhauHash = @password
                                 AND tk.TrangThai = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new TaiKhoanDTO
                    {
                        HoTen = reader["HoTen"].ToString(),
                        SDT = reader["SDT"].ToString(),
                        VaiTro = reader["TenVaiTro"].ToString()
                    };
                }
            }
            return null;
        }
    }
}