﻿using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text.RegularExpressions;

namespace FakeEmailPageObject
{
    public class MailPage
    {
        private WebDriver driver;
        private By messagesLocator = By.Id("nav-mail");
        private By newMailLocator = By.Id("mailNewBtn");
        private By mailToTextBoxLocator = By.ClassName("GCSDBRWBML");
        private By subjectLocator = By.Id("mailSubject");
        private By mailTextFrameLocator = By.XPath("//div[@class='GCSDBRWBCGC']/iframe");
        private By mailTextBoxLocator = By.XPath("/html/body");
        private By sendButtonLocator = By.Id("mailSend");
        private By firstMailFromListLocator = By.XPath("//table[@class='GCSDBRWBNT']/tbody[2]/tr[1]"); // first email from mail list 
        private By recievedSubjectLocator = By.ClassName("listSubject");        
        private By controlButtonLocator = By.CssSelector("div.GCSDBRWBO.tbBtn.afterSep.GCSDBRWBCV");
        private By menuButtonLocator = By.ClassName("GCSDBRWBME");
        private By logoutButtonLocator = By.ClassName("GCSDBRWBLQ");
        private By userMenuLocator = By.ClassName("GCSDBRWBME");
        private By settingsButtonLocator = By.ClassName("GCSDBRWBCR");
        private By personalDataLocator = By.XPath("//*[@class='treeItemLabel' and contains(text(), 'Personal data')]"); // 
        private By editPersonalDataLocator = By.CssSelector("div.btn.GCSDBRWBO.editHeaderDefaultBtn");
        private By nameTextBoxLocator = By.ClassName("GCSDBRWBHQ");
        private By SaveButtonLocator = By.CssSelector("div.btn.GCSDBRWBO.editHeaderDefaultBtn"); // it changing 
        private By sentTreeLocator = By.Id("treeSend");
        private By sentSubjectLocator = By.ClassName("listSubject");
        private By senderLocator = By.ClassName("GCSDBRWBGUB");
        private By senderNameLocator = By.XPath(".//div[@title]");
        private By contentTextLocator = By.CssSelector("div.GCSDBRWBGQC.mail-html-content");

        public IWebElement Messages => driver.FindElement(messagesLocator);
        public IWebElement MailTextBox => driver.FindElement(mailTextBoxLocator);
        public IWebElement FirstRecievedEmail => driver.FindElement(firstMailFromListLocator);
        public IWebElement SentSubject => driver.FindElement(sentSubjectLocator);
        public IWebElement SenderName => driver.FindElement(senderLocator).FindElement(senderNameLocator);
        public IWebElement EmailContent => driver.FindElement(contentTextLocator);

        public MailPage(WebDriver driver)//, string url)
        {
            this.driver = driver;
        }

        public MailPage SendMessage(string email, string subjectText, string mailText )
        {           
            driver.FindElement(messagesLocator).Click();
            driver.FindElement(newMailLocator).Click();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            driver.FindElement(mailToTextBoxLocator).SendKeys(email);
            driver.FindElement(subjectLocator).SendKeys(subjectText);
            IWebElement frame = driver.FindElement(mailTextFrameLocator);
            driver.SwitchTo().Frame(frame);
            MailTextBox.SendKeys(mailText);
            driver.SwitchTo().DefaultContent();
            driver.FindElement(sendButtonLocator).Click();
            return this;    
        }

        public MailPage SendAnswer(string replyText)
        {
            driver.FindElement(messagesLocator).Click();
            FirstRecievedEmail.Click();
            driver.FindElement(recievedSubjectLocator).Click(); //open first email from list
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            var control = driver.FindElements(controlButtonLocator);
            foreach (var element in control)
            {
                if (element.GetAttribute("title") == "Reply")
                {
                    element.Click();
                }
            }
            IWebElement frame = driver.FindElement(mailTextFrameLocator);
            driver.SwitchTo().Frame(frame).FindElement(mailTextBoxLocator).SendKeys(replyText);
            driver.SwitchTo().DefaultContent();
            driver.FindElement(sendButtonLocator).Click();
            return this;
        }

        public MailPage OpenLastEmail()
        {
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            driver.FindElement(messagesLocator).Click();
            driver.FindElement(firstMailFromListLocator).Click();
            driver.FindElement(recievedSubjectLocator).Click();
            return this;
        }

        public MailPage Logout()
        {
            driver.FindElement(menuButtonLocator).Click();
            driver.FindElements(logoutButtonLocator).Last().Click();
            return this;
        }

        public MailPage UserSettings()
        {
            driver.FindElement(userMenuLocator).Click();
            driver.FindElement(settingsButtonLocator).Click();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            return this;
        }

        public MailPage ChageUserNickname(string nickname) // changing name because nickname in mailfence is paid
        {
            driver.FindElement(personalDataLocator).Click();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            driver.FindElement(editPersonalDataLocator).Click();
            driver.FindElement(nameTextBoxLocator).Click();
            driver.SwitchTo().ActiveElement().Clear();
            driver.FindElement(nameTextBoxLocator).Click();
            driver.SwitchTo().ActiveElement().SendKeys(nickname);            
            driver.FindElement(SaveButtonLocator).Click(); // new search control buttons
            return this;
        }

        public string GetSentSubject()
        {
            driver.FindElement(sentTreeLocator).Click();
            string subject = driver.FindElement(sentSubjectLocator).GetAttribute("title");
            return subject;
        }
    }
}
