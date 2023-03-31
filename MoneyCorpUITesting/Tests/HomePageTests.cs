using MoneyCorpUITesting.PageObjects;
using NUnit.Framework;

namespace MoneyCorpUITesting.Tests
{
    public class HomePageTests : TestBase
    {
        [Test]
        public void ChangeTheLanguage_SearchOnFxSolution()
        {
            var homePage = new HomePage(driver);
            //Assering for lanuage change in URL.
            Assert.That(homePage.SelectUSAEnglishLanguage(), Is.EqualTo("https://www.moneycorp.com/en-us/"), "Urls are not matching");
            //Checking for the correct URL oncce the Fx solutions opened
            Assert.That(homePage.ClickForeinExchange(), Is.EqualTo("https://www.moneycorp.com/en-us/business/foreign-exchange-solutions/"),
                     "Fx solutions page is not loaded");
            //Verifying Seraching correcly displays the results
            Assert.That(homePage.SearchText("international payments"), Is.EqualTo("international payments"), "Search results are not matching");
            homePage.SearchResultsVerification("href", "https://www.moneycorp.com/en-us/");
        }
    }
}

