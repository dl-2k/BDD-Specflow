using NUnit.Framework;
using TechTalk.SpecFlow;
using final.Page;
using final.DataObject;
using final.Constant;
using final.Core.Helper;
using DemoQA.Core.Configurations;
using TechTalk.SpecFlow.Assist;
using final.Helper;

namespace final.Steps
{
    [Binding]
    public class RegistrationSteps
    {
        private readonly RegistationPage _registrationPage;
        private readonly ScenarioContext _scenarioContext;

        public RegistrationSteps(ScenarioContext scenarioContext)
        {
            _registrationPage = new RegistationPage();
            this._scenarioContext = scenarioContext;
        }

        [Given(@"I have opened the registration form")]
        public void GivenIHaveOpenedTheRegistrationForm()
        {
            ExtentReportHelper.LogTestStep("1. Go to Registation Page");
            string formUrl = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "form_url");
            WebObject.NavigateTo(formUrl);
        }

        [When(@"I fill in the registration form with the following data")]
        public void WhenIFillInTheRegistrationFormWithTheFollowingData(Table table)
        {
            ExtentReportHelper.LogTestStep("2. Enter all valid data into all fields");
            var formData = table.CreateInstance<FormFieldData>();
            formData.Picture = PathHelper.GetProjectRelativePath(Path.Combine("Image", Path.GetFileName(formData.Picture)));
           
            this._scenarioContext[nameof(FormFieldData)] = formData;
            _registrationPage.FillRegistrationForm(formData);
        }

        [Then(@"I should see the thank you message")]
        public void ThenIShouldSeeTheThankYouMessage()
        {
            ExtentReportHelper.LogTestStep("3. Verify Popup Form Submit ");
            _registrationPage.VerifyThankYouMessage();
        }

        [Then(@"the form submission should match the expected data")]
        public void ThenTheFormSubmissionShouldMatchTheExpectedData()
        {
           
            ExtentReportHelper.LogTestStep("4. Verify correct FormData successfully");
            var formData = this._scenarioContext[nameof(FormFieldData)] as FormFieldData;
            _registrationPage.VerifyFormSubmission(formData);
        }
    }
}
