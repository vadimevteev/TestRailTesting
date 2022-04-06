using OpenQA.Selenium;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Logger;
using TestRailAutomationTest.Model.ProjectModel.Enum;
using TestRailAutomationTest.Utils;
using TestRailAutomationTest.Wrapper;

namespace TestRailAutomationTest.Page
{
    public class CreateProjectPage : BasePage
    {
        public const string PageName = "Add project page";

        public static readonly By HeaderTitleLocation =
            By.XPath("//*[@id=\"content-header\"]//div[contains(text(),'Add Project')]");
        private const string NameInputId = "name";
        private const string AnnouncementInputId = "announcement";
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
            new Input(Driver,NameInputId,"Name" ).SetValue(project.Name);
            new Input(Driver,AnnouncementInputId, "Announcement").SetValue(project.Announcement);
            FillShowAnnouncementCheckMark(project.IsAnnouncementVisible);
            SelectProjectType(project.ProjectType);
            return this;
        }

        private void FillShowAnnouncementCheckMark(bool isTickTheCheckMark)
        {
            if (isTickTheCheckMark)
            {
                ClickButton(ShowAnnouncementCheckMarkLocation);
                LoggerHelper.LogButtonClick("Show Announcement checkmark");
            }
        }

        private void SelectProjectType(ProjectType projectType)
        {
            switch (projectType)
            {
                case ProjectType.SingleRepositoryForAllCases:
                    ClickButton(SingleSuiteModeLocation);
                    LoggerHelper.LogButtonClick("Single suite mode");
                    break;
                case ProjectType.SingleRepositoryWithBaselineSupport:
                    ClickButton(SingleBaseLineSuiteModeLocation);
                    LoggerHelper.LogButtonClick("Single repository with baseline mode");
                    break;
                case ProjectType.MultipleTestSuites:
                    ClickButton(MultipleModeLocation);
                    LoggerHelper.LogButtonClick("Multiple mode");
                    break;
                default:
                    var message = $"Project type {projectType} doesn't exist";
                    LoggerSingleton.GetLogger().Error(message);
                    throw new IncorrectDataException(message);
            }
        }

        public void PressAcceptButton()
        { 
            ClickButton(AcceptButtonLocation);
            LoggerHelper.LogButtonClick("Add project");
        } 
    }
}
