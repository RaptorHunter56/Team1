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
            #region file
            fileToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MainBackColor, NumberStyles.HexNumber));
            fileToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MainForeColor, NumberStyles.HexNumber));

            newToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            newToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            openToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            openToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            saveToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            saveToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            saveAsToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            saveAsToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            printToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            printToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            printPreviewToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            printPreviewToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            exitToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            exitToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));

            toolStripSeparator.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            toolStripSeparator.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            toolStripSeparator1.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            toolStripSeparator1.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            toolStripSeparator2.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            toolStripSeparator2.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            #endregion
            #region file
            editToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MainBackColor, NumberStyles.HexNumber));
            editToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MainForeColor, NumberStyles.HexNumber));

            undoToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            undoToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            redoToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            redoToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            cutToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            cutToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            copyToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            copyToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            pasteToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            pasteToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            selectAllToolStripMenuItem.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            selectAllToolStripMenuItem.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));

            toolStripSeparator3.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            toolStripSeparator3.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            toolStripSeparator4.BackColor = Color.FromArgb(Int32.Parse(theme.MenuHoverBackColor, NumberStyles.HexNumber));
            toolStripSeparator4.ForeColor = Color.FromArgb(Int32.Parse(theme.MenuHoverForeColor, NumberStyles.HexNumber));
            #endregion
        }

        public Form1()
        {
            theme.ThemeRefresh += ThemeRefreshControls;
            InitializeComponent();
            theme.EditTheme(Theme.Property.MainBackColor, "FFFF0000");
            theme.EditTheme(Theme.Property.MenuHoverBackColor, "FFFF0000");
        }

        #region MenuClicks

        #endregion
    }
}
