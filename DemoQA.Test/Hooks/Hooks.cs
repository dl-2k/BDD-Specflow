using TechTalk.SpecFlow;
using final.Helper;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using DemoQA.Core.Configurations;

namespace final.Steps
{
    [Binding]
    public class Hooks
    {
        public static IConfiguration Config;

        private const string AppSettingPath = "Configurations\\appsettings.json";

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            TestContext.Progress.WriteLine("====> Global one-time setup");

            // Read configuration file
            Config = ConfigurationHelper.ReadConfiguration(AppSettingPath);

            string browser = ConfigurationHelper.GetConfigurationByKey(Config, "browser");
            string environment = ConfigurationHelper.GetConfigurationByKey(Config, "environment");

           // Create report path dynamically
            string date = DateTime.Now.ToString("ddMMMMMyyyy_HHmm");
            string projectDirectory = Directory.GetCurrentDirectory();
            string testResultsDirectory = Path.Combine(projectDirectory, "TestResults");
            Directory.CreateDirectory(testResultsDirectory);

            string functionTestDirectory = Path.Combine(testResultsDirectory, $"ResultTest_{date}");
            Directory.CreateDirectory(functionTestDirectory);

            string reportPath = Path.Combine(functionTestDirectory, "result.html");

            ExtentReportHelper.InitializeReport(reportPath, "Hostname",environment, browser);
        }
    }
}
