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
        private const string ProjectExample = "ProjectName";
        private const string CommonProjectLocation = "//a[text()='" + ProjectExample + "']";

        public HomePage(IWebDriver? driver) : base(driver)
        {
        }
        
        public void ClickAddProjectButton() => ClickButton(AddProjectButtonLocation);

        public void OpenProject(string projectName)
        {
            try
            {
                ClickButton(By.XPath(CommonProjectLocation.Replace(ProjectExample, projectName)));
            }
            catch (WebDriverTimeoutException)
            {
                throw new IncorrectDataException($"Project {projectName} doesn't exist");
            }
        }

        public string GetCurrentUserName() => Waits.WaitElementExistence(Driver, UserNameLocation).Text;
    }
}
