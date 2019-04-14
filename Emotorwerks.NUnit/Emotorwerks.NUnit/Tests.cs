// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;



namespace Emotorwerks.NUnit
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    [TestFixture("edge")]
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
            // Check eMotorWerks website link on the fisrt searh page
            driver.FindElement(By.XPath("//cite[.='https://emotorwerks.com/']"));

            // Check eMotorWerks Wiki page link on the fisrt searh page
            driver.FindElement(By.XPath("//cite[.='https://en.wikipedia.org/wiki/EMotorWerks']"));

        }
    }
}
