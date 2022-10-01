using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using FakeEmailPageObject;

namespace WebDriverTask
{
    /// <summary>
    /// Question about design
    /// what would be better, create different methods in page object for any action (such as check),
    /// or i can use Selenium driver possibilities right here in test?
    /// </summary>
    [TestClass]
    public class CheckRecievedMailTests
    {
        private WebDriver webDriver = new EdgeDriver();

        [TestInitialize]
        public void TestInitialize()
        {
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
        }

        [TestMethod]
        [DataRow("", "")]
        public void IsUnreadMailTest(string recieverLogin, string recieverPassword)
        {
            //arrange
            LoginPage loginPage = new LoginPage(webDriver);
            MailPage mailPage = new MailPage(webDriver);

            //act
            loginPage.SignIn();
            loginPage.LoginFull(recieverLogin, recieverPassword). //reciever login
                Messages.Click();
            IWebElement firstEmail = mailPage.FirstRecievedEmail;

            //assert
            Assert.IsTrue(firstEmail.GetAttribute("class").Contains("listUnread"));
        }

        [TestMethod]
        [DataRow("", "", "sendSubject", "Neon Ovich", "sendMessage")]
        public void MailContentTest(string recieverLogin, string recieverPassword, string recievedSubject,
            string senderName, string recievedText)
        {
            //arrange
            LoginPage loginPage = new LoginPage(webDriver);
            MailPage mailPage = new MailPage(webDriver);

            //act
            loginPage.SignIn();
            loginPage.LoginFull(recieverLogin, recieverPassword).Messages.Click();//reciever login           
            mailPage.OpenLastEmail();
            Thread.Sleep(3000);
            IWebElement firstEmailSubject = mailPage.SentSubject; // first email subject
            IWebElement firstEmailSender = mailPage.SenderName; // first email sender
            IWebElement firstEmailContentText = mailPage.EmailContent;

            //assert
            Assert.AreEqual(firstEmailSubject.GetAttribute("title"), recievedSubject);
            Assert.AreEqual(firstEmailSender.GetAttribute("title").Trim(), senderName);
            Assert.IsTrue(firstEmailContentText.Text.StartsWith(recievedText)); //auto signature of mailfence
        }

        [TestCleanup]
        public void TestCleanup()
        {
            webDriver.Quit();
        }
    }
}
