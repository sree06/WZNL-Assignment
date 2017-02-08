using System;
using WZNLFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WZNLAssignments.Tests
{
    [TestClass]
    public class KiwiCalculator
    {
        [TestMethod]
        public void TestMethod1()
        {
            Pages.HomePage.Goto();

            Pages.HomePage.NavigateToKiwiCalculator();

            Pages.WidgetClass.ClickOnInformationIcon();
            Assert.AreEqual("This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.", Pages.WidgetClass.GetHelpInformationText());

        }
        [TestMethod]
        public void ValidateAgeEntry()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.NavigateToKiwiCalculator();
            Pages.WidgetClass.EnterAgeDetails("30");
            Pages.WidgetClass.SelectEmploymentStatus();
            Pages.WidgetClass.SetAnnualIncome("82,000");
            Pages.WidgetClass.SetKiwiSaverContribution(4);
            Pages.WidgetClass.PrescribedInvestorRate("17.5");
            Pages.WidgetClass.RiskProfileSelection("high");
            Assert.IsTrue(Pages.WidgetClass.validateProjectionEnabled(),"The control is enabled for projection");
        }
        [TestCleanup]
        public void CloseBrowser()
        {
           Browser.CloseBrowser();
        }
    }
}
