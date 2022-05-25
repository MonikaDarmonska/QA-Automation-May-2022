

using OpenQA.Selenium;

namespace WebDriver_POM_Example.Pages
{
    public class AddStudentPage : BasePage
    {
        // Constructor
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement InputName => driver.FindElement(By.Id("name"));
        public IWebElement InputEmail => driver.FindElement(By.Id("email"));
        public IWebElement AddButton => driver.FindElement(By.CssSelector("html body form button"));

        //public IWebElement AddButton => driver.FindElement(By.CssSelector("button[type='submit']"));

        public IWebElement ErrorMessage => driver.FindElement(By.CssSelector("body > div"));


        public void registerStudent(string name, string email)
        {
            this.InputName.SendKeys(name);
            this.InputEmail.SendKeys(email);
            this.AddButton.Click();
        }
        
        

    }
}
