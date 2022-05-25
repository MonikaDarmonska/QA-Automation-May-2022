


using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriver_POM_Example.Pages;

namespace WebDriver_POM_Example.Tests
{
    public class HomePageTests : BaseTests
    {


        [Test]
        public void Test_HomePage_TitleAndHeading()
        {
            var page = new HomePage(driver);
            page.Open();
            Assert.That(page.GetPageTitle(), Is.EqualTo("MVC Example"));
            Assert.That(page.GetPageHeadingTexts(), Is.EqualTo("Students Registry"));
            Assert.Greater(page.GetStudentCount(), 0);
        }

        /*
        [Test]
        public void Test_HomePage_HomeLink()
        {
            var home_page = new HomePage(driver);
            home_page.Open();
            home_page.HomeLink.Click();
            Assert.That(home_page.GetPageHeadingTexts, Is.EqualTo("MVC Example"));
            Assert.That(driver.Url, Is.EqualTo(home_page.GetPageUrl()));
        }
        */

        [Test]
        public void Test_HomePage_ViewHomeLinlk()
        {
            var home_page = new HomePage(driver);
            home_page.Open();
            home_page.HomeLink.Click();
            Assert.IsTrue(home_page.isOpen());
        }

        [Test]
        public void Test_HomePage_ViewStudentsLink()
        {
            var home_page = new HomePage(driver);
            home_page.Open();
            home_page.ViewStudentsLink.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).isOpen());

           // var view_students = new ViewStudentsPage(driver);
           // Assert.That(view_students.GetPageHeadingTexts, Is.EqualTo("Students"));
           // Assert.That(driver.Url, Is.EqualTo(view_students.GetPageUrl()));
        }

        /*
        [Test]
        public void Test_HomePage_AddStudentsLink()
        {
            var home_page = new HomePage(driver);
            home_page.Open();
            home_page.AddStudentLink.Click();
            var add_students = new AddStudentPage(driver);
            Assert.That(add_students.GetPageHeadingTexts, Is.EqualTo("Add Student"));
            Assert.That(driver.Url, Is.EqualTo(add_students.GetPageUrl()));
        }
        */

        [Test]
        public void Test_HomePage_OpenAddStudentPage()
        {
            var home_page = new HomePage(driver);
            home_page.Open();
            home_page.AddStudentLink.Click();
            Assert.IsTrue(new AddStudentPage(driver).isOpen());
        }

        [Test]
        public void Test_HomePage_ViewStudents()
        {
            var home_page = new HomePage(driver);
            home_page.Open();
            home_page.HomeLink.Click();
            Assert.That(home_page.GetPageHeadingTexts, Is.EqualTo("MVC Example"));
        }

        [Test]
        public void Test_HomePage_StudentCount()
        {
            var home_page = new HomePage(driver);
            home_page.Open();         
            Assert.Greater(home_page.GetStudentCount(), 1);
        }
    }
}
