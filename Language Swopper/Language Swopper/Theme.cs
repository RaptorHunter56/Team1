using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Language_Swopper
{
    public class Theme
    {
        public string Name { get { return name; } }
        private string name;

        public static string ColorToString(Color color)
        {
            return (color.A.ToString("X2") + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2"));
        }
        public static Color StringToColor(string input)
        {
            return Color.FromArgb(Int32.Parse(input, NumberStyles.HexNumber));
        }

        #region Main
        public Color MainForeColor { get { return mainForeColor; } }
        private Color mainForeColor;
        public Color MainBackColor { get { return mainBackColor; } }
        private Color mainBackColor;
        #endregion
        #region Text
        public Color TextForeColor { get { return textForeColor; } }
        private Color textForeColor;
        public Color TextBackColor { get { return textBackColor; } }
        private Color textBackColor;
        #endregion
        #region Menu
        public Color MenuForeColor { get { return menuForeColor; } }
        private Color menuForeColor;
        public Color MenuBackColor { get { return menuBackColor; } }
        private Color menuBackColor;
        public Color MenuHoverForeColor { get { return menuHoverForeColor; } }
        private Color menuHoverForeColor;
        public Color MenuHoverBackColor { get { return menuHoverBackColor; } }
        private Color menuHoverBackColor;
        #endregion

        public Theme(string name, string[] properties)
        {
            if (properties.Length != 14) { throw new ArgumentException("String Array Length is Incorrect (string[14]).", "properties"); }
            Dictionary<Property, string> Dproperties = new Dictionary<Property, string>();
            int Set = 0;
            foreach (var item in properties)
            {
                Dproperties.Add((Property)Set, item);
                Set++;
            }
            SetTheme(Dproperties);
            this.name = name;
        }
        public Theme(string name, Dictionary<Property, string> properties)
        {
            SetTheme(properties);
            this.name = name;
        }
        private void SetTheme(Dictionary<Property, string> properties)
        {
            foreach (var item in properties)
            {
                switch (item.Key)
                {
                    case Property.MainForeColor:
                        mainForeColor = StringToColor(item.Value);
                        break;
                    case Property.MainBackColor:
                        mainBackColor = StringToColor(item.Value);
                        break;
                    case Property.TextForeColor:
                        textForeColor = StringToColor(item.Value);
                        break;
                    case Property.TextBackColor:
                        textBackColor = StringToColor(item.Value);
                        break;
                    case Property.MenuForeColor:
                        menuForeColor = StringToColor(item.Value);
                        break;
                    case Property.MenuBackColor:
                        menuBackColor = StringToColor(item.Value);
                        break;
                    case Property.MenuHoverForeColor:
                        menuHoverForeColor = StringToColor(item.Value);
                        break;
                    case Property.MenuHoverBackColor:
                        menuHoverBackColor = StringToColor(item.Value);
                        break;
                    default:
                        break;
                }
            }
        }
        public event EventHandler ThemeRefresh;
        protected virtual void OnThemeRefresh(EventArgs e)
        {
            EventHandler handler = ThemeRefresh;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void EditTheme(Dictionary<Property, string> properties)
        {
            SetTheme(properties);
            OnThemeRefresh(EventArgs.Empty);
        }
        public void EditTheme(Property property, string value)
        {
            Dictionary<Property, string> properties = new Dictionary<Property, string>();
            properties.Add(property, value);
            SetTheme(properties);
            OnThemeRefresh(EventArgs.Empty);
        }

        public enum Property
        {
            MainForeColor,
            MainBackColor,
            TextForeColor,
            TextBackColor,
            MenuForeColor,
            MenuBackColor,
            MenuHoverForeColor,
            MenuHoverBackColor
        }
    }
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        private bool top = false;

        public MyRenderer(bool Top = false)
        {
            top = Top;
        }
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            e.Graphics.FillRectangle(new SolidBrush(((Form1)e.Item.OwnerItem.Owner.Parent).theme.MenuBackColor), rc);
            e.Graphics.DrawLine(new Pen(((Form1)e.Item.OwnerItem.Owner.Parent).theme.MenuForeColor), 2, rc.Height / 2, rc.Width - 2, rc.Height / 2);
        }
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            Brush bc = new SolidBrush(e.Item.BackColor);
            try
            {
                bc = new SolidBrush(((Form1)e.Item.Owner.Parent).theme.MenuBackColor);
                e.Item.ForeColor = ((Form1)e.Item.Owner.Parent).theme.MenuForeColor;
            }
            catch
            {
                try
                {
                    bc = new SolidBrush(((Form1)e.Item.OwnerItem.Owner.Parent).theme.MenuBackColor);
                    e.Item.ForeColor = ((Form1)e.Item.OwnerItem.Owner.Parent).theme.MenuForeColor;
                }
                catch { }
            }
            if (top)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else
                {
                    try
                    {

                        if (e.Item.Tag.ToString() == "Name")
                        {
                            bc = new SolidBrush(e.Item.BackColor);
                            e.Item.ForeColor = ((Form1)e.Item.Owner.Parent).theme.MenuHoverForeColor;
                            //e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
                        }
                        else
                        {
                            bc = new SolidBrush(((Form1)e.Item.Owner.Parent).theme.MenuHoverBackColor);
                            e.Item.ForeColor = ((Form1)e.Item.Owner.Parent).theme.MenuHoverForeColor;
                            //e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
                        }
                    }
                    catch (Exception)
                    {
                        bc = new SolidBrush(((Form1)e.Item.Owner.Parent).theme.MenuHoverBackColor);
                        e.Item.ForeColor = ((Form1)e.Item.Owner.Parent).theme.MenuHoverForeColor;
                        //e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
                    }
                }
            }
            else
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else if (e.Item.OwnerItem != null)
                {
                    if (e.Item.OwnerItem.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                    {
                        bc = new SolidBrush(((Form1)e.Item.OwnerItem.Owner.Parent).theme.MenuHoverBackColor);
                        e.Item.ForeColor = ((Form1)e.Item.OwnerItem.Owner.Parent).theme.MenuHoverForeColor;
                        //e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
                    }
                }
                else
                {
                    //foreach (ToolStripMenuItem Tm_items in menustrp.Items)
                    //{
                    //    Tm_items.DropDownOpened += (sender, args) => {
                    //        MessageBox.Show("Open"); // Perform logic here
                    //    };

                    //}

                    //string tim = e.Item.OwnerItem.GetType().ToString();
                    bc = new SolidBrush(((Form1)e.Item.Owner.Parent).theme.MenuHoverBackColor);
                    e.Item.ForeColor = ((Form1)e.Item.Owner.Parent).theme.MenuHoverForeColor;
                    //e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
                }
            }
            e.Graphics.FillRectangle(bc, rc);
        }
    }
        
}
