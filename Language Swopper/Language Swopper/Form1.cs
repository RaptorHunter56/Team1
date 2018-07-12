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
            menuStrip2.BackColor = theme.MenuBackColor;
            menuStrip2.ForeColor = theme.MenuForeColor;
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
            menuStrip2.Renderer = new MyRenderer(true);

            ThemeRefreshControls(this, new EventArgs());
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theme.EditTheme(Theme.Property.MenuHoverBackColor, Theme.ColorToString(Color.Red));
            theme.EditTheme(Theme.Property.MenuBackColor, Theme.ColorToString(Color.Blue));
            theme.EditTheme(Theme.Property.MenuHoverForeColor, Theme.ColorToString(Color.White));
            theme.EditTheme(Theme.Property.MenuForeColor, Theme.ColorToString(Color.White));
        }
    }
}
