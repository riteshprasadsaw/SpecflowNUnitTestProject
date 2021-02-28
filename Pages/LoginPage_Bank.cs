using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowNUnitTestProject.Pages
{
    class LoginPage_Bank:PageObject
    {

        private readonly IWebDriver _driver;

        public LoginPage_Bank(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement userName => _driver.FindElement(By.Id("username"));
        public IWebElement passWord => _driver.FindElement(By.Id("password"));
        public IWebElement loginButton => _driver.FindElement(By.Id("login-button"));

        //Methods

        public void ClickLogin() => loginButton.Click();
       
        public void EnterCredentials(String Username, String Password)
        {        
            userName.SendKeys(Username);
            passWord.SendKeys(Password);
           
        }

        public void GoToBankApplication()
        {
            Navigate(Hooks.Hooks.config.Bank_Url);
        }

        public void LoginToApplication(String Username, String Password)
        {
            
            EnterCredentials(Username, Password);
            ClickLogin();
        }
    }
}
