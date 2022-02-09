using OpenQA.Selenium;
using TestRailAutomationTest.Model;

namespace TestRailAutomationTest.Page;

public class AddProjectPage : BasePage
{
    public static readonly By HeaderTitleLocation =
        By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Project')]");
    private static readonly By NameInputLocation = By.XPath("//input[@id=\"name\"]");
    private static readonly By AnnouncementLocation = By.XPath("//textarea[@id=\"announcement\"]");
    private static readonly By AcceptButtonLocation = By.XPath("//button[@id=\"accept\"]");
    private static readonly By ShowAnnouncementCheckMarkLocation = By.XPath("//input[@id=\"show_announcement\"]");
    
    
    public AddProjectPage(IWebDriver? driver) : base(driver)
    {
    }

    public AddProjectPage FillAddProjectForm(Project project)
    {
        FillInput(NameInputLocation, project.Name);
        FillInput(AnnouncementLocation, project.Announcement);
        return this;
    }

    public AddProjectPage PressAcceptButton()
    {
        ClickButton(AcceptButtonLocation);
        return this;
    }
}
