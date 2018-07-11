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

        private string ColorToString(Color color)
        {
            return (color.A.ToString("X2") + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2"));
        }
        private Color StringToColor(string input)
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
    
}
