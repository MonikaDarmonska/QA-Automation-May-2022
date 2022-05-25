
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace WebDriver_POM_Example.Pages
{
    public class ViewStudentsPage : BasePage
    {
        // Constructor
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";

        public ReadOnlyCollection<IWebElement> ListItemsWithStudents =>
             driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudents()
        {
            var elementsStudent = this.ListItemsWithStudents.Select(s => s.Text).ToArray();
            return elementsStudent;
        }

        
    }
}
