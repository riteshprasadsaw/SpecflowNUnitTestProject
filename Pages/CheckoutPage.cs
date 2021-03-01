using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowNUnitTestProject.Extentions;
using System;
using System.Collections.Generic;
using System.Text;

/**
 * @author: Ritesh Saw
 *	
 *	01-03-2021
 */

namespace SpecflowNUnitTestProject.Pages
{
    public class CheckoutPage:PageObject
    {
        private readonly IWebDriver _driver;
       

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        //WebElements

        IWebElement checkout => _driver.FindElement(By.XPath("//*[@id='cart_contents_container']/div/div[2]/a[2]"));
        IWebElement firstName => _driver.FindElement(By.Id("first-name"));
        IWebElement lastName => _driver.FindElement(By.Id("last-name"));
        IWebElement postalCode => _driver.FindElement(By.Id("postal-code"));

        IWebElement continueButton => _driver.FindElement(By.XPath("//*[@id='checkout_info_container']/div/form/div[2]/input"));

        IWebElement finishButton => _driver.FindElement(By.XPath(" //*[@id='checkout_summary_container']/div/div[2]/div[8]/a[2]"));

        IWebElement successCheckoutMessage => _driver.FindElement(By.ClassName("complete-header"));

        IWebElement burgerButton => _driver.FindElement(By.Id("react-burger-menu-btn"));

        IWebElement logoutLink => _driver.FindElement(By.Id("logout_sidebar_link"));


        //Methods
       
        public void AddUserDetails(String firstname, String lastname, String zip)
        {
            firstName.SendKeys(firstname);
            lastName.SendKeys(lastname);
            postalCode.SendKeys(zip);

            continueButton.Click();
            finishButton.Click();

        }

        public void successMessageValidation()
        {
          
            Assert.AreEqual(successCheckoutMessage.Text, "THANK YOU FOR YOUR ORDER");

        }

        public void logoutFromApplication()
        {
            burgerButton.Click();
            Extension.WaitForEnabled(logoutLink);
            logoutLink.Click();
          
        }

    }
}
