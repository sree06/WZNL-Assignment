using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace WZNLFramework
{
    public class WidgetClass
    {
        WebDriverWait wait;

        public void ClickOnInformationIcon()
        {
            var btnCurrentAge = wait.Until(d =>
            {
                return Browser.webDriver.FindElement(By.XPath("//div//label[contains(text(),'Current age')]/ancestor::div[@class='field-row']//i/parent::button"));
            });
            btnCurrentAge.Click();
        }

        public bool validateProjectionEnabled()
        {
            var btnProjection = Browser.webDriver.FindElement(By.CssSelector("button[ng-click='ctrl.showResultsPanel()']"));
            if (btnProjection.Enabled)
            {
                return true;
            }
            return false;
        }

        public void RiskProfileSelection(string prfileOption)
        {
            var divRiskProfile = Browser.webDriver.FindElement(By.ClassName("wpnib-field-risk-profile"));
            var profileOption = divRiskProfile.FindElement(By.CssSelector("input[ng-click='select()'][value='" + prfileOption + "']"));
            var executor = (IJavaScriptExecutor)Browser.webDriver;
            executor.ExecuteScript("arguments[0].click();", profileOption);
        }

        public void VoluntaryContribution(string voluntaryContribution, string frequency)
        {
            var divVoluntaryContributions = Browser.webDriver.FindElement(By.ClassName("wpnib-field-voluntary-contributions"));
            var txtVoluntaryContributions= divVoluntaryContributions.FindElement(By.CssSelector("input[ng-model='displayModel']"));
            //var frequencySelect = divVoluntaryContributions.FindElement(By.CssSelector("li[ng-click='select()'][value='" + frequency + "'"));
            txtVoluntaryContributions.Clear();
            txtVoluntaryContributions.SendKeys(voluntaryContribution);
            txtVoluntaryContributions.SendKeys(Keys.Enter);
            var freSelect = divVoluntaryContributions.FindElement(By.CssSelector("div[ng-click='toggle()']"));
            var executor = (IJavaScriptExecutor)Browser.webDriver;
            executor.ExecuteScript("arguments[0].click();", freSelect);
            var frequencySelect = divVoluntaryContributions.FindElement(By.CssSelector("li[ng-click='select()'][value='" + frequency + "'"));
            executor.ExecuteScript("arguments[0].click();", frequencySelect);
        }

        public void SavingsGoalPostRetirement(string savingsPostRetd)
        {
            var divSavingsPostRetd = Browser.webDriver.FindElement(By.ClassName("wpnib-field-savings-goal"));
            var txtSavingsPostRetd = divSavingsPostRetd.FindElement(By.CssSelector("input[ng-model='displayModel']"));
            txtSavingsPostRetd.Clear();
            txtSavingsPostRetd.SendKeys(savingsPostRetd);
            txtSavingsPostRetd.SendKeys(Keys.Enter);
        }

        public void EnterCurrentBalance(string balance)
        {
            var divCurrentBalance = Browser.webDriver.FindElement(By.ClassName("wpnib-field-kiwi-saver-balance"));
            var txtCurrentBalance = divCurrentBalance.FindElement(By.CssSelector("input[ng-model='displayModel']"));
            txtCurrentBalance.Clear();
            txtCurrentBalance.SendKeys(balance);
            txtCurrentBalance.SendKeys(Keys.Enter);
        }

        public void PrescribedInvestorRate(string investorRate)
        {
            var divPrescribedIntRate = Browser.webDriver.FindElement(By.ClassName("wpnib-field-pir-rate"));
            var pirSelect = divPrescribedIntRate.FindElement(By.CssSelector("div[ng-click='toggle()']"));
            var executor = (IJavaScriptExecutor)Browser.webDriver;
            executor.ExecuteScript("arguments[0].click();", pirSelect);
            var investorrateselect = divPrescribedIntRate.FindElement(By.CssSelector("li[ng-click='select()'][value='" + investorRate + "'"));
            executor.ExecuteScript("arguments[0].click();", investorrateselect);
        }

        public void SetKiwiSaverContribution(int kiwiPercentage)
        {
            var divKiwiSavePercentage = Browser.webDriver.FindElement(By.ClassName("wpnib-field-kiwisaver-member-contribution"));
            var inputOption = divKiwiSavePercentage.FindElement(By.CssSelector("input[ng-click='select()'][value='" + kiwiPercentage + "']"));
            inputOption.Click();
        }

        public string GetHelpInformationText()
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
            var divCurrentAge = wait.Until(d =>
            {
                return Browser.webDriver.FindElement(By.ClassName("wpnib-field-current-age"));
            });
            var divHelpInformation = divCurrentAge.FindElement(By.ClassName("message-row"));
            var textelement = divHelpInformation.FindElement(By.TagName("p"));
            return textelement.Text;
        }

        public void EnterAgeDetails(string age)
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
            var ageText = wait.Until(d =>
            {
                return Browser.webDriver.FindElement(By.CssSelector("input[ng-model='displayModel']"));
            });
                
            
            ageText.Clear();
            ageText.SendKeys(age);
            ageText.SendKeys(Keys.Enter);

        }

        public void SelectEmploymentStatus(string employeeStatus)
        {
            wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(10));
            var selectControl = wait.Until(d =>
            {
                return Browser.webDriver.FindElement(By.CssSelector("div[ng-click='toggle()']"));
            });
            Browser.webDriver.SwitchTo().ActiveElement();
            //selectControl.Click();
            var executor = (IJavaScriptExecutor)Browser.webDriver;
            executor.ExecuteScript("arguments[0].click();", selectControl);
            //SelectElement select = new SelectElement(selectControl);
            //select.SelectByText("Employed");
            var liEmployed = wait.Until(d =>
            {
                return Browser.webDriver.FindElement(By.CssSelector("li[ng-click='select()'][value='"+employeeStatus+"'"));
            });
            executor.ExecuteScript("arguments[0].click();", liEmployed);
        }

        public void SetAnnualIncome(string income)
        {
            var divIncomeControl = Browser.webDriver.FindElement(By.ClassName("wpnib-field-annual-income"));
            var incomeControl = divIncomeControl.FindElement(By.CssSelector("input[ng-model='displayModel']"));
            incomeControl.Clear();
            incomeControl.SendKeys(income);
            incomeControl.SendKeys(Keys.Enter);


        }
    }
}
