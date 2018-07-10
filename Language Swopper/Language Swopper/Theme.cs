using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Swopper
{
    public class Theme
    {
        public string Name { get { return name; } }
        private string name;

        #region Main
        public string MainForeColor { get { return mainForeColor; } }
        private string mainForeColor;
        public string MainBackColor { get { return mainBackColor; } }
        private string mainBackColor;
        #endregion
        #region Text
        public string TextForeColor { get { return textForeColor; } }
        private string textForeColor;
        public string TextBackColor { get { return textBackColor; } }
        private string textBackColor;
        #endregion
        #region Menu
        public string MenuForeColor { get { return menuForeColor; } }
        private string menuForeColor;
        public string MenuBackColor { get { return menuBackColor; } }
        private string menuBackColor;
        public string MenuHoverForeColor { get { return menuHoverForeColor; } }
        private string menuHoverForeColor;
        public string MenuHoverBackColor { get { return menuHoverBackColor; } }
        private string menuHoverBackColor;
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
                        mainForeColor = item.Value;
                        break;
                    case Property.MainBackColor:
                        mainBackColor = item.Value;
                        break;
                    case Property.TextForeColor:
                        textForeColor = item.Value;
                        break;
                    case Property.TextBackColor:
                        textBackColor = item.Value;
                        break;
                    case Property.MenuForeColor:
                        menuForeColor = item.Value;
                        break;
                    case Property.MenuBackColor:
                        menuBackColor = item.Value;
                        break;
                    case Property.MenuHoverForeColor:
                        menuForeColor = item.Value;
                        break;
                    case Property.MenuHoverBackColor:
                        menuBackColor = item.Value;
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
            MenuBackColor
            MenuHoverForeColor,
            MenuHoverBackColor
        }
    }
}
