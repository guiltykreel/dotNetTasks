using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using FakeEmailPageObject;

namespace WebDriverTask
{
    [TestClass]
    public class WD04_ReplyTest
    {
        WebDriver webDriver = new EdgeDriver();
        private By contentTextLocator = By.CssSelector("div.GCSDBRWBGQC.mail-html-content");
        private string nickname;
        private By currentUsernameLocator = By.ClassName("GCSDBRWBME"); 

        [TestMethod]
        [DataRow("kataradania@mailfence.com","IOIupv3z5NelJqjftwEA", "neon.ovich@mailfence.com",
            "sLaDCIRpK7bqBFurhVve", "Vasilii")]
        public void SendReplyTest(string replayerLogin, string replayerPassword, string recieverLogin, 
            string recieverPassword, string sendNickname)
        {
            //assert
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
            LoginPage loginPage = new LoginPage(webDriver);
            MailPage mailPage = new MailPage(webDriver);

            //act
            loginPage.SignIn();
            loginPage.LoginFull(replayerLogin,replayerPassword);
            mailPage.SendAnswer(sendNickname); //send answer with new nickname 
            mailPage.Logout();
            //loginPage.SignIn(); // sometimes redirect to main page, sometimes no...
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            loginPage.LoginFull(recieverLogin, recieverPassword);
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            mailPage.OpenLastEmail();
            IWebElement firstEmailContentText = webDriver.FindElement(contentTextLocator);
            nickname = firstEmailContentText.Text.Remove(7); //recieve new nickname
            mailPage.UserSettings();
            mailPage.ChageUserNickname(nickname);
            Thread.Sleep(3000);

            //assert
            Assert.AreEqual(webDriver.FindElement(currentUsernameLocator).Text, nickname);
        }
    }
}
