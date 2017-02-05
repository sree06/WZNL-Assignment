using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace WZNLFramework
{
    public static class Browser
    {
        static IWebDriver webDriver = new FirefoxDriver();

        internal static void Goto(string url)
        {
            webDriver.Url = url;
        }
    }
}