using OpenQA.Selenium;
using SpecflowNUnitTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

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
            //loginPage = new LoginPage_Ecommerce();
            loginPage.GoToEcommerceApplication();
            
        }
        
        [Given(@"enters valid credentials")]
        public void GivenEntersValidCredentials(Table users)
        {
            loginPage.EnterUserDetailsInLoginFileds(users.Rows[0][0], users.Rows[0][1]);
          
        }
        
        [Given(@"clicks on Login button")]
        public void GivenClicksOnLoginButton()
        {
            loginPage.ClickLogin();
        }
        
        [When(@"user add two items to cart")]
        public void WhenUserAddTwoItemsToCart(Table products)
        {
            productpage.AddTwoProductsInCart(products.Rows[0][0], products.Rows[0][1]);
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
        public void WhenUserAddHisDetails(Table users)
        {
            checkoutPage.AddUserDetails(users.Rows[0][0], users.Rows[0][1], users.Rows[0][2]);
        }
        
        [When(@"user clicks on logout link")]
        public void WhenUserClicksOnLogoutLink()
        {
            // ScenarioContext.Current.Pending();
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
