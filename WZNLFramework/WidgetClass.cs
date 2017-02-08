using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace WZNLFramework
{
    /// <summary>
    /// Class defined for methods/properties in the Calculator widget.
    /// </summary>
    public class WidgetClass
    {
        WebDriverWait wait;
        /// <summary>
        /// Method to access the information icon for the Current Age of the user.
        /// </summary>
        public void ClickOnInformationIcon()
        {
            wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(10));
            var btnCurrentAge = wait.Until(d =>
            {
               return Browser.webDriver.FindElement(By.XPath("//div//label[contains(text(),'Current age')]/ancestor::div[@class='field-row']//i"));
            });
            btnCurrentAge.Click();
        }

        /// <summary>
        /// Method to verify if the Retirement Projects are enabled or not.
        /// </summary>
        /// <returns></returns>
        public bool validateProjectionEnabled()
        {
            var btnProjection = Browser.webDriver.FindElement(By.CssSelector("button[ng-click='ctrl.showResultsPanel()']"));
            if (btnProjection.Enabled)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// To fill in risk profile details for a particular user.
        /// </summary>
        /// <param name="prfileOption"></param>
        public void RiskProfileSelection(string prfileOption)
        {
            var divRiskProfile = Browser.webDriver.FindElement(By.ClassName("wpnib-field-risk-profile"));
            var profileOption = divRiskProfile.FindElement(By.CssSelector("input[ng-click='select()'][value='" + prfileOption + "']"));
            var executor = (IJavaScriptExecutor)Browser.webDriver;
            executor.ExecuteScript("arguments[0].click();", profileOption);
        }

        /// <summary>
        /// Voluntary contribution and the frequency of it.
        /// </summary>
        /// <param name="voluntaryContribution"></param>
        /// <param name="frequency"></param>
        public void VoluntaryContribution(string voluntaryContribution, string frequency)
        {
            var divVoluntaryContributions = Browser.webDriver.FindElement(By.ClassName("wpnib-field-voluntary-contributions"));
            var txtVoluntaryContributions = divVoluntaryContributions.FindElement(By.CssSelector("input[ng-model='displayModel']"));
            txtVoluntaryContributions.Clear();
            txtVoluntaryContributions.SendKeys(voluntaryContribution);
            txtVoluntaryContributions.SendKeys(Keys.Enter);
            var freSelect = divVoluntaryContributions.FindElement(By.CssSelector("div[ng-click='toggle()']"));
            var executor = (IJavaScriptExecutor)Browser.webDriver;
            executor.ExecuteScript("arguments[0].click();", freSelect);
            var frequencySelect = divVoluntaryContributions.FindElement(By.CssSelector("li[ng-click='select()'][value='" + frequency + "'"));
            executor.ExecuteScript("arguments[0].click();", frequencySelect);
        }

        /// <summary>
        /// Savings expected post retirement.
        /// </summary>
        /// <param name="savingsPostRetd"></param>
        public void SavingsGoalPostRetirement(string savingsPostRetd)
        {
            var divSavingsPostRetd = Browser.webDriver.FindElement(By.ClassName("wpnib-field-savings-goal"));
            var txtSavingsPostRetd = divSavingsPostRetd.FindElement(By.CssSelector("input[ng-model='displayModel']"));
            txtSavingsPostRetd.Clear();
            txtSavingsPostRetd.SendKeys(savingsPostRetd);
            txtSavingsPostRetd.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Current Balance for the current user.
        /// </summary>
        /// <param name="balance"></param>
        public void EnterCurrentBalance(string balance)
        {
            var divCurrentBalance = Browser.webDriver.FindElement(By.ClassName("wpnib-field-kiwi-saver-balance"));
            var txtCurrentBalance = divCurrentBalance.FindElement(By.CssSelector("input[ng-model='displayModel']"));
            txtCurrentBalance.Clear();
            txtCurrentBalance.SendKeys(balance);
            txtCurrentBalance.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Prescribed investor rate.
        /// </summary>
        /// <param name="investorRate"></param>
        public void PrescribedInvestorRate(string investorRate)
        {
            var divPrescribedIntRate = Browser.webDriver.FindElement(By.ClassName("wpnib-field-pir-rate"));
            var pirSelect = divPrescribedIntRate.FindElement(By.CssSelector("div[ng-click='toggle()']"));
            var executor = (IJavaScriptExecutor)Browser.webDriver;
            executor.ExecuteScript("arguments[0].click();", pirSelect);
            var investorrateselect = divPrescribedIntRate.FindElement(By.CssSelector("li[ng-click='select()'][value='" + investorRate + "'"));
            executor.ExecuteScript("arguments[0].click();", investorrateselect);
        }

        /// <summary>
        /// Methods to populate the Kiwi save contribution.
        /// </summary>
        /// <param name="kiwiPercentage"></param>
        public void SetKiwiSaverContribution(string kiwiPercentage)
        {
            var divKiwiSavePercentage = Browser.webDriver.FindElement(By.ClassName("wpnib-field-kiwisaver-member-contribution"));
            var inputOption = divKiwiSavePercentage.FindElement(By.CssSelector("input[ng-click='select()'][value='" + kiwiPercentage + "']"));
            inputOption.Click();
        }

        /// <summary>
        /// Fetch information for the div of the Current Age.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method to store in details of the Age
        /// </summary>
        /// <param name="age"></param>
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

        /// <summary>
        /// Method to set the employment status.
        /// </summary>
        /// <param name="employeeStatus"></param>
        public void SelectEmploymentStatus(string employeeStatus)
        {
            wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(10));
            var selectControl = wait.Until(d =>
            {
                return Browser.webDriver.FindElement(By.CssSelector("div[ng-click='toggle()']"));
            });
            Browser.webDriver.SwitchTo().ActiveElement();
            var executor = (IJavaScriptExecutor)Browser.webDriver;
            executor.ExecuteScript("arguments[0].click();", selectControl);
            var liEmployed = wait.Until(d =>
            {
                return Browser.webDriver.FindElement(By.CssSelector("li[ng-click='select()'][value='" + employeeStatus + "'"));
            });
            executor.ExecuteScript("arguments[0].click();", liEmployed);
        }

        /// <summary>
        /// To set annual income for the user.
        /// </summary>
        /// <param name="income"></param>
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
