using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Model.ProjectModel.Enum;

namespace TestRailAutomationTest.Page
{
    public class CreateProjectPage : BasePage
    {
        public const string PageName = "Add project page";

        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Project')]");
        private static readonly By NameInputLocation = By.Id("name");
        private static readonly By AnnouncementLocation = By.Id("announcement");
        private static readonly By AcceptButtonLocation = By.Id("accept");
        private static readonly By ShowAnnouncementCheckMarkLocation = By.Id("show_announcement");
        private static readonly By SingleSuiteModeLocation = By.Id("suite_mode_single");
        private static readonly By SingleBaseLineSuiteModeLocation =
            By.Id("suite_mode_single_baseline");
        private static readonly By MultipleModeLocation = By.Id("suite_mode_multi");

        public CreateProjectPage(IWebDriver? driver) : base(driver)
        {
        }

        public CreateProjectPage FillAddProjectForm(Model.ProjectModel.Project project)
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
                    throw new IncorrectDataException($"Project type {projectType} doesn't exist");
            }
        }

        public void PressAcceptButton() => ClickButton(AcceptButtonLocation);
    }
}
