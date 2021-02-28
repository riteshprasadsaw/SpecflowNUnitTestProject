using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNUnitTestProject.Pages
{
    class CartPage:PageObject
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }


        IWebElement checkout => _driver.FindElement(By.XPath("//*[@id='cart_contents_container']/div/div[2]/a[2]"));
        IWebElement item1Title => _driver.FindElement(By.XPath("//*[@id='item_4_title_link']/div"));
        IWebElement item1Price => _driver.FindElement(By.XPath("//*[@id='cart_contents_container']/div/div[1]/div[3]/div[2]/div[2]/div"));
        IWebElement item2Title => _driver.FindElement(By.XPath("//*[@id='item_0_title_link']/div"));
        IWebElement item2Price => _driver.FindElement(By.XPath("//*[@id='cart_contents_container']/div/div[1]/div[4]/div[2]/div[2]/div"));

        public void checkouttheproducts()
        {
            checkout.Click();
        }

        public void validateCartItemsAndTotalPrice()
        {
            Assert.AreEqual(item1Title.Text, "Sauce Labs Backpack");
            Assert.AreEqual(item2Title.Text, "Sauce Labs Bike Light");
            Assert.AreEqual(item1Price.Text, "29.99");
            Assert.AreEqual(item2Price.Text, "9.99");
          
        }
    }
}
