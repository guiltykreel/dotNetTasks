using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask
{
    public class GoogleCloud
    {
        private string _url = "https://cloud.google.com/";
        private WebDriver driver;
        private WebDriverWait wait;
        private By searchButtonLocator = By.ClassName("devsite-searchbox");
        //private By searchLocator= By.CssSelector("div.devsite-search-container.devsite-search-query");
        private By searchLocator = By.ClassName("devsite-search-field");
        private By calculatorRefLocator = By.LinkText("Google Cloud Pricing Calculator");//"https://cloud.google.com/products/calculator
        
        public IWebElement SearchButton => driver.FindElement(searchButtonLocator);
        public IWebElement CookieNotification => driver.FindElement(By.XPath("//devsite-snackbar[@type='cookie-notification']/div"));
        public IWebElement AcceptCookies => driver.FindElement(By.XPath("//button[@class='devsite-snackbar-action']"));
       
        public GoogleCloud(WebDriver driver)
        {
            this.driver = driver;
        }

        public GoogleCloud openPage()
        {
            driver.Navigate().GoToUrl(_url);
            driver.Manage().Window.Maximize();
            return this;
        }

        public GoogleCloud Search(string searchRequest)
        {
            SearchButton.Click();
            driver.FindElement(searchLocator).SendKeys(searchRequest + Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 3);
            return this;
        }

        public CloudCalculator OpenCalculator()
        {
            driver.FindElement(calculatorRefLocator).Click();
            return new CloudCalculator(driver);
        }

        public GoogleCloud AllowCookies()
        {
            AcceptCookies.Click();
            return this;
        }
    }
}
