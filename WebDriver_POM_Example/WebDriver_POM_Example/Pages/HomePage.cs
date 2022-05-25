

using OpenQA.Selenium;

namespace WebDriver_POM_Example.Pages
{
    public class HomePage : BasePage
    {
        // Constructor
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/";

        public IWebElement studentCount => driver.FindElement(By.CssSelector("html body p b")); //copy-> CSS Path

        public int GetStudentCount()
        {
            return int.Parse(studentCount.Text);    
        }

    }
}
