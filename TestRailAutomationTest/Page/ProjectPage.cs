using OpenQA.Selenium;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page;

public class ProjectPage : BasePage
{
    private static readonly By ProjectNameLocation = By.XPath("//div[@id=\"content-header\"]//div[contains(@class,\"content-header-title\")]");
    private static readonly By AnnouncementLocation =
        By.XPath("//div[@id=\"content-inner\"]/div[@class=\"markdown\"]/p");
    public static readonly By ChartLineLocation = By.XPath("//div[@id=\"chart-line-fc\"]");

    public ProjectPage(IWebDriver? driver) : base(driver)
    {
    }

    public string GetProjectName()
    {
        return Waits.WaitElementExistence(Driver, ProjectNameLocation).Text;
    }

    public bool IsShownAnnouncement()
    {
        return IsElementExistOnPage(AnnouncementLocation);
    }

    public string GetProjectAnnouncement()
    {
        try
        {
            return Waits.WaitElementExistence(Driver, AnnouncementLocation).Text;
        }
        catch (WebDriverTimeoutException)
        {
            return "";
        }
    }
}
