﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask
{
    public class Program
    {
        public static void Main()
        {
            Environment.SetEnvironmentVariable("Browser", "chrome");
            Environment.SetEnvironmentVariable("env", "new");
            string search = "Google Cloud Platform Pricing Calculator";
            WebDriver driver = new Driver().GetWebDriver();
            GoogleCloud googleCloud = new GoogleCloud(driver);
            CloudCalculator cloudCalculator = new CloudCalculator(driver);
            TempMailPage tempMail = new TempMailPage(driver);
            Engine engine = new EngineCreator().CreateNewEngine();

            googleCloud.openPage().
                AllowCookies().
                Search(search).
                OpenCalculator();
            cloudCalculator.ComputeEngine(engine).
               AddToEstimate();
            tempMail.OpenPage().
                GetTempEmail();
            cloudCalculator.SendEstimateToEmail();
            string cost = cloudCalculator.GetCost().Remove(0, 22);
            string recievedCost = tempMail.GetMailedCost().Remove(0, 24);
            //googleCloud.AcceptCookies.Click();
            driver.Quit();



        }
    }
}