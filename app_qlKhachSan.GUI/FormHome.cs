using app_qlKhachSan.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace app_qlKhachSan
{
    public partial class FormHome : Form
    {
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
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            mdiProperties.SetBevel(this, false);
            this.WindowState = FormWindowState.Maximized;
        }

        // ================= UI =================

        private void mdiProp()
        {
            mdiProperties.SetBevel(this, false); 

            var client = Controls.OfType<MdiClient>().FirstOrDefault();
            if (client != null)
            {
                client.BackColor = Color.FromArgb(232, 234, 237);
                client.Dock = DockStyle.Fill; // ✔ full form

                // ✔ tự resize khi phóng to / thu nhỏ
                this.Resize += (s, e) =>
                {
                    client.Dock = DockStyle.Fill;

                };
            }
        }

        public void OpenChild(Form child)
        {
            if (currentForm != null)
                currentForm.Close();

            currentForm = child;

            child.MdiParent = this;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            child.Show();
            child.BringToFront(); // 🔥 thêm dòng này
        }

        // ================= MENU ANIMATION =================

        bool seeting_time_tick = false;

        private void seeting_time_Tick(object sender, EventArgs e)
        {
            if (!seeting_time_tick)
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
            if (menu_time_bool)
            {
                menu.SuspendLayout();

                menu.Width -= 20;

                menu.ResumeLayout();
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

                    panel_trangchu.Width =
                    panel_thanhtoan.Width =
                    panel_quanlyphong.Width =
                    panel_quanlykhachhang.Width =
                    panel_hethong.Width =
                    panel_donphong.Width =
                    panel_dichvu.Width =
                    panel_datphong.Width = menu.Width;
                }
            }
        }

        private void icon_menu_Click(object sender, EventArgs e)
        {
            menu_time.Start();
        }

        // ================= BUTTON =================

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
    }
}