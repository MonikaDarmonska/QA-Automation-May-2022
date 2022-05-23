using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace WebDriverWaitExamples
{
    public class WaitTests
    {
        private WebDriver driver;
        private WebDriverWait wait;

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Wait_TrheadSleep()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");

            //driver.Url = "http://www.uitestpractice.com/Students/Contact";

            var element = driver.FindElement(By.LinkText("This is a Ajax link"));

            element.Click();
            Thread.Sleep(15000); // This is not a good practice

            var text_element = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(text_element);
           
        }

        [Test]
        public void Test_Wait_ImplicitWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); // This is not a good practice

            //driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");
            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.LinkText("This is a Ajax link")).Click();           

            var text_element = driver.FindElement(By.ClassName("ContactUs")).Text;
            Assert.IsNotEmpty(text_element);

            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.LinkText("This is a Ajax link")).Click();
            var text_element1 = driver.FindElement(By.ClassName("ContactUs")).Text;
            Assert.IsNotEmpty(text_element);
        }

        [Test]
        public void Test_Wait_ExplicitWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();            
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
           
            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.LinkText("This is a Ajax link")).Click();

            //ExplicitWait
            var text_element = this.wait.Until(d =>
            {
                return d.FindElement(By.LinkText("This is a Ajax link")).Text;
            });

            Assert.IsNotEmpty(text_element);

            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.LinkText("This is a Ajax link")).Click();
                     
           
            var text_element1 = this.wait.Until(d =>
            {
                return d.FindElement(By.LinkText("This is a Ajax link")).Text;
            });
            Assert.IsNotEmpty(text_element1);
        }

        [Test]
        public void Test_Wait_ExpectedConditions()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.LinkText("This is a Ajax link")).Click();
                        
            var text_element = this.wait.Until(
                ExpectedConditions.ElementIsVisible(By.LinkText("This is a Ajax link"))
            );

            Assert.IsNotEmpty(text_element.Text);

            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.LinkText("This is a Ajax link")).Click();


            var text_element1 = this.wait.Until(
                 ExpectedConditions.ElementIsVisible(By.LinkText("This is a Ajax link"))
             );
            Assert.IsNotEmpty(text_element1.Text);
        }
    }
}