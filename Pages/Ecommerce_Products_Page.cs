using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SpecflowNUnitTestProject.Pages
{
    class Ecommerce_Products_Page : PageObject
    {
        private readonly IWebDriver _driver;

        public Ecommerce_Products_Page(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }


        //Web Elements
      
        IWebElement productPage => _driver.FindElement(By.ClassName("product_label"));
        IWebElement product1 => _driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div[1]/div[3]/button"));
        IWebElement product2 => _driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div[2]/div[3]/button"));
        IWebElement cart => _driver.FindElement(By.XPath(" //*[@id='shopping_cart_container']/a"));
        
        
        //Methods

        public void AddTwoProductsInCart(String productName1, String productName2)
        {
            System.Threading.Thread.Sleep(2300);

            product1.Click();
            product2.Click();
            cart.Click();

        }

        

        public void validateProductsPage()
        {
          
            Assert.AreEqual(productPage.Text, "Products");
        }
    }
}
