using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MoneyCorpUITesting.Utilities
{
    public static class HelperMethods
    {
        public static bool IsInputFieldValueNonEmpty(WebDriver driver, By by)
        {
            SeleniumHelpers.WaitForElementVisible(driver, by);
            SeleniumHelpers.ScrollToElement(driver, by);
            Thread.Sleep(300);
            if (string.IsNullOrEmpty(driver.FindElement(by).GetAttribute("value")))
            {
                return false;
            }
            return true;
        }

        public static string GetInputFieldTextValue(WebDriver driver, By by)
        {
            return driver.FindElement(by).GetAttribute("value");
        }
        public static void GetAndVerifyChildControls(WebDriver driver, By parentControl, string attributeName, string attributeText)
        {
            var childElements = driver.FindElements(parentControl);
            foreach (var element in childElements)
            {
                if (element.GetAttribute(attributeName).ToString().StartsWith(attributeText))
                    continue;
                else
                    throw new Exception();
            }
        }
        public static string GetUIElementText(WebDriver driver, By by)
        {
            SeleniumHelpers.WaitForElementVisible(driver, by);
            return driver.FindElement(by).Text;
        }

        public static void EnterInputFieldData(WebDriver driver, By by, dynamic value)
        {
            string x = Convert.ToString(value);
            SeleniumHelpers.WaitForElementVisible(driver, by);
            driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(x);
        }

        public static bool IsElementInvisibleOnPage(WebDriver driver, By by, int? secondsToWait = null)
        {
            try
            {
                new WebDriverWait(driver, System.TimeSpan.FromSeconds(secondsToWait ?? 30)).Until(ExpectedConditions.InvisibilityOfElementLocated(by));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void ClickOn(WebDriver driver, By element)
        {
            Thread.Sleep(200);
            SeleniumHelpers.WaitForElementVisible(driver, element);
            SeleniumHelpers.ScrollToElement(driver, element);
            SeleniumHelpers.WaitForClickable(driver, element);
            driver.FindElement(element).Click();
            Thread.Sleep(200);
        }
    }
}