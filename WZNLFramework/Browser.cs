using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace WZNLFramework
{
    public static class Browser
    {
        static FirefoxDriverService drService = FirefoxDriverService.CreateDefaultService(@"C:\Users\PersonalPC\Documents\Visual Studio 2015\Projects\WZNLAssignments\Drivers");
        public static IWebDriver webDriver = new FirefoxDriver(drService);
        
        public static void Goto(string url)
        {

            webDriver.Url = url;         
        }

        public static void CloseBrowser()
        {
            webDriver.Quit();
        }
        public static void WaitforDOMstatecompletion()
        {
            IWait<IWebDriver> wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}