using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace MoneyCorpUITesting.Tests
{
    public class TestBase
    {
        public WebDriver driver;
        public string? baseUrl;
        public string? browserName;


        [SetUp]
        public void StartBrowser()
        {
            string basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            var settings = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                       .Build();

            baseUrl = settings["baseUrl"];
            browserName = settings["browser"];
            InitializeBrowserDriver(browserName);

        }

        public WebDriver getDriver()
        {
            return driver;
        }

        public void InitializeBrowserDriver(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    //Add chrome switch to disable notification - "**--disable-notifications**"
                    options.AddArguments("--disable-notifications");
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(options);
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(baseUrl);
                    Thread.Sleep(3000);
                    AcceptCookieWarning();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new EdgeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(baseUrl);
                    Thread.Sleep(3000);
                    AcceptCookieWarning();
                    break;
            }
        }
        public void AcceptCookieWarning()
        {
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
