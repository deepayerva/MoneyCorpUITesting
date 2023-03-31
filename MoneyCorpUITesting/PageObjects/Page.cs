using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoneyCorpUITesting.PageObjects
{
    public class Page : IPageActions
    {
        private string _pageUrl { get; set; }
        private string _pageTitle { get; }
        protected readonly IWebDriver _driver;
        public Page(WebDriver driver, string pageUrl, string pageTitle)
        {
            _driver = driver;
            _pageUrl = pageUrl;
            _pageTitle = pageTitle;
        }

        public virtual IPageActions NavigateTo()
        {
            _driver.Navigate().GoToUrl(_pageUrl);
            try
            {
                EnsurePageLoaded();
                return null;
            }
            catch
            {
                EnsurePageLoaded();
                return this;
            }
        }
        public virtual void EnsurePageLoaded()
        {
            if (!IsPageLoaded())
                throw new InvalidOperationException($"Failed to load Page.  Page Url Expected = {_pageUrl.ToLower()}, Actual = '{_driver.Url.ToLower()}'; Page Title Expected = {_pageTitle.ToLower()}, Actual = {_driver.Title.ToLower()};  Page Source: \r\n {_driver.PageSource}");
        }
        protected void TriggerBlurEvent()
        {
            _driver.FindElement(By.TagName("body")).Click();
        }

        public virtual void EnsurePageLoadedWithWait(TimeSpan? waitTimeSpan = null)
        {
            var webDriverWait = new WebDriverWait(_driver, waitTimeSpan.Value);
            bool pageHasLoaded = webDriverWait.Until(d => IsPageLoaded());

            if (!pageHasLoaded)
                throw new InvalidOperationException($"Failed to load LoginPage.  Page Url Expected = {_pageUrl.ToLower()}, Actual = '{_driver.Url.ToLower()}'; Page Title Expected = {_pageTitle.ToLower()}, Actual = {_driver.Title.ToLower()};  Page Source: \r\n {_driver.PageSource}");
        }
        public virtual bool IsPageLoaded(int? timeout = null)
        {
            var result = _driver.Url.ToLower().StartsWith(_pageUrl.ToLower()) &&
                                                    _driver.Title.ToLower() == _pageTitle.ToLower();
            return result;
        }
    }
}