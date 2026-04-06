using app_qlKhachSan.DTO;
using System;
using System.Data;

public class PhongBUS
{
    PhongDAL dal = new PhongDAL();

    public DataTable GetPhong()
    {
        return dal.GetAllPhong();
    }

    public DataTable TimPhong(string keyword)
    {
        return dal.TimPhong(keyword);
    }

    public bool UpdatePhong(string maPhong,
                        string soPhong,
                        string maLoaiPhong,
                        string trangThai)
    {
        if (string.IsNullOrWhiteSpace(soPhong))
            throw new Exception("Số phòng không được rỗng");

        if (string.IsNullOrWhiteSpace(trangThai))
            throw new Exception("Chưa chọn trạng thái");

        return dal.UpdatePhong(maPhong,
                               soPhong,
                               maLoaiPhong,
                               trangThai);
    }

    public bool DeletePhong(int maPhong)
    {
        return dal.DeletePhong(maPhong);
    }

    public bool InsertPhong(PhongDTO p)
    {
        if (string.IsNullOrWhiteSpace(p.SoPhong))
            throw new Exception("Số phòng không được rỗng");

        if (string.IsNullOrWhiteSpace(p.MaLoaiPhong))
            throw new Exception("Chưa chọn loại phòng");

        if (string.IsNullOrWhiteSpace(p.TrangThai))
            throw new Exception("Chưa chọn trạng thái");

        return dal.InsertPhong(p);
    }


    // ================= THÊM PHẦN NÀY =================

    public DataTable GetPhongTrong()
    {
        return dal.GetPhongTrong();
    }

    public string GetMaLoaiPhong(string maPhong)
    {
        return dal.GetMaLoaiPhong(maPhong);
    }

    public void UpdateTrangThai(string maPhong,
                                string trangThai)
    {
        dal.UpdateTrangThai(maPhong,
                            trangThai);
    }

    public string GetMaDatPhongMoiNhat()
    {
        return dal.GetMaDatPhongMoiNhat();
    }
    public DataTable GetDanhSach()
    {
        return dal.GetAllPhong();
    }

}