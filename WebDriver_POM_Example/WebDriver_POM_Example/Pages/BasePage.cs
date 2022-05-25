using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver_POM_Example.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        public virtual string PageUrl { get; }

        // Constructor
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        //Properties
        public IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.LinkText("View Students"));
        public IWebElement AddStudentLink => driver.FindElement(By.LinkText("Add Student"));
        public IWebElement ElementPageHeading => driver.FindElement(By.CssSelector("body > h1")); //copy-> CSS Path


        //Methods
    public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool isOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageUrl()
        {
            return driver.Url;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingTexts()
        {
            return ElementPageHeading.Text;
        }

    }
}
