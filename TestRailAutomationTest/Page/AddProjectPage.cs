using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Model.Project;
using TestRailAutomationTest.Model.Project.Enum;

namespace TestRailAutomationTest.Page.Project;

public class AddProjectPage : BasePage
{
    public const string PageName = "Add project page";
    public static readonly By HeaderTitleLocation =
        By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Project')]");
    private static readonly By NameInputLocation = By.XPath("//input[@id=\"name\"]");
    private static readonly By AnnouncementLocation = By.XPath("//textarea[@id=\"announcement\"]");
    private static readonly By AcceptButtonLocation = By.XPath("//button[@id=\"accept\"]");
    private static readonly By ShowAnnouncementCheckMarkLocation = By.XPath("//input[@id=\"show_announcement\"]");
    private static readonly By SingleSuiteModeLocation = By.XPath("//input[@id=\"suite_mode_single\"]");
    private static readonly By SingleBaseLineSuiteModeLocation =
        By.XPath("//input[@id=\"suite_mode_single_baseline\"]");
    private static readonly By MultipleModeLocation = By.XPath("//input[@id=\"suite_mode_multi\"]");
    
    public AddProjectPage(IWebDriver? driver) : base(driver)
    {
    }

    public AddProjectPage FillAddProjectForm(Model.Project.Project project)
    {
        FillInput(NameInputLocation, project.Name);
        FillInput(AnnouncementLocation, project.Announcement);
        FillShowAnnouncementCheckMark(project.IsAnnouncementVisible);
        SelectProjectType(project.ProjectType);
        return this;
    }

    private void FillShowAnnouncementCheckMark(bool isTickTheCheckMark)
    {
        if (isTickTheCheckMark)
        {
            ClickButton(ShowAnnouncementCheckMarkLocation);
        }
    }

    private void SelectProjectType(ProjectType projectType)
    {
        switch (projectType)
        {
            case ProjectType.SingleRepositoryForAllCases:
                ClickButton(SingleSuiteModeLocation);
                break;
            case ProjectType.SingleRepositoryWithBaselineSupport:
                ClickButton(SingleBaseLineSuiteModeLocation);
                break;
            case ProjectType.MultipleTestSuites:
                ClickButton(MultipleModeLocation);
                break;
            default:
                throw new IncorrectDataException("Incorrect project type");
        }
    }

    public AddProjectPage PressAcceptButton()
    {
        ClickButton(AcceptButtonLocation);
        return this;
    }
}
