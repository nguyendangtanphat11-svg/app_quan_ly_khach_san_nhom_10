using app_qlKhachSan.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace app_qlKhachSan.DAL
{
    public class DatPhongDAL
    {
        // ================= INSERT =================

        public int Insert(DatPhongDTO dp)
        {
            string sql = @"
            INSERT INTO DatPhong
            (
                MaKhachHang,
                MaPhong,
                NgayNhanPhong,
                NgayTraPhong,
                TrangThai,
                NgayTao,
                GhiChu
            )
            VALUES
            (
                @MaKH,
                @MaPhong,
                @NgayNhan,
                @NgayTra,
                @TrangThai,
                GETDATE(),
                @GhiChu
            )";

            SqlParameter[] param =
            {
                new SqlParameter("@MaKH", dp.MaKhachHang),
                new SqlParameter("@MaPhong", dp.MaPhong),
                new SqlParameter("@NgayNhan", dp.NgayNhanPhong),
                new SqlParameter("@NgayTra", dp.NgayTraPhong),
                new SqlParameter("@TrangThai", dp.TrangThai),
                new SqlParameter("@GhiChu", dp.GhiChu)
            };

            return DBHelper.ExecuteNonQuery(sql, param);
        }


        // ================= GET DANH SÁCH =================

        public DataTable GetDanhSach()
        {
            string sql = "SELECT * FROM DatPhong";

            return DBHelper.ExecuteQuery(sql);
        }


        // ================= UPDATE TRẠNG THÁI =================

        public int UpdateTrangThai(long maDatPhong,
                           string trangThai)
        {
            string sql =
            @"UPDATE DatPhong
      SET TrangThai=@TrangThai
      WHERE MaDatPhong=@MaDatPhong";

            SqlParameter[] param =
            {
        new SqlParameter("@TrangThai", trangThai),
        new SqlParameter("@MaDatPhong", maDatPhong)
    };

            return DBHelper.ExecuteNonQuery(sql, param);
        }


        // ================= DELETE =================

        public int Delete(string maDatPhong)
        {
            string sql =
            @"DELETE FROM DatPhong
              WHERE MaDatPhong=@MaDatPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatPhong",
                                 maDatPhong)
            };

            return DBHelper.ExecuteNonQuery(sql, param);
        }


        // ================= UPDATE THÔNG TIN =================

        public int Update(DatPhongDTO dp)
        {
            string sql =
            @"UPDATE DatPhong
              SET
              MaKhachHang=@MaKH,
              MaPhong=@MaPhong,
              NgayNhanPhong=@NgayNhan,
              NgayTraPhong=@NgayTra,
              GhiChu=@GhiChu
              WHERE MaDatPhong=@MaDatPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@MaKH", dp.MaKhachHang),
                new SqlParameter("@MaPhong", dp.MaPhong),
                new SqlParameter("@NgayNhan", dp.NgayNhanPhong),
                new SqlParameter("@NgayTra", dp.NgayTraPhong),
                new SqlParameter("@GhiChu", dp.GhiChu),
                new SqlParameter("@MaDatPhong", dp.MaDatPhong)
            };

            return DBHelper.ExecuteNonQuery(sql, param);
        }
        public bool UpdateThongTin(
    string maDatPhong,
    string maPhong,
    string maKhachHang,
    DateTime ngayNhan,
    DateTime ngayTra
)
        {
            string sql = @"
        UPDATE DatPhong
        SET MaPhong = @MaPhong,
            MaKhachHang = @MaKhachHang,
            NgayNhanPhong = @NgayNhan,
            NgayTraPhong = @NgayTra
        WHERE MaDatPhong = @MaDatPhong";

            SqlParameter[] parameters =
            {
        new SqlParameter("@MaPhong", maPhong),
        new SqlParameter("@MaKhachHang", maKhachHang),
        new SqlParameter("@NgayNhan", ngayNhan),
        new SqlParameter("@NgayTra", ngayTra),
        new SqlParameter("@MaDatPhong", maDatPhong)
    };

            return DBHelper.ExecuteNonQuery(sql, parameters) > 0;
        }
        public DataTable GetPhongDangO()
        {
            string sql = @"
    SELECT MaDatPhong
    FROM DatPhong
    WHERE TrangThai IN
    (
        N'ĐÃ ĐẶT',
        N'ĐANG Ở'
    )";

            return DBHelper.ExecuteQuery(sql);
        }
        public decimal GetTienPhong(long maDatPhong)
        {
            string sql = @"
    SELECT
    DATEDIFF(DAY, NgayNhanPhong, NgayTraPhong)
    * lp.GiaTheoNgay
    FROM DatPhong dp
    JOIN Phong p
        ON dp.MaPhong = p.MaPhong
    JOIN LoaiPhong lp
        ON p.MaLoaiPhong = lp.MaLoaiPhong
    WHERE dp.MaDatPhong = @MaDatPhong";

            SqlParameter[] param =
            {
        new SqlParameter("@MaDatPhong", maDatPhong)
    };

            object result =
            DBHelper.ExecuteScalar(sql, param);

            return Convert.ToDecimal(result);
        }
        public DataRow GetThongTinThanhToan(long maDatPhong)
        {
            string sql = @"
    SELECT
        dp.MaDatPhong,
        dp.NgayNhanPhong,
        dp.NgayTraPhong,
        p.SoPhong,
        kh.HoTen
    FROM DatPhong dp
    JOIN Phong p
        ON dp.MaPhong = p.MaPhong
    JOIN KhachHang kh
        ON dp.MaKhachHang = kh.MaKhachHang
    WHERE dp.MaDatPhong = @MaDatPhong";

            SqlParameter[] param =
            {
        new SqlParameter("@MaDatPhong", maDatPhong)
    };

            DataTable table =
            DBHelper.ExecuteQuery(sql, param);

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }
        public string GetMaPhongByMaDatPhong(long maDatPhong)
        {
            string sql = @"
    SELECT MaPhong
    FROM DatPhong
    WHERE MaDatPhong = @MaDatPhong";

            SqlParameter[] param =
            {
        new SqlParameter("@MaDatPhong", maDatPhong)
    };

            return DBHelper.ExecuteScalar(sql, param).ToString();
        }

    }

}