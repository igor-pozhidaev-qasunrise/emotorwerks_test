// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;


namespace Emotorwerks.NUnit
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    [TestFixture("ie")]
    [Parallelizable]

    public class Tests : SetUps
    {
        public Tests(string browser) : base(browser) { }

        [Test]
        [TestCase(TestName = "1.1 Google search result contains eMotorWerks Links")]
        public void googleSearchResult()
        {

            // Search eMotorWerks
            driver.Navigate().GoToUrl("https://www.google.com/");
            IWebElement searchInput = driver.FindElement(By.Name("q"));
            searchInput.SendKeys("eMotorWerks");
            searchInput.Submit();

            // Check search results
            // Check eMotorWerks website links on the fisrt searh page
            driver.FindElement(By.XPath("//cite[.='https://emotorwerks.com/']"));
            driver.FindElement(By.XPath("//a[@href='https://emotorwerks.com/']"));

            // Check eMotorWerks - Wikipedia search result item 
            driver.FindElement(By.XPath("//h3[.='eMotorWerks - Wikipedia']"));

            // Check eMotorWerks Wiki page link on the fisrt searh page
            driver.FindElement(By.XPath("//cite[.='https://en.wikipedia.org/wiki/EMotorWerks']"));

        }


        [Test]
        [TestCase(TestName = "1.2 Check Footer Navigation")]
        public void checkFooterNavigation()
        {
            // Search eMotorWerks
            driver.Navigate().GoToUrl("https://emotorwerks.com/");

            // Check There are 4 Footer Menu Navigation items
            driver.FindElement(By.XPath("//ul[@class='b-footer-bottom-menu__list'][count(li) = 4]"));

            // Check each link from the list
            var theNavigation = new List<NavigationItem>
            {
                new NavigationItem() { Item="Return & refund policy", Href="/return-and-refund-policy"},
                new NavigationItem() { Item="Privacy", Href="/privacy-policy"},
                new NavigationItem() { Item="Cookie Policy", Href="/cookie-policy"},
                new NavigationItem() { Item="Sitemap", Href="/sitemap"}
            };
            
            foreach (NavigationItem theNavigationItem in theNavigation)
            {
                string elementXPath = "//a[.='"+theNavigationItem.Item+"' and @href='"+theNavigationItem.Href+"']";
                IWebElement returnRefundPolicy = driver.FindElement(By.XPath(elementXPath));
                CustomClick(returnRefundPolicy);
                Assert.IsTrue(driver.PageSource.Contains(theNavigationItem.Href));
                driver.Navigate().Back();
            }
        }
    }

    internal class NavigationItem
    {
        public NavigationItem()
        {
        }

        public string Item { get; set; }
        public string Href { get; set; }
    }
}
