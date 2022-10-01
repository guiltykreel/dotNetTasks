using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask
{
    public class TempMailPage
    {
        private string _url = "https://tempmail.plus";
        private WebDriver driver;
        private By costLocator = By.XPath("//*[contains(text(), 'Estimated Monthly Cost:')]");

        private IWebElement RecievedEmail => driver.FindElement(By.ClassName("mail"));
        private IWebElement CopyEmailButton => driver.FindElement(By.Id("pre_copy"));

        public TempMailPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public TempMailPage OpenPage()
        {
            driver.ExecuteScript("window.open()");
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Navigate().GoToUrl(_url);
            return this;
        }

        public TempMailPage GetTempEmail()
        {
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 3);
            CopyEmailButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            return this;
        }

        public string GetMailedCost()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("mail"))).Click();
            RecievedEmail.Click();
            driver.ExecuteScript("arguments[0].scrollIntoView(true);", RecievedEmail);
            return driver.FindElement(costLocator).Text;
        }
    }
}
