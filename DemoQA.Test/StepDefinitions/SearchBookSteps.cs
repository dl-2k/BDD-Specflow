using TechTalk.SpecFlow;
using final.Page;
using final.Helper;
using NUnit.Framework;
using System.Collections.Generic;
using DemoQA.Core.Configurations;
using final.Core.Helper;
using final.Steps;

[Binding]
public class SearchBookSteps
{
    private SearchBookPage _searchBookPage;
    private string bookstore_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "bookstore_url");

    [Given(@"I navigate to the bookstore page")]
    public void GivenINavigateToTheBookstorePage()
    {
        ExtentReportHelper.LogTestStep("1. Go to Bookstore Page");
        WebObject.NavigateTo(bookstore_url);
        _searchBookPage = new SearchBookPage();
    }

    [When(@"I enter ""(.*)"" in the search bar")]
    public void WhenIEnterInTheSearchBar(string keyword)
    {

        ExtentReportHelper.LogTestStep("2. Search Book name");
        _searchBookPage.EnterSearchKeyword(keyword);
    }

    [Then(@"I should see the search results containing ""(.*)""")]
    public void ThenIShouldSeeTheSearchResultsContaining(string keyword)
    {
        ExtentReportHelper.LogTestStep("3. Verify Search Book Correctly");
        List<string> expectedHeaders = new List<string> { "Image", "Title", "Author", "Publisher" };
        _searchBookPage.AssertSearchResults(keyword, expectedHeaders);
    }
}
