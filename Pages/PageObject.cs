using OpenQA.Selenium;
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
    public abstract class PageObject
    {
        private readonly IWebDriver _driver;

        public PageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void AssertTitle(string title)
        {
            string pageTitle = _driver.Title;
            //pageTitle.Should().Be(title);
        }

        public Boolean validatePageSourceContains(String text)
        {
            return _driver.PageSource.Contains(text);
        }
    }
}
