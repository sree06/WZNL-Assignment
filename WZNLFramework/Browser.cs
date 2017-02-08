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
        public static IWebDriver webDriver;
        public static string driverlocation;
        public static void LaunchFirefox()
        {
            FirefoxDriverService drService = FirefoxDriverService.CreateDefaultService(driverlocation);
            webDriver = new FirefoxDriver(drService);
         
        }
        public static void Goto(string url)
        {
            webDriver.Url = url;         
        }

        public static void CloseBrowser()
        {
            webDriver.Quit();
        }
       
    }
}