using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Language_Swopper
{
    public partial class Form1 : Form
    {
        private void ThemeRefreshControls(object sender, EventArgs e)
        {
            menuStrip1.BackColor = theme.MenuBackColor;
            menuStrip1.ForeColor = theme.MenuForeColor;
            TitleStrip.BackColor = theme.MenuBackColor;
            TitleStrip.ForeColor = theme.MenuForeColor;
            foreach (Control item in this.Controls)
            {
                item.Refresh();
            }
        }

        public Form1()
        {
            theme.ThemeRefresh += ThemeRefreshControls;
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            TitleStrip.Renderer = new MyRenderer(true);

            ThemeRefreshControls(this, new EventArgs());
            
        }

        #region Menu
        private bool TogleMove = false;
        private Point point;
        private void menuStrip2_MouseDown(object sender, MouseEventArgs e)
        {
            TogleMove = true;
            point = new Point(e.X, e.Y);
        }
        private void menuStrip2_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogleMove)
            {
                if (this.WindowState == FormWindowState.Normal) this.SetDesktopLocation(MousePosition.X - point.X, MousePosition.Y - point.Y);
                else
                {
                    decimal PreSet = (decimal)point.X / (decimal)this.Width;
                    this.WindowState = FormWindowState.Normal;
                    int PreSetHalf = (int)(PreSet * this.Width);
                    point = new Point(PreSetHalf, e.Y);
                    this.SetDesktopLocation(MousePosition.X - PreSetHalf, 10);
                }
            }
        }
        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                panel1.Visible = true;
                panel2.Visible = true;
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
            }
        }
        private void menuStrip2_MouseUp(object sender, MouseEventArgs e)
        {
            TogleMove = false;
        }
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            //TogleMove = false;
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theme.EditTheme(Theme.Property.MenuHoverBackColor, Theme.ColorToString(Color.Red));
            theme.EditTheme(Theme.Property.MenuBackColor, Theme.ColorToString(Color.Blue));
            theme.EditTheme(Theme.Property.MenuHoverForeColor, Theme.ColorToString(Color.White));
            theme.EditTheme(Theme.Property.MenuForeColor, Theme.ColorToString(Color.White));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) WindowState = FormWindowState.Maximized;
            else WindowState = FormWindowState.Normal;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            menuStrip2_MouseMove(TitleStrip, new MouseEventArgs(new MouseButtons(), 0, 0, 0, 0));
        }
    }
}
