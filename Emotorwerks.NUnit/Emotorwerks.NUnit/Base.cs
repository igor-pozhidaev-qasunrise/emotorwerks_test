using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using System.Drawing;

namespace Emotorwerks.NUnit
{
    public class SetUps
    {
        protected IWebDriver driver;
        protected string browser;
        
        public SetUps(string browser)
        {
            this.browser = browser;
        }

        [SetUp]
        public void Initialize()
        {
            switch (browser)
            {
                // These all pull the latest version by default
                // To specify version add SetCapability("version", "desired version")
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    break;
            }

            driver.Manage().Window.Size = new Size(1400, 900);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public void CustomClick(IWebElement targetElement)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", targetElement);
            targetElement.Click();
        }
    }
}