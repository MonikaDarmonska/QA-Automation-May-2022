


using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriver_POM_Example.Pages;

namespace WebDriver_POM_Example.Tests
{
    public class AddStudentTests : BaseTests
    {
        
        [Test]
        public void Test_AddStudent_Url_Heading_Title()
        {
            var add_student = new AddStudentPage(driver);
            add_student.Open();
            Assert.That(driver.Url, Is.EqualTo(add_student.GetPageUrl()));
            Assert.That(add_student.GetPageTitle(), Is.EqualTo("Register New Student"));
            Assert.That(add_student.GetPageHeadingTexts, Is.EqualTo("Add Student"));
        }

        [Test]
        public void Test_HomePage_HomeLink()
        {
            var add_student = new AddStudentPage(driver);
            add_student.Open();
            add_student.HomeLink.Click();
            var home_page = new HomePage(driver);
            Assert.That(home_page.GetPageHeadingTexts, Is.EqualTo("MVC Example"));
            Assert.That(driver.Url, Is.EqualTo(home_page.GetPageUrl()));
        }

      
       
    }
}
