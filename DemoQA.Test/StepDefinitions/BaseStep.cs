using DemoQA.Core.Configurations;
using DemoQA.Core.DataObject;
using final.Constant;
using final.Core;
using final.DataObject;
using final.Helper;
using MongoDB.Bson;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace final.Steps
{
    [Binding]
    public class BaseStep
    {
      
        public Dictionary<string, Account> AccountData;
     

        [BeforeScenario]
        public void SetUp()
        {
            string browser = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "browser");

            AccountData = JsonHelper.ReadAndParse<Dictionary<string, Account>>(FileConstant.AccountFilePath.GetAbsolutePath());
            



            ExtentReportHelper.CreateTest(TestContext.CurrentContext.Test.ClassName);
            ExtentReportHelper.CreateNode(TestContext.CurrentContext.Test.Name);
            ExtentReportHelper.LogTestStep("Initialize WebDriver");

            DriverManager.InitDriver(browser);
            DriverManager.driver.Manage().Window.Maximize();
            DriverManager.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            DriverManager.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
        }

        [AfterScenario]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            ExtentReportHelper.CreateTestResult(status, stacktrace, TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name, DriverManager.driver);
            ExtentReportHelper.Flush();
            DriverManager.driver.Quit();
        }
    }
}
