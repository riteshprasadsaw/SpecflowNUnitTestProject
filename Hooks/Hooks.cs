using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.IO;
using SpecflowNUnitTestProject.Configuration;
using Microsoft.Extensions.Configuration;
using BoDi;
using OpenQA.Selenium.Support.Extensions;
using SpecflowNUnitTestProject.Extentions;

/**
 * @author: Ritesh Saw
 *	
 *	01-03-2021
 */

namespace SpecflowNUnitTestProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static ScenarioContext _scenarioContext;
        //private static FeatureContext _featureContext;
        private static AventStack.ExtentReports.ExtentTest _scenario,_step;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static AventStack.ExtentReports.ExtentReports _extent;
        private static AventStack.ExtentReports.ExtentTest _feature;
        private static IWebDriver _driver;
        private static DriverFactory _driverFactory;
        public static ConfigSetting config;
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            String filepath = System.IO.Directory.GetParent(@"../../../").FullName
                + Path.DirectorySeparatorChar + @"Reports\";

            String configfilepath = System.IO.Directory.GetParent(@"../../../").FullName
                + Path.DirectorySeparatorChar + @"Configuration\configsetting.json";

            _extentHtmlReporter = new ExtentHtmlReporter(filepath);
            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(_extentHtmlReporter);

            config = new ConfigSetting();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configfilepath);

            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
            _driverFactory = new DriverFactory();


        }


        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                _feature = _extent.CreateTest(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public void BeforeScenarioStart(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }

            _driver = _driverFactory.CreateDriver();
            _objectContainer.RegisterInstanceAs(_driver);
           
        }

        [BeforeStep]
        public static void BeforeStep(ScenarioContext context)
        {

            _step = _scenario;
        }

        [AfterStep]
        public static void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                _step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if(context.TestError != null){
                _step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }


        [AfterScenario]
        public static void AfterScenario(ScenarioContext scenarioContext)
        {
           
            var mediaEntity = Utility.CaptureScreenshotFromBase64(scenarioContext.ScenarioInfo.Title.Trim(),_driver);

            if (scenarioContext.TestError != null)
            {
                _driver.TakeScreenshot().SaveAsFile(Path.Combine("..", "..", "TestResults", $"{scenarioContext.ScenarioInfo.Title}.png"), ScreenshotImageFormat.Png);
                _scenario.Log(Status.Fail, mediaEntity);
            }
           
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            _extent.Flush();
            _driver?.Dispose();
        }

        [AfterTestRun]
        public static void AfterTestrun()
        {
            //_extent.Flush();
            // _driver?.Dispose();
        }
    }
}
