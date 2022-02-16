using System;
using OpenQA.Selenium;
using TestRailAutomationTest.Model.Project;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Page;

public class ProjectPage : BasePage
{
    public const string PageName = "Project page"; 
    private static readonly By ProjectNameLocation = By.XPath("//div[@id=\"content-header\"]//div[contains(@class,\"content-header-title\")]");
    private static readonly By AnnouncementLocation =
        By.XPath("//div[@id=\"content-inner\"]/div[@class=\"markdown\"]/p");
    public static readonly By ChartLineLocation = By.XPath("//div[@id=\"chart-line-fc\"]");

    public ProjectPage(IWebDriver? driver) : base(driver)
    {
    }

    public Project GetProject()
    {
        return new Project
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
