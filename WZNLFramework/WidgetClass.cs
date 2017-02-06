using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WZNLFramework
{
    public class WidgetClass
    {
        WebDriverWait wait;
        public void ClickOnInformationicon()
        {
            wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(10));
            var embeddedCalculator = wait.Until(d =>
              {
                  return Browser.webDriver.FindElement(By.Id("calculator-embed"));

              });
            var frameSource = wait.Until(d =>
            {
                return embeddedCalculator.FindElement(By.TagName("iframe"));

            });
            
            Browser.webDriver.SwitchTo().Frame(frameSource);
            var divCurrentAge = wait.Until(d =>
            {
                return Browser.webDriver.FindElement(By.ClassName("wpnib-field-current-age"));
            });
            var btnCurrentAge = divCurrentAge.FindElement(By.XPath("//button[@type='button']"));
            var icon = btnCurrentAge.FindElement(By.ClassName("icon"));
            icon.Click();
           
        }
    }
}
