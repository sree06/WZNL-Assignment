using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZNLFramework
{
    public static class Pages
    {
        public static class HomePage
        {
            static string url="http://www.westpac.co.nz";

            public static void Goto()
            {
                Browser.Goto(url);
                throw new NotImplementedException();
            }
        }
    }
}
