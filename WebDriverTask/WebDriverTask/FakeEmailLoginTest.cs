using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using FakeEmailPageObject;

namespace WebDriverTask
{
    [TestClass]
    public class FakeEmailLoginTests
    {
        WebDriver webDriver = new EdgeDriver();

        [TestInitialize]
        public void TestInitialize()
        {
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
        }        

        [TestMethod, Priority(01)]
        [DataRow("","", "Mailfence | Log in to Mailfence")]
        public void EmptyLoginTest(string login, string password, string actual)
        {
            //arrange
            LoginPage loginPage = new LoginPage(webDriver);
            
            //act 
            loginPage.SignIn();
            loginPage.typeLogin(login);
            loginPage.TypePassword(password);
            loginPage.SubmitLogin();
          
            //assert 
            Assert.AreEqual(webDriver.Title, actual);
        }

        [TestMethod, Priority(03)]
        [DataRow("wefwwef@mailfence.com", "qwerty1234", "Mailfence | Log in to Mailfence")]
        public void WrongLoginTest(string login, string password, string actual)
        {
            //arrange
            LoginPage loginPage = new LoginPage(webDriver);

            //act 
            loginPage.SignIn();
            loginPage.typeLogin(login);
            loginPage.TypePassword(password);
            loginPage.SubmitLogin();

            //assert 
            Assert.AreEqual(webDriver.Title, actual);
        }

        [TestMethod, Priority(02)]
        [DataRow("", "", "Mailfence")]
        public void LoginTest(string login, string password, string actual)
        {
            //arrange
            LoginPage loginPage = new LoginPage(webDriver);

            //act 
            loginPage.SignIn();
            loginPage.typeLogin(login);
            loginPage.TypePassword(password);
            loginPage.SubmitLogin();

            //assert 
            Assert.AreEqual(webDriver.Title, actual);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            webDriver.Quit();
        }
    }
}