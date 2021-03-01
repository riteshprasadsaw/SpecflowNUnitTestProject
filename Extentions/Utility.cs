using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowNUnitTestProject.Extentions
{
    public class Utility
    {
      
        public static MediaEntityModelProvider CaptureScreenshotFromBase64(string name, IWebDriver _driver)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build();
        }
    }
}
