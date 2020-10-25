using Medicalgorithmics.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medicalgorithmics.PageObjects
{
    public class SearchResultPage
    {
        IWebDriver driver;
        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IList<IWebElement> SearchResult => driver.FindElements(By.ClassName("latest_post_custom"));
        private IWebElement SearchPageAmount => driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/div[2]/div/ul/div/ul/li[last() - 1]"));
        private IList<IWebElement> Titles => driver.FindElements(By.XPath("//h3/a"));
        private IWebElement SecondPage => driver.FindElement(By.XPath("//ul/li/a[contains(text(), '2')]"));
        private IWebElement Body => driver.FindElement(By.XPath("//body"));
        private IWebElement CookieButton => driver.FindElement(By.Id("cn-accept-cookie"));

        internal int CountResults()
        {
            return SearchResult.Count();
        }

        internal int SearchPageCount()
        {
            var pagination = Convert.ToInt32(SearchPageAmount.Text);
            return pagination;
        }

        internal int GetTelKardCount()
        {
            
            List<string> titlesFirstPage = new List<string>(Titles.Select(t => t.Text));
            ScrollToSecondPage();
            SecondPage.Click();
            List<string> titlesSecondPage = new List<string>(Titles.Select(t => t.Text));
            var allTitles =  titlesFirstPage.Union(titlesSecondPage).ToList();
            int telKardCount = allTitles.Count(t => t.Contains("PocketECG CRS – telerehabilitacja kardiologiczna"));
            return telKardCount;
        }

        private void ScrollToSecondPage()
        {
            HelperWaits waits = new HelperWaits(driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", SecondPage);
            waits.WaitUntilDisplayed(SecondPage);
        }
    }
}
