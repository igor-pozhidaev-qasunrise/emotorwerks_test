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
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [Parallelizable]

    public class Tests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        IWebDriver driver;
        
        [SetUp]
        public void Initialize()
        {
            this.driver = new TWebDriver();
        }

        [Test]
        public void googleTest()
        {
            // TODO: Add your test code here
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
