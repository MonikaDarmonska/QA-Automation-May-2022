using NUnit.Framework;
using WebDriver_POM_Example.Pages;

namespace WebDriver_POM_Example.Tests
{
    public class ViewStudentPageTests : BaseTests
    {
        [Test]
        public void Test_ViewStudentPage_TitleAndHeading()
        {
            var students_page = new ViewStudentsPage(driver);
            students_page.Open();
            Assert.That(students_page.GetPageTitle(), Is.EqualTo("Students"));
            Assert.That(students_page.GetPageHeadingTexts(), Is.EqualTo("Registered Students"));
        }

        [Test]
        public void Test_Chek_Students()
        {
            var students_page = new ViewStudentsPage(driver);
            students_page.Open();
            var students = students_page.GetRegisteredStudents();
            foreach(var student in students)
            {
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.LastIndexOf(")") == student.Length - 1);
            }
         
        }


    }
}
