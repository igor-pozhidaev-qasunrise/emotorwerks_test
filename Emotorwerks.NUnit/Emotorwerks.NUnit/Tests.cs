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
        public void googleTest()
        {
            // TODO: Add your test code here
            driver.Navigate().GoToUrl("https://www.google.com/");
        }
    }
}
