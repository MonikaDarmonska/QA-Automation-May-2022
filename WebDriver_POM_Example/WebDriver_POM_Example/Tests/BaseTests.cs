

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver_POM_Example.Tests
{
    public class BaseTests
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void ShutDownBrowser()
        {
            driver.Quit();
        }
    }
}
