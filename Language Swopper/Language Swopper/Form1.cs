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
            this.BackColor = Color.FromArgb(Int32.Parse(theme.MainBackColor, NumberStyles.HexNumber));
            this.ForeColor = Color.FromArgb(Int32.Parse(theme.MainForeColor, NumberStyles.HexNumber));
            menuStrip1.BackColor = Color.FromArgb(Int32.Parse(theme.MainBackColor, NumberStyles.HexNumber));
            menuStrip1.ForeColor = Color.FromArgb(Int32.Parse(theme.MainForeColor, NumberStyles.HexNumber));
            menuStrip2.BackColor = Color.FromArgb(Int32.Parse(theme.MainBackColor, NumberStyles.HexNumber));
            menuStrip2.ForeColor = Color.FromArgb(Int32.Parse(theme.MainForeColor, NumberStyles.HexNumber));
            richTextBox1.BackColor = Color.FromArgb(Int32.Parse(theme.TextBackColor, NumberStyles.HexNumber));
            richTextBox1.ForeColor = Color.FromArgb(Int32.Parse(theme.TextForeColor, NumberStyles.HexNumber));
            fileToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuBackColor, NumberStyles.HexNumber));
            fileToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuForeColor, NumberStyles.HexNumber));
            newToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuBackColor, NumberStyles.HexNumber));
            newToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuForeColor, NumberStyles.HexNumber));
        }

        public Form1()
        {
            theme.ThemeRefresh += ThemeRefreshControls;
            InitializeComponent();
            theme.EditTheme(Theme.Property.MainBackColor, "FFFF0000");
        }

        #region MenuClicks

        #endregion
    }
}
