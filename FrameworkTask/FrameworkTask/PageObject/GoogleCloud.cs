using OpenQA.Selenium;

namespace FrameworkTask
{
    public class GoogleCloud
    {
        private string _url = "https://cloud.google.com/";
        private WebDriver driver;
        private By searchButtonLocator = By.ClassName("devsite-searchbox");
        //private By searchLocator= By.CssSelector("div.devsite-search-container.devsite-search-query");
        private By searchLocator = By.ClassName("devsite-search-field");
        private By calculatorRefLocator = By.LinkText("Google Cloud Pricing Calculator");//"https://cloud.google.com/products/calculator

        public GoogleCloud(WebDriver driver)
        {
            this.driver = driver;
        }

        public GoogleCloud openPage()
        {
            driver.Navigate().GoToUrl(_url);
            return this;
        }

        public GoogleCloud Search(string searchRequest)
        {
            driver.FindElement(searchButtonLocator).Click();
            driver.FindElement(searchLocator).SendKeys(searchRequest + Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 3);
            return this;
        }

        public CloudCalculator OpenCalculator()
        {
            driver.FindElement(calculatorRefLocator).Click();
            return new CloudCalculator(driver);
        }
    }
}
