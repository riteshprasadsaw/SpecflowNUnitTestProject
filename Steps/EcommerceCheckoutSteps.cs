using OpenQA.Selenium;
using SpecflowNUnitTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


/**
 * @author: Ritesh Saw
 *	
 *	01-03-2021
 */

namespace SpecflowNUnitTestProject.Steps
{
    [Binding]
    public class EcommerceCheckoutSteps   
    {
        LoginPage_Ecommerce loginPage;
        Ecommerce_Products_Page productpage;
        CheckoutPage checkoutPage;
        CartPage cartPage;


        public EcommerceCheckoutSteps(IWebDriver driver)
        {
            loginPage = new LoginPage_Ecommerce(driver);
            productpage = new Ecommerce_Products_Page(driver);
            checkoutPage = new CheckoutPage(driver);
            cartPage = new CartPage(driver);
        }

        [Given(@"user is on Ecommerce Login page")]
        public void GivenUserIsOnEcommerceLoginPage()
        {
           
            loginPage.GoToEcommerceApplication();
            
        }
        
        [Given(@"enters valid credentials")]
        public void GivenEntersValidCredentials(Table users)
        {
            var usersCredential = users.CreateDynamicSet();

            foreach (var user in usersCredential)
            {
                loginPage.EnterUserDetailsInLoginFileds(user.Username, user.Password);
            }
  
          
        }
        
        [Given(@"clicks on Login button")]
        public void GivenClicksOnLoginButton()
        {
            loginPage.ClickLogin();
        }
        
        [When(@"user add two items to cart")]
        public void WhenUserAddTwoItemsToCart(Table products)
        {
            var productsItems = products.CreateDynamicSet();

            foreach (var product in productsItems)
            {
                productpage.AddTwoProductsInCart(product.product1, product.product2);
            }

        }
        
        [When(@"verify the items and total")]
        public void WhenVerifyTheItemsAndTotal()
        {
            cartPage.validateCartItemsAndTotalPrice();
        }
        
        [When(@"performs checkout")]
        public void WhenPerformsCheckout()
        {

            cartPage.checkouttheproducts();
        }
        
        [When(@"user add his details")]
        public void WhenUserAddHisDetails(Table details)
        {
            checkoutPage.AddUserDetails(details.Rows[0][0], details.Rows[0][1], details.Rows[0][2]);
        }
        
        [When(@"user clicks on logout link")]
        public void WhenUserClicksOnLogoutLink()
        {
            
            checkoutPage.logoutFromApplication();
        }
        
        [Then(@"user should be successfully logged in")]
        public void ThenUserShouldBeSuccessfullyLoggedIn()
        {
            productpage.validateProductsPage();
        }
        
        [Then(@"user should see success purchase message")]
        public void ThenUserShouldSeeSuccessPurchaseMessage()
        {
            checkoutPage.successMessageValidation();
        }
        
        [Then(@"user should be successfully logged out from the application")]
        public void ThenUserShouldBeSuccessfullyLoggedOutFromTheApplication()
        {
            loginPage.validateLoginPage();
        }
    }
}
