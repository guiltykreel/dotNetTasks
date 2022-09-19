using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using FakeEmailPageObject;

namespace WebDriverTask
{
    [TestClass]
    public class WD01_FakeEmailLoginTest
    {
        WebDriver webDriver = new EdgeDriver();

        [TestMethod]
        [DataRow("","", "Mailfence | Log in to Mailfence")]
        public void FELT02_EmptyLoginTest(string login, string password, string actual)
        {
            //arrange          
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
            LoginPage loginPage = new LoginPage(webDriver);

            //act 
            loginPage.SignIn();
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            loginPage.typeLogin(login);
            loginPage.typePassword(password);
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            loginPage.submitLogin();
          
            //assert 
            Assert.AreEqual(webDriver.Title, actual);
        }

        [TestMethod]
        [DataRow("wefwwef@mailfence.com", "qwerty1234", "Mailfence | Log in to Mailfence")]
        public void FELT01_WrongLoginTest(string login, string password, string actual)
        {
            //arrange
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
            LoginPage loginPage = new LoginPage(webDriver);

            //act 
            loginPage.SignIn();
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            loginPage.typeLogin(login);
            loginPage.typePassword(password);
            loginPage.submitLogin();

            //assert 
            Assert.AreEqual(webDriver.Title, actual);
        }

        [TestMethod]
        [DataRow("neon.ovich@mailfence.com", "sLaDCIRpK7bqBFurhVve", "Mailfence")]
        public void FELT03_LoginTest(string login, string password, string actual)
        {
            //arrange
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
            LoginPage loginPage = new LoginPage(webDriver);

            //act 
            loginPage.SignIn();
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            loginPage.typeLogin(login);
            loginPage.typePassword(password);
            loginPage.submitLogin();
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);

            //assert 
            Assert.AreEqual(webDriver.Title, actual);
        }
    }
}