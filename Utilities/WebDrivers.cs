using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace OpenQA.Selenium
{
    internal static class WebDrivers
    {

        public static IWebDriver CreateBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                case BrowserType.Firefox:
                    FirefoxOptions firefoxProfile = new FirefoxOptions();
                    firefoxProfile.SetPreference("browser.download.manager.showWhenStarting", false);
                    firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/zip");
                    firefoxProfile.SetPreference("browser.helperApps.neverAsk.openFile", "application/zip");
                    return new FirefoxDriver(firefoxProfile);

                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }
    }
}


