using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using FakeEmailPageObject;

namespace WebDriverTask
{
    [TestClass]
    public class WD03_CheckRecievedMail
    {
        private WebDriver webDriver = new EdgeDriver();
        private By messagesLocator = By.Id("nav-mail"); //mail button locator
        private By firstMailFromListLocator = By.XPath("/html/body/div[4]/div[2]/div/div[3]/div/div[2]" +
                "/div/div[5]/div/div[2]/div/div[2]/div/div[3]/div/div[2]/div/div[2]/div/div[1]" +
                "/div/table/tbody[2]/tr[1]"); // first email from mail list 
        private By recievedSubjectLocator = By.ClassName("listSubject");
        private By senderLocator = By.ClassName("GCSDBRWBGUB");
        private By senderNameLocator = By.XPath(".//div[@title]");
        private By contentTextLocator = By.CssSelector("div.GCSDBRWBGQC.mail-html-content");


        [TestMethod]
        [DataRow("kataradania@mailfence.com", "IOIupv3z5NelJqjftwEA")]
        public void IsUnreadMailTest(string recieverLogin, string recieverPassword)
        {
            //arrange
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
            LoginPage loginPage = new LoginPage(webDriver);

            //act
            loginPage.SignIn();
            loginPage.LoginFull(recieverLogin, recieverPassword);//reciever login           
            webDriver.FindElement(messagesLocator).Click();
            IWebElement firstEmail = webDriver.FindElement(firstMailFromListLocator);

            //assert
            Assert.IsTrue(firstEmail.GetAttribute("class").Contains("listUnread"));
        }

        [TestMethod]
        [DataRow("kataradania@mailfence.com", "IOIupv3z5NelJqjftwEA", "sendSubject", "Neon Ovich", "sendMessage")]
        public void MailContentTest(string recieverLogin, string recieverPassword, string recievedSubject,
            string senderName, string recievedText)
        {
            //arrange
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
            LoginPage loginPage = new LoginPage(webDriver);
            MailPage mailPage = new MailPage(webDriver);

            //act
            loginPage.SignIn();
            loginPage.LoginFull(recieverLogin, recieverPassword);//reciever login           
            webDriver.FindElement(messagesLocator).Click();
            mailPage.OpenLastEmail();
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            Thread.Sleep(3000);
            IWebElement firstEmailSubject = webDriver.FindElement(recievedSubjectLocator); // first email subject
            IWebElement firstEmailSender = webDriver.FindElement(senderLocator).FindElement(senderNameLocator); // first email sender
            IWebElement firstEmailContentText = webDriver.FindElement(contentTextLocator);

            //assert
            Assert.AreEqual(firstEmailSubject.GetAttribute("title"), recievedSubject);
            Assert.AreEqual(firstEmailSender.GetAttribute("title").Trim(), senderName);
            Assert.IsTrue(firstEmailContentText.Text.StartsWith(recievedText)); //auto signature of mailfence
        }
    }
}
