using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using app_qlKhachSan.DTO;

namespace app_qlKhachSan.DAL
{
    public class TrangChuDAL
    {
        string connStr = @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True;";

        public int TongPhong()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                return (int)new SqlCommand("SELECT COUNT(*) FROM Phong", conn).ExecuteScalar();
            }
        }

        public int PhongTrong()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                return (int)new SqlCommand("SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Trống'", conn).ExecuteScalar();
            }
        }

        public int PhongDangO()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                return (int)new SqlCommand("SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Đang ở'", conn).ExecuteScalar();
            }
        }

        public decimal DoanhThuHomNay()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                return Convert.ToDecimal(new SqlCommand(@"
                    SELECT ISNULL(SUM(TongTien),0)
                    FROM HoaDon
                    WHERE TrangThaiThanhToan = N'ĐÃ THANH TOÁN'
                    AND CAST(NgayTao AS DATE) = CAST(GETDATE() AS DATE)", conn).ExecuteScalar());
            }
        }

        public int SuDungDichVu()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                return (int)new SqlCommand(@"
                    SELECT ISNULL(COUNT(MaSuDung),0)
                    FROM SuDungDichVu
                    WHERE CAST(ThoiGianSuDung AS DATE) = CAST(GETDATE() AS DATE)", conn).ExecuteScalar();
            }
        }

        public List<DoanhThuDTO> DoanhThuThang()
        {
            List<DoanhThuDTO> list = new List<DoanhThuDTO>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT DAY(NgayTao), SUM(TongTien)
                    FROM HoaDon
                    WHERE MONTH(NgayTao)=MONTH(GETDATE())
                    AND YEAR(NgayTao)=YEAR(GETDATE())
                    AND TrangThaiThanhToan = N'ĐÃ THANH TOÁN'
                    GROUP BY DAY(NgayTao)", conn);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new DoanhThuDTO
                    {
                        Ngay = Convert.ToInt32(r[0]),
                        DoanhThu = Convert.ToDecimal(r[1])
                    });
                }
            }

            return list;
        }
    }
}