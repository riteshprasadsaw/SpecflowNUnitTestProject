using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNUnitTestProject
{
    using BoDi;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
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
            string username = Hooks.Hooks.config.SourceLabs_Username;
            string _authkey = Hooks.Hooks.config.SourceLabs_AccessKey;

            switch (browser.ToUpperInvariant())
            {
                case "CHROME":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("start-maximized");

                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(options);
                    return driver;

                case "REMOTE":
                    ChromeOptions options1 = new ChromeOptions();
                    options1.AddAdditionalCapability("browserstack.debug", "true");
                    options1.AddAdditionalCapability("build", "1.0");
                    options1.AddAdditionalCapability("browserName", "Chrome");
                    options1.AddAdditionalCapability("platform", "Windows 10");
                    options1.AddAdditionalCapability("version", "49.0");
                    options1.AddAdditionalCapability("screenResolution", "1280x800");
                    options1.AddAdditionalCapability("username", username);
                    options1.AddAdditionalCapability("accessKey", _authkey);
                    options1.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
                    driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options1);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    return driver;

                default:
                    throw new ArgumentException($"Browser not yet implemented: {browser}");
            }
        }
    }
}
