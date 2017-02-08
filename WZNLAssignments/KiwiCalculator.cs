using System;
using WZNLFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WZNLAssignments.Tests
{
    [TestClass]
    public class KiwiCalculator
    {
        [TestMethod, Description("The below test to to click on the information icon for the Age of the user")]
        public void Validate_information_Age()
        {
            Pages.HomePage.Goto();

            Pages.HomePage.NavigateToKiwiCalculator();

            Pages.WidgetClass.ClickOnInformationIcon();
            Assert.AreEqual("This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.", Pages.WidgetClass.GetHelpInformationText());

        }
        [TestMethod, Description("The following test validates if an user employed,is able to calculate retirement projections")]
        public void Validate_RetirementProjections_Employed()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.NavigateToKiwiCalculator();
            Pages.WidgetClass.EnterAgeDetails("30");
            Pages.WidgetClass.SelectEmploymentStatus("employed");
            Pages.WidgetClass.SetAnnualIncome("82,000");
            Pages.WidgetClass.SetKiwiSaverContribution(4);
            Pages.WidgetClass.PrescribedInvestorRate("17.5");
            Pages.WidgetClass.RiskProfileSelection("high");
            Assert.IsTrue(Pages.WidgetClass.validateProjectionEnabled());
        }
        [TestMethod,Description("Test to verify the scenario for Self Employed")]
        public void Validate_RetirementProjections_SelfEmployed()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.NavigateToKiwiCalculator();
            Pages.WidgetClass.EnterAgeDetails("45");
            Pages.WidgetClass.SelectEmploymentStatus("self-employed");
            Pages.WidgetClass.PrescribedInvestorRate("17.5");
            Pages.WidgetClass.EnterCurrentBalance("100000");
            Pages.WidgetClass.VoluntaryContribution("90", "fortnight");
            Pages.WidgetClass.RiskProfileSelection("high");
            Pages.WidgetClass.SavingsGoalPostRetirement("290,000");
            Assert.IsTrue(Pages.WidgetClass.validateProjectionEnabled());
        }
        [TestMethod,Description("Test to verify if the user is able to get the projections for Not Employed category")]
        public void Validate_RetirementProjects_NotEmployed()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.NavigateToKiwiCalculator();
            Pages.WidgetClass.EnterAgeDetails("55");
            Pages.WidgetClass.SelectEmploymentStatus("not-employed");
            Pages.WidgetClass.PrescribedInvestorRate("10.5");
            Pages.WidgetClass.EnterCurrentBalance("140000");
            Pages.WidgetClass.VoluntaryContribution("10", "year");
            Pages.WidgetClass.RiskProfileSelection("medium");
            Pages.WidgetClass.SavingsGoalPostRetirement("200,000");
            Assert.IsTrue(Pages.WidgetClass.validateProjectionEnabled());
        }
        [TestCleanup]
        public void CloseBrowser()
        {
            Browser.CloseBrowser();
        }
    }
}
