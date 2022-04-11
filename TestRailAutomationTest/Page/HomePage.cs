using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page
{
    public class HomePage : BasePage
    {
        public const string PageName = "Home page";
        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'All Projects')]");
        private static readonly By UserNameLocation =
            By.XPath("//*[@id=\"navigation-user\"]/span[@class=\"navigation-username\"]");
        private const string AddProjectButtonId = "sidebar-projects-add";

        private Button AddProjectButton => new(Driver, AddProjectButtonId, "Add project");
        private static string ProjectLinkXPath(string projectName) => $"//a[text()=\"{projectName}\"]";
        private ButtonLink ProjectLink(string projectName) => new(Driver, ProjectLinkXPath(projectName), projectName);

        public HomePage(IWebDriver? driver) : base(driver)
        {
        }

        public void ClickAddProjectButton() => AddProjectButton.Click();

        public void OpenProject(string projectName)
        {
            try
            {
                ProjectLink(projectName).Click();
            }
            catch (WebDriverTimeoutException)
            {
                throw new IncorrectDataException($"Incorrect project {projectName}");
            }
        }

        public string GetCurrentUserName() => Waits.WaitElementExistence(Driver, UserNameLocation).Text;
    }
}
