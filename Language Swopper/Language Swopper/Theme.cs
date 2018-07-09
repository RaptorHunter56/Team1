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


        //Main
        public string MainForeGroundColor { get { return name; } }
        private string mainForeGroundColor;
        public string MainBackGroundColor { get { return name; } }
        private string mainBackGroundColor;
        //Text
        public string TextForeGroundColor { get { return name; } }
        private string textForeGroundColor;
        public string TextBackGroundColor { get { return name; } }
        private string textBackGroundColor;
        //Frame
        public string FrameForeGroundColor { get { return name; } }
        private string frameForeGroundColor;
        public string FrameBackGroundColor { get { return name; } }
        private string frameBackGroundColor;
        //ToolBar
        public string ToolBarForeGroundColor { get { return name; } }
        private string toolBarForeGroundColor;
        public string ToolBarBackGroundColor { get { return name; } }
        private string toolBarBackGroundColor;
        //Link
        public string LinkForeGroundColor { get { return name; } }
        private string linkForeGroundColor;
        public string LinkBackGroundColor { get { return name; } }
        private string linkBackGroundColor;
        //Section
        public string SectionForeGroundColor { get { return name; } }
        private string sectionForeGroundColor;
        public string SectionBackGroundColor { get { return name; } }
        private string sectionBackGroundColor;
        //Coment
        public string ComentForeGroundColor { get { return name; } }
        private string comentForeGroundColor;
        public string ComentBackGroundColor { get { return name; } }
        private string comentBackGroundColor;



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
            try { SetTheme(Dproperties); }
            catch (Exception)
            {

                throw;
            }
            this.name = name;
        }

        public Theme(string name, Dictionary<Property, string> properties)
        {
            try { SetTheme(properties); }
            catch (Exception)
            {

                throw;
            }
            this.name = name;
        }

        private void SetTheme(Dictionary<Property, string> properties)
        {

        }

        public void EditTheme(Dictionary<Property, string> properties)
        {

        }

        public void EditTheme(Property property, string value)
        {
            Dictionary<Property, string> properties = new Dictionary<Property, string>();
            properties.Add(property, value);
            EditTheme(properties);
        }

        public enum Property
        {
            MainForeGroundColor,
            MainBackGroundColor,
            TextForeGroundColor,
            TextBackGroundColor,
            FrameForeGroundColor,
            FrameBackGroundColor,
            ToolBarForeGroundColor,
            ToolBarBackGroundColor,
            LinkForeGroundColor,
            LinkBackGroundColor,
            SectionForeGroundColor,
            SectionBackGroundColor,
            ComentForeGroundColor,
            ComentBackGroundColor
        }
    }
}
