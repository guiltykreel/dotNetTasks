﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkTask
{
    public class Driver
    {
        private WebDriver driver;

        public WebDriver GetWebDriver()
        {
            if (driver == null)
            {
                switch (Environment.GetEnvironmentVariable("Browser"))
                {
                    case "Chrome" or "chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                }
            }
            return driver;
        }

        public void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
