using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using FakeEmailPageObject;

namespace WebDriverTask
{
    [TestClass]
    public class ReplyTest
    {
        WebDriver webDriver = new EdgeDriver();
        private By currentUsernameLocator = By.ClassName("GCSDBRWBME");
        private string nickname;

        [TestInitialize]
        public void TestInitialize()
        {
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
        }

        [TestMethod]
        [DataRow("","", "",
            "", "Vasilii")]
        public void SendReplyTest(string replayerLogin, string replayerPassword, string recieverLogin, 
            string recieverPassword, string sendNickname)
        {
            //assert
            LoginPage loginPage = new LoginPage(webDriver);
            MailPage mailPage = new MailPage(webDriver);

            //act
            loginPage.SignIn();
            loginPage.LoginFull(replayerLogin,replayerPassword);
            mailPage.SendAnswer(sendNickname); //send answer with new nickname 
            mailPage.Logout();
            loginPage.LoginFull(recieverLogin, recieverPassword);
            mailPage.OpenLastEmail();
            IWebElement firstEmailContentText = mailPage.EmailContent;
            nickname = firstEmailContentText.Text.Remove(7); //recieve new nickname
            mailPage.UserSettings();
            mailPage.ChageUserNickname(nickname);
            Thread.Sleep(3000); // bad case but ImplicitWait doesent work

            //assert
            Assert.AreEqual(webDriver.FindElement(currentUsernameLocator).Text, nickname);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            webDriver.Quit();
        }
    }
}
