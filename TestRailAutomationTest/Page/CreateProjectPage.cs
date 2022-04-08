using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Logger;
using TestRailAutomationTest.Model.ProjectModel.Enum;
using TestRailAutomationTest.Page.Constants;
using TestRailAutomationTest.WebElement.Service;
using TestRailAutomationTest.WebElement.Wrapper;

namespace TestRailAutomationTest.Page
{
    public class CreateProjectPage : BasePage
    {
        public const string PageName = "Add project page";

        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Project')]");

        private Button AcceptAddingButton => new(Driver, ProjectProperties.AcceptButtonId, "Add project");
        private Input NameInput => new(Driver, ProjectProperties.NameInputId, "Name");
        private Textarea AnnouncementInput => new(Driver, WrapperHelper.BuildIdXpath(ProjectProperties.AnnouncementInputId), "Announcement");
        private Checkmark ShowAnnouncementCheckmark => new(Driver, ProjectProperties.ShowAnnouncementCheckmarkId, "Show announcement");
        private Radio SingleModeRadio => new(Driver, ProjectProperties.SingleSuiteModeId, "Single suite mode");
        private Radio SingleBaseLineRadio => new(Driver, ProjectProperties.SingleBaseLineSuiteModeId, "Single baseline suite mode");
        private Radio MultipleModeRadio => new(Driver, ProjectProperties.MultipleModeId, "Multiple suite mode");

        public CreateProjectPage(IWebDriver? driver) : base(driver)
        {
        }

        public CreateProjectPage FillAddProjectForm(Model.ProjectModel.Project project)
        {
            NameInput.SetValue(project.Name);
            AnnouncementInput.SetValue(project.Announcement);
            FillShowAnnouncementCheckMark(project.IsAnnouncementVisible);
            SelectProjectType(project.ProjectType);
            return this;
        }

        private void FillShowAnnouncementCheckMark(bool isTickTheCheckMark)
        {
            if (isTickTheCheckMark)
            {
                ShowAnnouncementCheckmark.Click();
            }
        }

        private void SelectProjectType(ProjectType projectType)
        {
            switch (projectType)
            {
                case ProjectType.SingleRepositoryForAllCases:
                    SingleModeRadio.Click();
                    break;
                case ProjectType.SingleRepositoryWithBaselineSupport:
                    SingleBaseLineRadio.Click();
                    break;
                case ProjectType.MultipleTestSuites:
                    MultipleModeRadio.Click();
                    break;
                default:
                    var message = $"Project type {projectType} doesn't exist";
                    LoggerSingleton.GetLogger().Error(message);
                    throw new IncorrectDataException(message);
            }
        }

        public void PressAcceptButton() => AcceptAddingButton.Click();
    }
}
