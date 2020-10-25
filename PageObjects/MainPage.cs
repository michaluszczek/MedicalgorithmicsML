using Medicalgorithmics.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medicalgorithmics.PageObjects
{
    public class MainPage
    {
        IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        

        private IWebElement KontaktMenuLink => driver.FindElement(By.XPath("(//*[@id='mega-menu-item-29']/a)[1]"));
        private IWebElement MagnifyingGlass => driver.FindElement(By.XPath("/html/body/div[3]/div/header/div/div/div/div[2]/div/div/a/span"));
        private IWebElement SearchField => driver.FindElement(By.Name("s"));
        private IWebElement SearchArrow => driver.FindElement(By.XPath("/html/body/div[3]/div/header/div/form/div/div/a/span"));
        private IWebElement CookieButton => driver.FindElement(By.Id("cn-accept-cookie"));

        public void CookieClick()
        {
            CookieButton.Click();
        }
        
        public void KontaktClick()
        {
            KontaktMenuLink.Click();
        }

        public string GetKontaktColor()
        {
            return KontaktMenuLink.GetCssValue("color");            

        }

        internal void Hover()
        {
            HelperWaits waits = new HelperWaits(driver);
            waits.WaitUntilDisplayed(KontaktMenuLink);
            Actions actions = new Actions(driver);
            actions.MoveToElement(KontaktMenuLink).Build().Perform();
        }

        internal void Search(string subject)
        {
            MagnifyingGlass.Click();
            SearchField.SendKeys(subject);
            SearchArrow.Click();
        }

        internal bool WaitForLoad(IWebDriver driver, int timeoutSec = 15)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            return wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
