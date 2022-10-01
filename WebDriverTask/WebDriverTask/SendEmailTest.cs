using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using FakeEmailPageObject;

namespace WebDriverTask
{
    [TestClass]
    public class SendEmailTest
    {
        private WebDriver webDriver = new EdgeDriver();
        private string sendToEmail = "";
        private string sendedSubject;

        [TestInitialize]
        public void TestInitialize()
        {
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
        }

        [TestMethod]
        [DataRow("", "", "sendSubject", "sendMessage")]
        public void SendMailTest(string senderEmail, string senderPassword, string sendSubject, string sendMessage)
        {
            //arrange
            LoginPage loginPage = new LoginPage(webDriver);
            
            //act
            loginPage.SignIn();
            sendedSubject = loginPage.LoginFull(senderEmail,senderPassword).
                SendMessage(sendToEmail, sendSubject, sendMessage).
                GetSentSubject();

            //assert
            Assert.AreEqual(sendedSubject, sendSubject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            webDriver.Quit();
        }
    }
}
