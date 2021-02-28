using OpenQA.Selenium;
using SpecflowNUnitTestProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowNUnitTestProject.Steps
{
    [Binding]
    public class BankOperationSteps
    {
        LoginPage_Bank loginPage;
        //private readonly LoginPage_Bank _page;

        public BankOperationSteps(IWebDriver driver)
        {
            loginPage = new LoginPage_Bank(driver);
        }

        [Given(@"customer is on Bank Login page")]
        public void GivenCustomerIsOnBankLoginPage()
        {
           // loginPage = new LoginPage_Bank();
            loginPage.GoToBankApplication();
        }
        
        [Given(@"customer enters valid credentials")]
        public void GivenCustomerEntersValidCredentials(Table table)
        {
            Console.WriteLine("Testing");
        }
        
        [Given(@"clicks the Login button")]
        public void GivenClicksTheLoginButton()
        {
            Console.WriteLine("Testing");
        }
        
        [When(@"customer deposits an amount")]
        public void WhenCustomerDepositsAnAmount()
        {
            Console.WriteLine("Testing");
        }
        
        [When(@"verify the balance")]
        public void WhenVerifyTheBalance()
        {
            Console.WriteLine("Testing");
        }
        
        [When(@"customer withdraws an amount")]
        public void WhenCustomerWithdrawsAnAmount()
        {
            Console.WriteLine("Testing");
        }
        
        [When(@"customer clicks on logout link")]
        public void WhenCustomerClicksOnLogoutLink()
        {
            Console.WriteLine("Testing");
        }
        
        [When(@"manager enters valid credentials")]
        public void WhenManagerEntersValidCredentials(Table table)
        {
            Console.WriteLine("Testing");
        }
        
        [When(@"clicks the Login button")]
        public void WhenClicksTheLoginButton()
        {
            Console.WriteLine("Testing");
        }
        
        [Then(@"customer should be successfully logged in")]
        public void ThenCustomerShouldBeSuccessfullyLoggedIn()
        {
            Console.WriteLine("Testing");
        }
        
        [Then(@"correct bank balance should be displayed")]
        public void ThenCorrectBankBalanceShouldBeDisplayed()
        {
            Console.WriteLine("Testing");
        }
        
        [Then(@"customer should be successfully logged out from the application")]
        public void ThenCustomerShouldBeSuccessfullyLoggedOutFromTheApplication()
        {
            Console.WriteLine("Testing");
        }
        
        [Then(@"manager should be successfully logged in")]
        public void ThenManagerShouldBeSuccessfullyLoggedIn()
        {
            Console.WriteLine("Testing");
        }
        
        [Then(@"searches for the customer")]
        public void ThenSearchesForTheCustomer()
        {
            Console.WriteLine("Testing");
        }
        
        [Then(@"adds the customer")]
        public void ThenAddsTheCustomer(Table table)
        {
            Console.WriteLine("Testing");
        }
        
        [Then(@"correct details should be added")]
        public void ThenCorrectDetailsShouldBeAdded()
        {
            Console.WriteLine("Testing");
        }
    }
}
