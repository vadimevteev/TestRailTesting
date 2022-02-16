using OpenQA.Selenium;
using TestRailAutomationTest.Model.Project;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page.Project;

public class OverviewPage : BasePage
{
    public const string PageName = "Project page"; 
    private static readonly By ProjectNameLocation = By.XPath("//div[@id=\"content-header\"]//div[contains(@class,\"content-header-title\")]");
    private static readonly By TestCaseTabLocation = By.XPath("//a[@id=\"navigation-suites\"]");
    private static readonly By AnnouncementLocation =
        By.XPath("//div[@id=\"content-inner\"]/div[@class=\"markdown\"]/p");
    public static readonly By ChartLineLocation = By.XPath("//div[@id=\"chart-line-fc\"]");

    public OverviewPage(IWebDriver? driver) : base(driver)
    {
    }

    public OverviewPage OpenTestCasesPage()
    {
        ClickButton(TestCaseTabLocation);
        return this;
    }
    
    public Model.Project.Project GetProject()
    {
        return new Model.Project.Project
        {
            Name = GetProjectName(),
            Announcement = GetProjectAnnouncement(),
            IsAnnouncementVisible = IsShownAnnouncement()
        };
    }

    private string GetProjectName()
    {
        return Waits.WaitElementExistence(Driver, ProjectNameLocation).Text;
    }

    private bool IsShownAnnouncement()
    {
        return IsElementExistOnPage(AnnouncementLocation, ReducedTimeout);
    }

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
