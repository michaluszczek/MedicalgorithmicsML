using Medicalgorithmics.Utilities;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace Medicalgorithmics.PageObjects
{
    public class MediaPackPage
    {
        IWebDriver driver;
        public MediaPackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static string DownloadsDirectory { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        public string LogoFile { get; } = Path.Combine(DownloadsDirectory, "logotypy.zip");
        private IWebElement LogotypyLink => driver.FindElement(By.XPath("//strong[text() = 'Logotypy']"));

        public void DownloadLogotypy()
        {
            HelperWaits waits = new HelperWaits(driver);
            File.Delete(LogoFile);
            waits.WaitUntilDisplayed(LogotypyLink);
            LogotypyLink.Click();
            Thread.Sleep(5000);
        }
    }
}
