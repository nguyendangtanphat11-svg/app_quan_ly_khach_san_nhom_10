using System.Data;
using System.Data.SqlClient;
using app_qlKhachSan.DAL;

public class DonPhongDAL
{
    public DataTable GetDonPhongCanDon()
    {
        string sql = @"
        SELECT
            dp.MaDonPhong,
            dp.MaPhong,
            p.SoPhong,
            dp.TrangThai,
            dp.NgayTao,
            dp.MaNhanVien,
            dp.GhiChu
        FROM DonPhong dp
        JOIN Phong p 
            ON dp.MaPhong = p.MaPhong
        WHERE dp.NgayHoanThanh IS NULL
        ORDER BY dp.NgayTao DESC
        ";

        return DBHelper.ExecuteQuery(sql);
    }

    public bool NhanDon(int maDonPhong, int maNhanVien)
    {
        string updateDonPhong = @"
        UPDATE DonPhong
        SET 
            MaNhanVien = @p0,
            TrangThai = N'ĐANG DỌN'
        WHERE MaDonPhong = @p1
        ";

        bool result1 =
        DBHelper.ExecuteNonQuery(updateDonPhong,
        new SqlParameter[]
        {
            new SqlParameter("@p0", maNhanVien),
            new SqlParameter("@p1", maDonPhong)
        }) > 0;


        string updatePhong = @"
        UPDATE Phong
        SET TrangThai = N'ĐANG DỌN'
        WHERE MaPhong =
        (
            SELECT MaPhong
            FROM DonPhong
            WHERE MaDonPhong = @p0
        )
        ";

        bool result2 =
        DBHelper.ExecuteNonQuery(updatePhong,
        new SqlParameter[]
        {
            new SqlParameter("@p0", maDonPhong)
        }) > 0;


        return result1 && result2;
    }

    public bool HoanThanhDon(int maDonPhong, string ghiChu)
    {
        string updateDonPhong = @"
        UPDATE DonPhong
        SET 
            TrangThai = N'HOÀN THÀNH',
            NgayHoanThanh = GETDATE(),
            GhiChu = @p0
        WHERE MaDonPhong = @p1
        ";

        bool result1 =
        DBHelper.ExecuteNonQuery(updateDonPhong,
        new SqlParameter[]
        {
            new SqlParameter("@p0", ghiChu),
            new SqlParameter("@p1", maDonPhong)
        }) > 0;


        string updatePhong = @"
        UPDATE Phong
        SET TrangThai = N'TRỐNG'
        WHERE MaPhong =
        (
            SELECT MaPhong
            FROM DonPhong
            WHERE MaDonPhong = @p0
        )
        ";

        bool result2 =
        DBHelper.ExecuteNonQuery(updatePhong,
        new SqlParameter[]
        {
            new SqlParameter("@p0", maDonPhong)
        }) > 0;


        return result1 && result2;
    }
    public bool TaoDonPhong(string maPhong)
    {
        string sql = @"
    INSERT INTO DonPhong
    (
        MaPhong,
        TrangThai,
        NgayTao
    )
    VALUES
    (
        @MaPhong,
        N'CẦN DỌN',
        GETDATE()
    )";

        return DBHelper.ExecuteNonQuery(
            sql,
            new SqlParameter[]
            {
            new SqlParameter("@MaPhong", maPhong)
            }
        ) > 0;
    }
    
}