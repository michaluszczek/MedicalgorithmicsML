using Medicalgorithmics.PageObjects;
using OpenQA.Selenium;
using System;
using System.IO;
using Xunit;

namespace Medicalgorithmics_tests
{
    public class LogotypesTest
    {
        private string Test_url { get; } = "https://www.medicalgorithmics.pl/";        

        [Theory]
        [InlineData(BrowserType.Chrome)]
        [InlineData(BrowserType.Firefox)]

        public void VerifyFontColor(BrowserType browserType)
        {
            var driver = WebDrivers.CreateBrowser(browserType);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Test_url);
            MainPage mainPage = new MainPage(driver);

            var colorBeforeHover = mainPage.GetKontaktColor();
            mainPage.Hover();
            var colorAfterHover = mainPage.GetKontaktColor();

            Assert.NotEqual(colorBeforeHover, colorAfterHover);

            driver.Quit();
        }

        [Theory]
        [InlineData(BrowserType.Chrome)]
        [InlineData(BrowserType.Firefox)]

        public void DownloadLogotypy(BrowserType browserType)
        {
            var driver = WebDrivers.CreateBrowser(browserType);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Test_url);
            MainPage mainPage = new MainPage(driver);
            KontaktPage kontaktPage = new KontaktPage(driver);
            MediaPackPage mediaPackPage = new MediaPackPage(driver);

            mainPage.KontaktClick();
            kontaktPage.GoToMediaPack();

            mediaPackPage.DownloadLogotypy();

            Assert.True(File.Exists(mediaPackPage.LogoFile));

            driver.Quit();
        }
    }
}