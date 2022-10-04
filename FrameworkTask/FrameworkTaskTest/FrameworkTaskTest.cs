namespace FrameworkTaskTest
{
    [TestClass]
    public class FrameworkTaskTest
    {
        private WebDriver _driver;
        private static TestContext _testContext;

        public TestContext Context { get; set; }
        
        [ClassInitialize]
        public static void SetupClass(TestContext context) 
        { 
            _testContext = context; 
        }

        [TestInitialize]
        public void TestInitialize() => _driver = new Driver().GetWebDriver();

        [TestMethod, TestCategory("All"), TestCategory("Smoke")]
        [DataRow("Google Cloud Platform Pricing Calculator")]
        public void CalculateEstimateCostTest(string search)
        {
            //Assert
            GoogleCloud googleCloud = new GoogleCloud(_driver);
            CloudCalculator cloudCalculator = new CloudCalculator(_driver);
            TempMailPage tempMail = new TempMailPage(_driver);
            Engine engine = new EngineCreator().CreateNewEngine();

            //Act
            googleCloud.openPage().
                //AllowCookies().
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

        [TestCleanup]
        public void TestCleanup()
        {
            if (_testContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Screenshots");
                Screenshot screenshot = _driver.GetScreenshot();
                string fileName = DateTime.Now.ToString("yyyy'-‘MM’-‘dd’T’HH’:’mm’:’ss");
                screenshot.SaveAsFile($"{Directory.GetCurrentDirectory()}\\Screenshots\\{fileName}.jpg", ScreenshotImageFormat.Jpeg);
            }
            _driver.Quit();
        }
    }
}