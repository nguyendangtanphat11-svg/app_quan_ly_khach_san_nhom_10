using System.Data;
using app_qlKhachSan.DAL;

public class DonPhongDAL
{
    // ================= LOAD DANH SÁCH CẦN DỌN =================

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


    // ================= NHẬN DỌN =================

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
            DBHelper.Execute(updateDonPhong,
            maNhanVien,
            maDonPhong);


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
            DBHelper.Execute(updatePhong,
            maDonPhong);


        return result1 && result2;
    }


    // ================= HOÀN THÀNH =================

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
            DBHelper.Execute(updateDonPhong,
            ghiChu,
            maDonPhong);


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
            DBHelper.Execute(updatePhong,
            maDonPhong);


        return result1 && result2;
    }
}