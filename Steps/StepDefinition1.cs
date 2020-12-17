using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowNUnitTestProject.Steps
{
    [Binding]
    public sealed class StepDefinition1
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;

        public StepDefinition1(IWebDriver driver,ScenarioContext scenarioContext)
        {
            /*_webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;*/
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement act (action) logic
            Console.WriteLine("In Step definition file");
            // Navigate to the proper wikipedia page
            _driver.Url = $"https://en.wikipedia.org/wiki/Google";
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement act (action) logic
            Console.WriteLine("In Step definition file");
            Assert.AreEqual("Google - Wikipedia", _driver.Title);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            Console.WriteLine("In Step definition file");
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            Console.WriteLine("In Step definition file");
        }
    }
}
