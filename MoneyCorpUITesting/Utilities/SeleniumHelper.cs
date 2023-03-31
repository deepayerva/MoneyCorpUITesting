using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace MoneyCorpUITesting.Utilities
{

    public static class SeleniumHelpers
    {
        public static void JavascriptClick(WebDriver driver, By element)
        {
            WaitForElementExists(driver, element);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(element));
        }

        public static void WaitForElementExists(WebDriver driver, By by, int? secondsToWait = null)
        {
            try
            {
                new WebDriverWait(driver, System.TimeSpan.FromSeconds(secondsToWait ?? 30)).Until(ExpectedConditions.ElementExists(by));
            }
            catch (WebDriverException ex)
            {
                throw new WebDriverException("WaitForElement action failed", ex);
            }
        }

        public static void WaitForElementVisible(WebDriver driver, By by, int? secondsToWait = null)
        {
            try
            {
                new WebDriverWait(driver, System.TimeSpan.FromSeconds(secondsToWait ?? 30)).Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverException ex)
            {
                throw new WebDriverException("WaitForElement action failed", ex);
            }
        }

        public static void WaitForClickable(WebDriver driver, By by, int? secondsToWait = null)
        {
            try
            {
                new WebDriverWait(driver, System.TimeSpan.FromSeconds(secondsToWait ?? 30)).Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (WebDriverException ex)
            {
                throw new WebDriverException("WaitForClickable action failed", ex);
            }
        }


        public static void ScrollToElement(WebDriver driver, By by)
        {
            var js = (IJavaScriptExecutor)driver;
            try
            {
                var element = driver.FindElement(by);

                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (System.Exception ex)
            {
                throw new WebDriverException("Failed to scroll to element", ex);
            }
        }
    }
}