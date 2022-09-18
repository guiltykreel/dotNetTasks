using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace FakeEmailPageObject
{
    public class LoginPage
    {
        private WebDriver driver;
        private By signInButtonLocator = By.Id("signin");//homepage
        private By usernameLocator = By.Name("UserID"); // sign in page 
        private By passwordLocator = By.Name("Password"); //sign in page 
        private By buttonNextLocator = By.ClassName("btn"); // login        

        public LoginPage(WebDriver driver)
        { 
            this.driver = driver;
        }

        public LoginPage SignIn()
        {
            driver.FindElement(signInButtonLocator).Click();
            return this;
        }

        public LoginPage typeLogin(string login)
        { 
            driver.FindElement(usernameLocator).SendKeys(login);
            return this;
        }

        public LoginPage typePassword(string password)
        { 
            driver.FindElement(passwordLocator).SendKeys(password);
            return this;
        }
            
        public LoginPage submitLogin()
        {
            driver.FindElement(buttonNextLocator).Click();
            return this;
        }

        public LoginPage LoginFull(string login, string password)
        {
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            driver.FindElement(usernameLocator).SendKeys(login);
            driver.FindElement(passwordLocator).SendKeys(password);
            driver.FindElement(buttonNextLocator).Click();
            return this;
        }
    }
}
