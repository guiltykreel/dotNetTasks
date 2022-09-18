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
            webDriver.Manage().Window.Maximize();
            
            webDriver.Navigate().GoToUrl("https://mailfence.com/");
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);

            LoginPage loginPage = new LoginPage(webDriver);
            /*
            loginPage.SignIn();
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);

            string loginPageTitle = webDriver.Title;

            loginPage.typeLogin(login);
            loginPage.typePassword(password);
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            loginPage.submitLogin();

            SendEmail sendEmail = new SendEmail(webDriver, webDriver.Url);
            sendEmail.SendMessage("email", "subject", "emailtext");
            */
            loginPage.SignIn();
            loginPage.LoginFull(login, password); // login to mail service

            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);

            By messagesLocator = By.Id("nav-mail"); // messages button locator
            By allMailsLocator = By.ClassName("GCSDBRWBGUB"); // all mails table

            //string senderName = "'Олег Русевич  '"; 
            //string loc = @"//div[@title=" + senderName + "]"; //works
            //By mailLocator = By.XPath(loc); // check sender name
            By firstMailFromListLocator = By.XPath("/html/body/div[4]/div[2]/div/div[3]/div/div[2]" +
                "/div/div[5]/div/div[2]/div/div[2]/div/div[3]/div/div[2]/div/div[2]/div/div[1]" +
                "/div/table/tbody[2]/tr[1]"); // first email from mail list 
            string subjectText = "2"; //
            By subjectLocator = By.CssSelector("div.listSubject");
            By senderLocator = By.ClassName("GCSDBRWBGUB");
            By senderTextLocator = By.XPath(".//div[@title]");
            //By mailContentLocator = By.XPath(".//div[@dir='ltr']");
            By mailContentLocator = By.CssSelector("div.GCSDBRWBGQC.mail-html-content");
            
            //By contentTextLocator = By.CssSelector("GCSDBRWBGQC mail-html-content");

            //webDriver.FindElement(messagesLocator).Click();
            //webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);

            //string firstEmailClassName = webDriver.FindElement(firstMailFromListLocator).GetAttribute("class"); 
            //bool isUnread = firstEmailClassName.Contains("listUnread");
            
            //IWebElement firstMailElement = webDriver.FindElement(firstMailFromListLocator);
            //string subText = firstMailElement.FindElement(subjectLocator).GetAttribute("title");

            //IWebElement sender = firstMailElement.FindElement(senderLocator).FindElement(senderTextLocator);
            //string senderText = sender.GetAttribute("title");
            //firstMailElement.Click();

            //IWebElement textElement = webDriver.FindElement(mailContentLocator);

            //string text = textElement.Text;
            MailPage mailPage = new MailPage(webDriver);
            //mailPage.SendAnswer("asd");
            //mailPage.OpenLastEmail();
            //string mailtext = webDriver.FindElement(mailContentLocator).Text.Remove(7);
            //string[] splitedMailText = webDriver.FindElement(mailContentLocator).Text.Split('\u005c');
            mailPage.UserSettings();
            mailPage.ChageUserNickname("Neon");

            webDriver.Quit();
        }
    }
}