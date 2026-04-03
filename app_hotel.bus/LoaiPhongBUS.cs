using System;
using System.Data;
using app_qlKhachSan.DTO;

public class LoaiPhongBUS
{
    LoaiPhongDAL dal = new LoaiPhongDAL();

    public DataTable GetLoaiPhong()
    {
        return dal.GetLoaiPhong();
    }

    public bool UpdateLoaiPhong(LoaiPhongDTO lp)
    {
        if (string.IsNullOrWhiteSpace(lp.MaLoaiPhong))
            throw new Exception("Chưa chọn loại phòng");

        if (string.IsNullOrWhiteSpace(lp.TenLoaiPhong))
            throw new Exception("Tên loại phòng không được rỗng");

        return dal.UpdateLoaiPhong(lp);
    }

    public bool DeleteLoaiPhong(string ma)
    {
        if (string.IsNullOrWhiteSpace(ma))
            throw new Exception("Chưa chọn loại phòng");

        return dal.DeleteLoaiPhong(ma);
    }
    public bool InsertLoaiPhong(LoaiPhongDTO lp)
    {
        if (string.IsNullOrWhiteSpace(lp.TenLoaiPhong))
            throw new Exception("Tên loại phòng không được rỗng");

        if (lp.GiaTheoNgay <= 0)
            throw new Exception("Giá theo ngày phải > 0");

        if (lp.GiaTheoGio <= 0)
            throw new Exception("Giá theo giờ phải > 0");

        if (lp.SoNguoiToiDa <= 0)
            throw new Exception("Số người tối đa phải > 0");

        return dal.InsertLoaiPhong(lp);
    }
}