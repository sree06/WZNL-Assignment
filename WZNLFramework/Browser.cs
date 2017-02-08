using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace WZNLFramework
{
    public static class Browser
    {
        //static FirefoxDriverService drService = FirefoxDriverService.CreateDefaultService(@"C:\Users\PersonalPC\Documents\Visual Studio 2015\Projects\WZNLAssignments\Drivers");
        //public static IWebDriver webDriver = new FirefoxDriver(drService);
        public static IWebDriver webDriver;
        public static void LaunchFirefox()
        {
            FirefoxDriverService drService = FirefoxDriverService.CreateDefaultService(@"C:\Users\PersonalPC\Documents\Visual Studio 2015\Projects\WZNLAssignments\Drivers");
            webDriver = new FirefoxDriver(drService);
            //webDriver =new InternetExplorerDriver(@"C:\Users\PersonalPC\Documents\Visual Studio 2015\Projects\WZNLAssignments\Drivers");
            //return webDriver;
        }
        public static void LaunchChrome()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("test-type");
            webDriver = new ChromeDriver(@"C:\Users\PersonalPC\Documents\Visual Studio 2015\Projects\WZNLAssignments\Drivers", option);
        }
        public static void Goto(string url)
        {
            //ChromeOptions option = new ChromeOptions();
            //option.AddArgument
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