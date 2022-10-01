using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask
{
    public class CloudCalculator
    {
        private WebDriver driver;
        private WebDriverWait wait;
        private By EstimatedCostLocator = By.XPath("//*[@class='ng-binding' and contains(text(), 'Total Estimated Cost:')]");

        private IWebElement AppFrame => driver.FindElement(By.XPath("//*[@id='cloud-site']/devsite-iframe/iframe"));
        private IWebElement CalculatorFrame => driver.FindElement(By.XPath("//*/iframe[@id='myFrame']"));
        private IWebElement ComputeEngineButton => driver.FindElement(By.XPath("//*[@class='name ng-binding' and contains(text(), 'Compute Engine')]"));
        private IWebElement NumberOfInstancesTextBox => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.quantity']"));
        private IWebElement OperatingSystemMenu => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.os']"));
        private IWebElement ProvisionModelMenu => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.class']"));
        private IWebElement SeriesMenu => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.series']"));
        private IWebElement MachineTypeMenu => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.instance']"));
        private IWebElement AddGPUCheckBox => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.addGPUs']"));
        private IWebElement SelectGPUTypeMenu => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.gpuType']"));
        private IWebElement NumberOfGPUMenu => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.gpuCount']"));
        private IWebElement LocalSSDMenu => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.ssd']"));
        private IWebElement DatacenterMenu => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.location']"));
        private IWebElement CommitedUsageMenu => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.cud']"));
        private IWebElement AddToEstimateButton => driver.FindElement(By.XPath("//*[@ng-click='listingCtrl.addComputeServer(ComputeEngineForm);']"));
        private IWebElement EmailQuoteButton => driver.FindElement(By.Id("email_quote"));
        private IWebElement EmailTexBox => driver.FindElement(By.XPath("//input[@ng-model='emailQuote.user.email']"));
        private IWebElement SendButton => driver.FindElement(By.XPath("//button[contains(text(), 'Send Email')]"));

        public CloudCalculator(WebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
        }

        public CloudCalculator ComputeEngine(Engine engine) //there should be credentials in argument
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            driver.SwitchTo().Frame(AppFrame);
            driver.SwitchTo().Frame(CalculatorFrame);
            ComputeEngineButton.Click();
            NumberOfInstancesTextBox.SendKeys(engine.numberOfInstances);
            OperatingSystemMenu.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(engine.operatingSystemSelector))).Click();
            ProvisionModelMenu.Click();
            driver.FindElement(engine.provisionModelSelector).Click();
            driver.ExecuteScript("arguments[0].scrollIntoView(true);", NumberOfInstancesTextBox);
            SeriesMenu.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(engine.seriesSelector))).Click();
            MachineTypeMenu.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(engine.machineTypeSelector))).Click();
            AddGPUCheckBox.Click();
            SelectGPUTypeMenu.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(engine.selectGPUTypeSelector))).Click();
            NumberOfGPUMenu.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(engine.numberOfGPUSelector))).Click();
            driver.ExecuteScript("arguments[0].scrollIntoView(true);", NumberOfGPUMenu);
            LocalSSDMenu.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(engine.localSSDSelector))).Click();
            DatacenterMenu.Click(); ;
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(engine.datacenterSelector))).Click();
            CommitedUsageMenu.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(engine.commitUsageSelector))).Click();
            return this;
        }

        public CloudCalculator AddToEstimate()
        {
            AddToEstimateButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            return this;
        }

        public CloudCalculator SendEstimateToEmail()
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.SwitchTo().Frame(AppFrame);
            driver.SwitchTo().Frame(CalculatorFrame);
            EmailQuoteButton.Click();
            EmailTexBox.SendKeys(Keys.Control + 'v');
            driver.ExecuteScript("arguments[0].scrollIntoView(true);", SendButton);
            wait.Until(ExpectedConditions.ElementToBeClickable(SendButton)).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            return this;
        }

        public string GetCost()
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.SwitchTo().Frame(AppFrame);
            driver.SwitchTo().Frame(CalculatorFrame);
            return driver.FindElement(EstimatedCostLocator).Text;
        }
    }
}
