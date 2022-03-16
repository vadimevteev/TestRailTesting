using OpenQA.Selenium;
using TestRailAutomationTest.Model.ProjectModel;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page.Project
{
    public class ProjectOverviewPage : BasePage
    {
        public const string PageName = "Project overview page";
        public static readonly By ChartLineLocation = By.Id("chart-line-fc");
        private static readonly By ProjectNameLocation =
            By.XPath("//div[@id=\"content-header\"]//div[contains(@class,\"content-header-title\")]");
        private static readonly By TestCaseTabLocation = By.Id("navigation-suites");
        private static readonly By AnnouncementLocation =
            By.XPath("//div[@id=\"content-inner\"]/div[@class=\"markdown\"]/p");

        public ProjectOverviewPage(IWebDriver? driver) : base(driver)
        {
        }

        public void OpenTestCasesPage() => ClickButton(TestCaseTabLocation);

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
