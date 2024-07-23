using TechTalk.SpecFlow;
using final.Page;
using final.Helper;
using NUnit.Framework;
using System.Collections.Generic;
using DemoQA.Core.Configurations;
using final.Constant;
using final.Core.Helper;
using final.Steps;
using final.DataObject;
using DemoQA.Core.DataObject;
using Core.API;
using DemoQA.Service.Services;
using DemoQA.Test.DataProvider;
using DemoQA.Test.DataObjects;

[Binding]
public class DeleteBookSteps
{
    private BookServices _bookServices;
    private UserServices _userServices;
    private APIClient APIClient;
    private LoginPage _loginPage;
    private DeleteBookPage _deleteBookPage;
    private readonly ScenarioContext _scenarioContext;
    public Dictionary<string, Account> AccountData;
    private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");

    public DeleteBookSteps(ScenarioContext scenarioContext)
    {
        APIClient = new APIClient(ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "home_url"));
        _loginPage = new LoginPage();
        _deleteBookPage = new DeleteBookPage();
        _userServices = new UserServices(APIClient);
        _bookServices = new BookServices(APIClient);
        AccountData = JsonHelper.ReadAndParse<Dictionary<string, Account>>(FileConstant.AccountFilePath.GetAbsolutePath());
        this._scenarioContext = scenarioContext;
    }
    [Given(@"User already Add Book into book collection")]
    public async Task GivenUserAlreadyAddBookIntoBookCollectionBy(Table table)
    {

        ExtentReportHelper.LogTestStep("1. Add book into collection");
        foreach (var row in table.Rows)
        {
            string userInfoData = row["UserDataKey"];
            string bookInfoData = row["BookDataKey"];
            var userInfo = UserProvider.GetUserInfoData(userInfoData);
            var bookInfo = BookProvider.GetBookInfoData(bookInfoData);
            var responseToken = await _userServices.GenerateTokenAsync(userInfo.username, userInfo.password);
            var token = responseToken.Data.Token;
            var response = await _bookServices.AddBookAsync(userInfo.userid, bookInfo.isbn, token);
            Console.WriteLine(response.Data.Books.Count);
        }

    }


    [Given(@"I navigate to the login page")]
    public void GivenINavigateToTheLoginPage()
    {

        ExtentReportHelper.LogTestStep("2. Go to Login Page");
        WebObject.NavigateTo(login_url);
    }


    [When(@"I login into system with ""(.*)"" data")]
    public void WhenILoginIntoSystemWithData(string accountValue)
    {

        ExtentReportHelper.LogTestStep("3. Login with username and password");
        Account account = AccountData[accountValue];
        _loginPage.Login(account.username, account.password);
        _loginPage.VerifyLoginSuccessfully(account.username);
    }


    [When(@"I search for the book ""(.*)""")]
    public void WhenISearchForTheBook(string bookTitle)
    {
        ExtentReportHelper.LogTestStep("4. Search Book name");
        _deleteBookPage.EnterSearchKeyword(bookTitle);
    }

    [When(@"I delete the book ""(.*)""")]
    public void WhenIDeleteTheBook(string bookTitle)
    {

        ExtentReportHelper.LogTestStep("5. Delete Book");
        _deleteBookPage.DeleteBook(bookTitle);
    }

    [Then(@"the book ""(.*)"" should be deleted successfully")]
    public void ThenTheBookShouldBeDeletedSuccessfully(string bookTitle)
    {
        ExtentReportHelper.LogTestStep("6. Verify Delete Book successfully");
        bool isBookDeleted = _deleteBookPage.IsBookDeleted(bookTitle);
        Assert.IsTrue(isBookDeleted, $"The book titled '{bookTitle}' was not deleted successfully.");
    }

}
