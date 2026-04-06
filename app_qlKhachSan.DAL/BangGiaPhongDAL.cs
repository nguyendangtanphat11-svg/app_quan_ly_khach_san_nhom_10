using System;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class BangGiaPhongDAL
    {
        public decimal GetGiaMoiNhat(string maLoaiPhong)
        {
            string sql =
            @"SELECT TOP 1 GiaTheoNgay
              FROM BangGiaPhong
              WHERE MaLoaiPhong=@MaLoaiPhong
              ORDER BY NgayApDung DESC";

            SqlParameter[] param =
            {
                new SqlParameter("@MaLoaiPhong",
                                 maLoaiPhong)
            };

            object result =
            DBHelper.ExecuteScalar(sql, param);

            if (result == null)
                return 0;

            return Convert.ToDecimal(result);
        }
        public bool InsertGiaMoi(string maLoaiPhong,
                         decimal giaTheoNgay,
                         string ghiChu = "")
        {
            string sql =
            @"INSERT INTO BangGiaPhong
      (MaLoaiPhong,
       NgayApDung,
       GiaTheoNgay,
       GhiChu)
      VALUES
      (@MaLoaiPhong,
       GETDATE(),
       @GiaTheoNgay,
       @GhiChu)";

            SqlParameter[] param =
            {
        new SqlParameter("@MaLoaiPhong",
                         maLoaiPhong),

        new SqlParameter("@GiaTheoNgay",
                         giaTheoNgay),

        new SqlParameter("@GhiChu",
                         ghiChu)
    };

            return DBHelper.ExecuteNonQuery(sql, param) > 0;
        }
    }

}