using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace FakeEmailPageObject
{
    public class Program
    {
        public static void Main()
        {
            string login = "neon.ovich@mailfence.com";
            string password = "sLaDCIRpK7bqBFurhVve";

            WebDriver webDriver = new EdgeDriver();
            LoginPage loginPage = new LoginPage(webDriver);
            MailPage mailPage = new MailPage(webDriver);
            
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            loginPage.SignIn();
            loginPage.LoginFull(login, password); // login to mail service
            mailPage.UserSettings();
            mailPage.ChageUserNickname("Neon");

            webDriver.Quit();
        }
    }
}