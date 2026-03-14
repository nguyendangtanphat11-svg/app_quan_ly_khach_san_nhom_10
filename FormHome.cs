using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace app_qlKhachSan
{
    public partial class FormHome : Form
    {
        Form_trang_chu trangchu;
        Form_thanh_toan thanhtoan;
        Form_quan_ly_phong quanlyphong;
        Form_quan_ly_khach_hang quanlykhachhang;
        Form_tai_khoan taikhoan;
        Form_don_phong donphong;
        Form_dich_vu dichvu;
        Form_dat_phong datphong;
        Form currentForm = null;
        string ten;
        string sdt;
        string vaitro;





        public FormHome(string ten, string sdt, string vaitro)
        {
            InitializeComponent();
            this.ten = ten;
            this.sdt = sdt;
            this.vaitro = vaitro;
        }
        private string CONNECTION_STRING = @"Data Source=LAPTOP-B6BVDVFI\MSSQLSERVER16;Initial Catalog=HotelManager;Integrated Security=True;";

        private void FormHome_Load(object sender, EventArgs e)
        {
            mdiProp();

        }

        private void hethong_time_Tick(object sender, EventArgs e)
        {

        }
     
        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }
        bool seeting_time_tick = false;
      
        private void seeting_time_Tick(object sender, EventArgs e)
        {
            if (seeting_time_tick == false)
            {
                panel_hethong.Height += 10;
                if (panel_hethong.Height >= 241)
                {
                    seeting_time_tick = true;
                    seeting_time.Stop();
                }

            }
            else
            {
                panel_hethong.Height -= 10;
                if (panel_hethong.Height <= 45)
                {
                    seeting_time_tick = false;
                    seeting_time.Stop();
                }
            }
        }

        private void button_seting_Click(object sender, EventArgs e)
        {
            seeting_time.Start();
        }

        bool menu_time_bool = true;
        private void menu_time_Tick(object sender, EventArgs e)
        {
            if (menu_time_bool == true)
            {
                menu.Width -= 10;
                if (menu.Width <= 63)
                {
                    menu_time_bool = false;
                    menu_time.Stop();
                }
            }
            else
            {
                menu.Width += 10;
                if (menu.Width >= 246)
                {
                    menu_time_bool = true;
                    menu_time.Stop();

                    panel_trangchu.Width = menu.Width;
                    panel_thanhtoan.Width = menu.Width;
                    panel_quanlyphong.Width = menu.Width;
                    panel_quanlykhachhang.Width = menu.Width;
                    panel_hethong.Width = menu.Width;
                    panel_donphong.Width = menu.Width;
                    panel_dichvu.Width = menu.Width;
                    panel_datphong.Width = menu.Width;


                }
            }
        }

        private void icon_menu_Click(object sender, EventArgs e)
        {
            menu_time.Start();
        }
        private void OpenChild(Form child)
        {
          
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = child;
            child.MdiParent = this;
            child.FormBorderStyle = FormBorderStyle.None; 
            child.Dock = DockStyle.Fill;
            child.Show();
        }

    
        private void menu_Paint(object sender, PaintEventArgs e)
        {

        }

       
      
        private void Form_trang_chu(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
        private void Button_trangchu_Click(object sender, EventArgs e)
        {
            OpenChild(new Form_trang_chu(ten, sdt, vaitro));

        }



        private void button_quanlyphong_Click(object sender, EventArgs e)
        {
            OpenChild(new Form_quan_ly_phong());
        }


        private void button_quanlykhachhang_Click(object sender, EventArgs e)
        {
            OpenChild(new Form_quan_ly_khach_hang());
        }
       

        private void button_datphong_Click(object sender, EventArgs e)
        {
            OpenChild(new Form_dat_phong());
        }
       
        private void button_dichvu_Click(object sender, EventArgs e)
        {
            OpenChild(new Form_dich_vu());
        }
       

        private void button_donphong_Click(object sender, EventArgs e)
        {
            OpenChild(new Form_don_phong());
        }
       
        private void button_thanhtoan_Click(object sender, EventArgs e)
        {
            OpenChild(new Form_thanh_toan());
        }
       

        private void button_taikhoan_Click(object sender, EventArgs e)
        {
            OpenChild(new Form_tai_khoan());
        }


        private void FormHome_Load_1(object sender, EventArgs e)
        {

        }
    }

}