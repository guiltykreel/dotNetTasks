using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using FakeEmailPageObject;

namespace WebDriverTask
{
    [TestClass]
    public class WD02_SendEmailTest
    {
        private WebDriver webDriver = new EdgeDriver();
        private string sendToEmail = "kataradania@mailfence.com";
        private By sentTreeLocator = By.Id("treeSend");
        private By sendedSubjectLocator = By.ClassName("listSubject");

        [TestMethod]
        [DataRow("neon.ovich@mailfence.com", "sLaDCIRpK7bqBFurhVve", "sendSubject", "sendMessage")]
        public void SendMailTest(string senderEmail, string senderPassword, string sendSubject, string sendMessage)
        {
            //arrange
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
            LoginPage loginPage = new LoginPage(webDriver);
            MailPage sendEmail = new MailPage(webDriver);

            //act
            loginPage.SignIn();
            loginPage.LoginFull(senderEmail,senderPassword);
            sendEmail.SendMessage(sendToEmail, sendSubject, sendMessage);
            IWebElement sentTree = webDriver.FindElement(sentTreeLocator);
            sentTree.Click();
            IWebElement sendedSubject = webDriver.FindElement(sendedSubjectLocator);

            //assert
            Assert.AreEqual(sendedSubject.GetAttribute("title"), sendSubject);
        }
    }
}
