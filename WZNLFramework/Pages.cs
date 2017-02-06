using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZNLFramework
{
    public static class Pages
    {
        public static HomePage HomePage
        {
            get
            {
                var home = new HomePage();
                return home; 
            }
        }

        public static WidgetClass WidgetClass
        {
            get
            {
                var widget = new WidgetClass();
                return widget;
            }

        }
    }
    
}
