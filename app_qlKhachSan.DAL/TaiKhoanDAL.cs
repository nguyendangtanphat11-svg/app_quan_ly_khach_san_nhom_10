using app_qlKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                string query = @"SELECT HoTen, SDT
FROM TaiKhoan
WHERE TenDangNhap = @username
AND MatKhauHash = @password
AND TrangThai = 1";

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
                        VaiTro = "User"
                    };
                }
            }
            return null;
        }
        public DataTable GetDanhSach()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM TaiKhoan";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public bool Insert(TaiKhoanDTO tk)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO TaiKhoan
        VALUES(@MaTaiKhoan,@TenDangNhap,@MatKhauHash,
        @HoTen,@SDT,@TrangThai,@NgayTao,@MaNhanVien)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaTaiKhoan", tk.MaTaiKhoan);
                cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhauHash", tk.MatKhauHash);
                cmd.Parameters.AddWithValue("@HoTen", tk.HoTen);
                cmd.Parameters.AddWithValue("@SDT", tk.SDT);
                cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
                cmd.Parameters.AddWithValue("@NgayTao", tk.NgayTao);
                cmd.Parameters.AddWithValue("@MaNhanVien", tk.MaNhanVien);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Update(TaiKhoanDTO tk)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE TaiKhoan SET
        TenDangNhap=@TenDangNhap,
        HoTen=@HoTen,
        SDT=@SDT,
        TrangThai=@TrangThai,
        MaNhanVien=@MaNhanVien
        WHERE MaTaiKhoan=@MaTaiKhoan";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
                cmd.Parameters.AddWithValue("@HoTen", tk.HoTen);
                cmd.Parameters.AddWithValue("@SDT", tk.SDT);
                cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
                cmd.Parameters.AddWithValue("@MaNhanVien", tk.MaNhanVien);
                cmd.Parameters.AddWithValue("@MaTaiKhoan", tk.MaTaiKhoan);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Delete(string ma)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "DELETE FROM TaiKhoan WHERE MaTaiKhoan=@Ma";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Ma", ma);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}