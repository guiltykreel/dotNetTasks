using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Locators
{
    /// <summary>
    /// Поместить локаторы в переменные
    /// Локаторы должны однозначно указывать на элемент
    /// </summary>
    public class Program
    {
        private static void Main()

        { 
            IWebDriver webDriver = new EdgeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://www.bbc.com/sport");

            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0,0,10);

            //Locators
            
            string acceptCookiesButtonLocator = "button.fc-button.fc-cta-consent.fc-primary-button"; // accept cookies by XPath
            string findSearchFieldLocator = "//div[@role = 'search']"; // field "Search" by XPath
            string buttonMore = "More";

            var acceptCookies = webDriver.FindElement(By.CssSelector(acceptCookiesButtonLocator));
            acceptCookies.Click();

            /*
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            IWebElement findMoreButton = webDriver.FindElement(By.LinkText(buttonMore));
            findMoreButton.Click();
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            IWebElement findAllSportsButton = webDriver.FindElement(By.LinkText("Full Sports A-Z"));
            findAllSportsButton.Click();
            

            IWebElement findSearchField = webDriver.FindElement(By.XPath(findSearchFieldLocator));
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);

            findSearchField.Click();
            */

            string bbcIconLocator = "BBC Homepage";
            var bbcIcon = webDriver.FindElements(By.LinkText(bbcIconLocator));
            foreach (var item in bbcIcon)
            {
                item.GetCssValue("name");
            }

            webDriver.Quit();
        }
    }
}