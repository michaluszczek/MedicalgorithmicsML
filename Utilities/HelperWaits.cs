using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Medicalgorithmics.Utilities
{
    class HelperWaits
    {
        IWebDriver driver;
        public HelperWaits(IWebDriver driver)
        {
            this.driver = driver;
        }
        WebDriverWait wait;
        public void WaitUntilFind(IWebElement el)
        {
            if (wait == null)
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(d => el);
        }

        public void WaitUntilDisplayed(IWebElement el)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(e => el.Displayed);           
        }

    }
        
}
