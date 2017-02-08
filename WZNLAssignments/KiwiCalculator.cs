using System;
using WZNLFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace WZNLAssignments.Tests
{
    [TestClass]
    public class KiwiCalculator
    {
        public static string url;
        public static string xmlPath;
        public static string browserType;
        [TestInitialize]
        public void TestInitialize()
        {
            url= ConfigurationManager.AppSettings["portalurl"].ToString();
            xmlPath = ConfigurationManager.AppSettings["testdataxml"].ToString();
            browserType= ConfigurationManager.AppSettings["browser"].ToString();
            
        }
        [TestMethod, Description("The below test to to click on the information icon for the Age of the user")]
        public void Validate_information_Age()
        {
            Pages.HomePage.Goto(url);

            Pages.HomePage.NavigateToKiwiCalculator();

            Pages.WidgetClass.ClickOnInformationIcon();
            Assert.AreEqual("This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.", Pages.WidgetClass.GetHelpInformationText());

        }
        [TestMethod, Description("The following test validates if an user employed,is able to calculate retirement projections")]
        public void Validate_RetirementProjections_Employed()
        {
            Pages.HomePage.Goto(url);
            Pages.HomePage.NavigateToKiwiCalculator();
            Pages.WidgetClass.EnterAgeDetails(Common.GetDataFromXML(xmlPath, "Testdata/employed/age"));
            Pages.WidgetClass.SelectEmploymentStatus(Common.GetDataFromXML(xmlPath, "Testdata/employed/employeestatus"));
            Pages.WidgetClass.SetAnnualIncome(Common.GetDataFromXML(xmlPath, "Testdata/employed/annualincome"));
            Pages.WidgetClass.SetKiwiSaverContribution(Common.GetDataFromXML(xmlPath, "Testdata/employed/kiwisavercontribution"));
            Pages.WidgetClass.PrescribedInvestorRate(Common.GetDataFromXML(xmlPath, "Testdata/employed/PrescribedInvestorRate"));
            Pages.WidgetClass.RiskProfileSelection(Common.GetDataFromXML(xmlPath, "Testdata/employed/RiskProfile"));
            Assert.IsTrue(Pages.WidgetClass.validateProjectionEnabled());
        }
        [TestMethod,Description("Test to verify the scenario for Self Employed")]
        public void Validate_RetirementProjections_SelfEmployed()
        {
            Pages.HomePage.Goto(url);
            Pages.HomePage.NavigateToKiwiCalculator();
            Pages.WidgetClass.EnterAgeDetails(Common.GetDataFromXML(xmlPath, "Testdata/selfemployed/age"));
            Pages.WidgetClass.SelectEmploymentStatus(Common.GetDataFromXML(xmlPath, "Testdata/selfemployed/employeestatus"));
            Pages.WidgetClass.PrescribedInvestorRate(Common.GetDataFromXML(xmlPath, "Testdata/selfemployed/PrescribedInvestorRate"));
            Pages.WidgetClass.EnterCurrentBalance(Common.GetDataFromXML(xmlPath, "Testdata/selfemployed/currentBalance"));
            Pages.WidgetClass.VoluntaryContribution(Common.GetDataFromXML(xmlPath, "Testdata/selfemployed/voluntaryfund"), Common.GetDataFromXML(xmlPath, "Testdata/selfemployed/frequency"));
            Pages.WidgetClass.RiskProfileSelection(Common.GetDataFromXML(xmlPath, "Testdata/selfemployed/RiskProfile"));
            Pages.WidgetClass.SavingsGoalPostRetirement(Common.GetDataFromXML(xmlPath, "Testdata/selfemployed/SavingsPostRetd"));
            Assert.IsTrue(Pages.WidgetClass.validateProjectionEnabled());
        }
        [TestMethod,Description("Test to verify if the user is able to get the projections for Not Employed category")]
        public void Validate_RetirementProjects_NotEmployed()
        {
            Pages.HomePage.Goto(url);
            Pages.HomePage.NavigateToKiwiCalculator();
            Pages.WidgetClass.EnterAgeDetails(Common.GetDataFromXML(xmlPath, "Testdata/notemployed/age"));
            Pages.WidgetClass.SelectEmploymentStatus(Common.GetDataFromXML(xmlPath, "Testdata/notemployed/employeestatus"));
            Pages.WidgetClass.PrescribedInvestorRate(Common.GetDataFromXML(xmlPath, "Testdata/notemployed/PrescribedInvestorRate"));
            Pages.WidgetClass.EnterCurrentBalance(Common.GetDataFromXML(xmlPath, "Testdata/notemployed/currentBalance"));
            Pages.WidgetClass.VoluntaryContribution(Common.GetDataFromXML(xmlPath, "Testdata/notemployed/voluntaryfund"), Common.GetDataFromXML(xmlPath, "Testdata/notemployed/frequency"));
            Pages.WidgetClass.RiskProfileSelection(Common.GetDataFromXML(xmlPath, "Testdata/notemployed/RiskProfile"));
            Pages.WidgetClass.SavingsGoalPostRetirement(Common.GetDataFromXML(xmlPath, "Testdata/notemployed/SavingsPostRetd"));
            Assert.IsTrue(Pages.WidgetClass.validateProjectionEnabled());
        }
        [TestCleanup]
        public void CloseBrowser()
        {
            Browser.CloseBrowser();
        }
    }
}
