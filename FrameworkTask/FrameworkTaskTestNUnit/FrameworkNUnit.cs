using FrameworkTask;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;

namespace FrameworkTaskTestNUnit
{
    
    public class FrameworkNUnit
    {
        private WebDriver _driver;

        [SetUp]
        public void Setup() => _driver = new Driver().GetWebDriver();

        [Test, Category("Smoke")]
        [TestCase("Google Cloud Platform Pricing Calculator")]
        public void CalculateEstimateCostTest(string search)
        {
            //Assert
            GoogleCloud googleCloud = new GoogleCloud(_driver);
            CloudCalculator cloudCalculator = new CloudCalculator(_driver);
            TempMailPage tempMail = new TempMailPage(_driver);
            Engine engine = new EngineCreator().CreateNewEngine();

            //Act
            googleCloud.openPage().
                AllowCookies().
                Search(search).
                OpenCalculator();
            cloudCalculator.ComputeEngine(engine).
               AddToEstimate();
            tempMail.OpenPage().
                GetTempEmail();
            cloudCalculator.SendEstimateToEmail();
            string cost = cloudCalculator.GetCost().Remove(0, 22);
            string recievedCost = tempMail.GetMailedCost().Remove(0, 24);

            //Assert
            Assert.IsTrue(cost.StartsWith(recievedCost));
        }
    
        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Screenshots");
                Screenshot screenshot = _driver.GetScreenshot();
                string fileName = DateTime.Now.ToString().Replace('.', '_').Replace(' ', '_').Replace(':', '_');
                screenshot.SaveAsFile($"{Directory.GetCurrentDirectory()}\\Screenshots\\{fileName}.jpg", ScreenshotImageFormat.Jpeg);
            }
            _driver.Quit();
        }
    }
}