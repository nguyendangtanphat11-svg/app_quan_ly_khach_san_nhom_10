using System.Data;

public class DonPhongBUS
{
    DonPhongDAL dal = new DonPhongDAL();


    public DataTable GetDonPhongCanDon()
    {
        return dal.GetDonPhongCanDon();
    }


    public bool NhanDon(int maDonPhong, int maNhanVien)
    {
        return dal.NhanDon(maDonPhong, maNhanVien);
    }


    public bool HoanThanhDon(int maDonPhong, string ghiChu)
    {
        return dal.HoanThanhDon(maDonPhong, ghiChu);
    }
    public bool TaoDonPhong(string maPhong)
    {
        return dal.TaoDonPhong(maPhong);
    }

}