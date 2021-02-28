using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNUnitTestProject
{
    using BoDi;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using TechTalk.SpecFlow;
    using WebDriverManager;
    using WebDriverManager.DriverConfigs.Impl;

    [Binding]
    public class DriverFactory
    {
        IWebDriver driver;
        public IWebDriver CreateDriver()
        {
            string browser = Environment.GetEnvironmentVariable("BROWSER") ?? "CHROME";

            switch (browser.ToUpperInvariant())
            {
                case "CHROME":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("start-maximized");

                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(options);
                    return driver;

                default:
                    throw new ArgumentException($"Browser not yet implemented: {browser}");
            }
        }
    }
}
