using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace app_qlKhachSan.Helpers
{
    public static class mdiProperties
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x200;

        // 👇 HÀM PHẢI CÓ
        public static bool SetBevel(Form form, bool show)
        {
            foreach (Control c in form.Controls)
            {
                if (c is MdiClient client)
                {
                    int style = GetWindowLong(client.Handle, GWL_EXSTYLE);

                    if (show)
                        style |= WS_EX_CLIENTEDGE;
                    else
                        style &= ~WS_EX_CLIENTEDGE;

                    SetWindowLong(client.Handle, GWL_EXSTYLE, style);
                    return true;
                }
            }
            return false;
        }
    }
}