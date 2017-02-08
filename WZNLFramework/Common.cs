using System;
using System.Xml;

namespace WZNLFramework
{
    public static class Common
    {
        public static string GetDataFromXML(string XMLPath,string path)
        {
            string value = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(XMLPath);
                value = doc.SelectSingleNode(path).InnerText.ToString();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }   
            return value;
        }
    }
}
