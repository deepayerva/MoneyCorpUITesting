using MoneyCorpUITesting.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MoneyCorpUITesting.PageObjects
{
    public class HomePage
    {
        private WebDriver driver;
        WebDriverWait wait;
        private string _pageUrl;
        private string _pageTitle;


        public HomePage(WebDriver driver)
        {
            this.driver = driver;
        }


        By _languageMenuBtn = By.Id("language-dropdown");
        By _usaLinkText = By.XPath("//*[@id='nav-languages-overlay']//ul//span[contains(text(),'USA')]");
        By _buisinessTab = By.XPath("//*[@id=\"menu\"]/nav/ul/li[1]/div/a");
        By _foreignExchangeLinkText = By.XPath("//*[@id=\"mega-nav-1\"]/div//div[1]/ul[1]/li[2]/a");
        By _searchBox = By.XPath("/html/body/section/header/div/div/div[3]/div[1]/form/input");
        By _searchBtn = By.XPath("/html/body/section/header/div/div/div[3]/div[1]/form/input[2]");
        By _aboutLinkText = By.LinkText("About");
        By _searchResultHeadingText = By.XPath("/html/body/section/section/div[2]/form/input");
        By _searchResults = By.XPath("/html/body/section/section/div[2]/div[2]//a[@class='title u-m-b2']");

        public string SearchText(string text)
        {
            HelperMethods.EnterInputFieldData(driver, _searchBox, text);
            HelperMethods.ClickOn(driver, _searchBtn);
            return HelperMethods.GetInputFieldTextValue(driver, _searchResultHeadingText);
        }
        public void SearchResultsVerification(string attributeName, string attributeText)
        {
            HelperMethods.GetAndVerifyChildControls(driver, _searchResults, attributeName, attributeText);
        }



        public string SelectUSAEnglishLanguage()
        {
            HelperMethods.ClickOn(driver, _languageMenuBtn);
            HelperMethods.ClickOn(driver, _usaLinkText);
            return driver.Url.ToString();
        }
        public string ClickForeinExchange()
        {

            var buisinessTab = driver.FindElement(_buisinessTab);
            Actions action = new Actions(driver);
            action.MoveToElement(buisinessTab).Perform();
            var fxLinkText = driver.FindElement(_foreignExchangeLinkText);
            fxLinkText.Click();
            return driver.Url.ToString();
        }
    }
}

