using app_qlKhachSan.DAL;
using app_qlKhachSan.DTO;
using System;
using System.Data;

namespace app_qlKhachSan.BUS
{
    public class DatPhongBUS
    {
        DatPhongDAL dal = new DatPhongDAL();
        DatPhongDAL datPhongDAL = new DatPhongDAL();


        // ================= INSERT =================

        public int Insert(DatPhongDTO dp)
        {
            return dal.Insert(dp);
        }


        // ================= GET DANH SÁCH =================

        public DataTable GetDanhSach()
        {
            return dal.GetDanhSach();
        }


        // ================= UPDATE TRẠNG THÁI =================

        public int UpdateTrangThai(long maDatPhong,
                                  string trangThai)
        {
            return dal.UpdateTrangThai(
                   maDatPhong,
                   trangThai);
        }


        // ================= DELETE =================

        public int Delete(string maDatPhong)
        {
            return dal.Delete(maDatPhong);
        }


        // ================= UPDATE =================

        public int Update(DatPhongDTO dp)
        {
            return dal.Update(dp);
        }
        public bool UpdateThongTin(
    string maDatPhong,
    string maPhong,
    string maKhachHang,
    DateTime ngayNhan,
    DateTime ngayTra
)
        {
            return datPhongDAL.UpdateThongTin(
                maDatPhong,
                maPhong,
                maKhachHang,
                ngayNhan,
                ngayTra
            );
        }
        public DataTable GetPhongDangO()
        {
            return dal.GetPhongDangO();
        }
        public decimal GetTienPhong(long maDatPhong)
        {
            return dal.GetTienPhong(maDatPhong);
        }
        public DataRow GetThongTinThanhToan(long maDatPhong)
        {
            return dal.GetThongTinThanhToan(maDatPhong);
        }
        public string GetMaPhongByMaDatPhong(long maDatPhong)
        {
            return dal.GetMaPhongByMaDatPhong(maDatPhong);
        }
    }
}