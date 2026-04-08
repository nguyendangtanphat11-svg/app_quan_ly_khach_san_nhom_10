using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_qlKhachSan
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }


        private async void frmSplash_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;

            // fade + zoom in
            for (double i = 0; i <= 1; i += 0.05)
            {
                this.Opacity = i;

                picLogo.Width += 4;
                picLogo.Height += 4;

                await Task.Delay(20);
            }

            // giữ logo lâu hơn (3.5 giây)
            await Task.Delay(3500);

            // fade out
            for (double i = 1; i >= 0; i -= 0.05)
            {
                this.Opacity = i;
                await Task.Delay(20);
            }

            this.Hide();

            FormLogin login = new FormLogin();
            login.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
