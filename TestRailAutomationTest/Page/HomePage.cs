using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page
{

    public class HomePage : BasePage
    {
        public const string PageName = "Home page";
        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'All Projects')]");
        private static readonly By UserNameLocation =
            By.XPath("//*[@id=\"navigation-user\"]/span[@class=\"navigation-username\"]");
        private static readonly By AddProjectButtonLocation = By.XPath("//a[@id=\"sidebar-projects-add\"]");
        private const string ProjectLocation = "//a[text()='ProjectName']";

        public HomePage(IWebDriver? driver) : base(driver)
        {
        }
        
        public HomePage ClickAddProjectButton()
        {
            ClickButton(AddProjectButtonLocation);
            return this;
        }

        public void OpenProject(string projectName)
        {
            try
            {
                ClickButton(By.XPath(ProjectLocation.Replace("ProjectName", projectName)));
            }
            catch (WebDriverTimeoutException)
            {
                throw new IncorrectDataException($"Project {projectName} doesn't exist");
            }
        }

        public string GetCurrentUserName()
        {
            return Waits.WaitElementExistence(Driver, UserNameLocation).Text;
        }
    }
}
