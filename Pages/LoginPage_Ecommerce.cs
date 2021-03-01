using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

/**
 * @author: Ritesh Saw
 *	
 *	01-03-2021
 */

namespace SpecflowNUnitTestProject.Pages
{
    class LoginPage_Ecommerce : PageObject
    {
        private readonly IWebDriver _driver;

        public LoginPage_Ecommerce(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
        //Web-Elements*/

        public IWebElement userName => _driver.FindElement(By.Id("user-name"));
        public IWebElement passWord => _driver.FindElement(By.Id("password"));
        public IWebElement loginButton => _driver.FindElement(By.Id("login-button"));

        //Methods

        public void ClickLogin() => loginButton.Click();
       
        public void EnterCredentials(String Username, String Password)
        {        
            userName.SendKeys(Username);
            passWord.SendKeys(Password);
           
        }

        public void GoToEcommerceApplication()
        {
            Navigate( Hooks.Hooks.config.Ecommerce_Url);
        }

        public void EnterUserDetailsInLoginFileds(String Username, String Password)
        {
            GoToEcommerceApplication();
            EnterCredentials(Username, Password);
         
        }
        public void ClickLoginButton()
        {
        
            ClickLogin();
        }

        public void validateLoginPage()
        {
            Assert.IsTrue(validatePageSourceContains("login-button"));
            
        }
    }
}
