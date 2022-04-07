using OpenQA.Selenium;
using TestRailAutomationTest.Logger;
using TestRailAutomationTest.Model.ProjectModel;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page.Project
{
    public class ProjectOverviewPage : BasePage
    {
        public const string PageName = "Project overview page";
        public static readonly By ChartLineLocation = By.Id("chart-line-fc");
        private static readonly By ProjectNameLocation =
            By.XPath("//div[@id=\"content-header\"]//div[contains(@class,\"content-header-title\")]");
        private const string TestCaseTabId = "navigation-suites";
        private static readonly By AnnouncementLocation =
            By.XPath("//div[@id=\"content-inner\"]/div[@class=\"markdown\"]/p");

        private Button TestCasesButton => new(Driver, TestCaseTabId, "Test Cases");

        public ProjectOverviewPage(IWebDriver? driver) : base(driver)
        {
        }

        public void OpenTestCasesPage() => TestCasesButton.Click();

        public Model.ProjectModel.Project GetProject()
        {
            return new Model.ProjectModel.Project()    
            {
                Name = GetProjectName(),
                Announcement = GetProjectAnnouncement(),
                IsAnnouncementVisible = IsShownAnnouncement()
            };
        }

        private string GetProjectName() => Waits.WaitElementExistence(Driver, ProjectNameLocation).Text;

        private bool IsShownAnnouncement() => IsElementExistOnPage(AnnouncementLocation, ReducedTimeout);

        private string GetProjectAnnouncement()
        {
            try
            {
                return Waits.WaitElementExistence(Driver, AnnouncementLocation, ReducedTimeout).Text;
            }
            catch (WebDriverTimeoutException)
            {
                return "";
            }
        }
    }
}
