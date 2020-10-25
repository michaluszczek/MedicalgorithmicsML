using Medicalgorithmics.Utilities;
using OpenQA.Selenium;
using System.Threading;

namespace Medicalgorithmics.PageObjects
{
    public class KontaktPage
    {
        IWebDriver driver;
        public KontaktPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement MediaPack => driver.FindElement(By.XPath("//h3/a[contains(text(), 'Media pack')]"));

        public void GoToMediaPack()
        {
            Thread.Sleep(3000);           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", MediaPack);            
            MediaPack.Click();
        }
    }
}
