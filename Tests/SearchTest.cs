using Medicalgorithmics.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Medicalgorithmics_tests
{
    public class SearchTest
    {
        private string Test_url { get; } = "https://www.medicalgorithmics.pl/";
        private int ExpectedPocketECGCRSamount { get; } = 10;
        private int ExpectedPageCount { get; } = 2;
        private int ExpectedTelKardCount { get; } = 1;
       
        [Theory]
        [InlineData(BrowserType.Chrome)]
        [InlineData(BrowserType.Firefox)]

        public void PageIsLoadedFirstMethod(BrowserType browserType)
        {
            var driver = WebDrivers.CreateBrowser(browserType);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Test_url);
            MainPage mainPage = new MainPage(driver);

            var pageIsLoaded = mainPage.WaitForLoad(driver);

            Assert.True(pageIsLoaded, "Page not properly loaded, document.readyState is not complete");

            driver.Quit();
        }

        [Theory]
        [InlineData(BrowserType.Chrome)]
        [InlineData(BrowserType.Firefox)]

        public void PageIsLoadedSecondMethod(BrowserType browserType)
        {
            var driver = WebDrivers.CreateBrowser(browserType);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Test_url);
            MainPage mainPage = new MainPage(driver);

            var title = driver.Title;

            Assert.Equal("Home - Medicalgorithmics", title);

            driver.Quit();
        }

        [Theory]
        [InlineData(BrowserType.Chrome)]
        [InlineData(BrowserType.Firefox)]

        public void PocketECGCRSSearch(BrowserType browserType)
        {
            var driver = WebDrivers.CreateBrowser(browserType);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Test_url);
            MainPage mainPage = new MainPage(driver);
            SearchResultPage searchResult = new SearchResultPage(driver);

            mainPage.Search("Pocket ECG CRS");
            var pocketECGCRSamount = searchResult.CountResults();

            Assert.True(pocketECGCRSamount == ExpectedPocketECGCRSamount, "Expected PocketECGCRS amount from search result is 10");

            driver.Quit();
        }

        [Theory]
        [InlineData(BrowserType.Chrome)]
        [InlineData(BrowserType.Firefox)]

        public void VerifyPageCount(BrowserType browserType)
        {
            var driver = WebDrivers.CreateBrowser(browserType);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Test_url);
            MainPage mainPage = new MainPage(driver);
            SearchResultPage searchResult = new SearchResultPage(driver);

            mainPage.Search("Pocket ECG CRS");
            var pageCount = searchResult.SearchPageCount();

            Assert.True(pageCount == ExpectedPageCount, "Expected page count is 2");

            driver.Close();
        }

        [Theory]
        [InlineData(BrowserType.Chrome)]
        [InlineData(BrowserType.Firefox)]
        public void VerifyTelerehabilitacjaKardiologiczna(BrowserType browserType)
        {
            var driver = WebDrivers.CreateBrowser(browserType);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Test_url);
            MainPage mainPage = new MainPage(driver);
            SearchResultPage searchResult = new SearchResultPage(driver);

            mainPage.Search("Pocket ECG CRS");
            var telKardCount = searchResult.GetTelKardCount();

            Assert.True(telKardCount == ExpectedTelKardCount, "Expected amount of telKardCount is 1");

            driver.Quit();
        }
    }
}