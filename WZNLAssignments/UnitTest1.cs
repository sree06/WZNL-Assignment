using System;
using WZNLFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WZNLAssignments
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Pages.HomePage.Goto();

            Pages.HomePage.NavigateToKiwiCalculator();
            
            Pages.WidgetClass.ClickOnInformationicon();

        }
        [TestCleanup]
        public void CloseBrowser()
        {
            Browser.CloseBrowser();
        }
    }
}
