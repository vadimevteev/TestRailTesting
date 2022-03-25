using TestRailAutomationTest.Model.ProjectModel;
using TestRailAutomationTest.Page;

namespace TestRailAutomationTest.Steps
{
    public class ProjectSteps
    {
        private readonly HomePage _homePage;
        private readonly CreateProjectPage _createProjectPage;
        private readonly ProjectsMenuPage _projectsMenuPage;

        public ProjectSteps(HomePage homePage, CreateProjectPage createProjectPage, ProjectsMenuPage projectsMenuPage)
        {
            _homePage = homePage;
            _createProjectPage = createProjectPage;
            _projectsMenuPage = projectsMenuPage;
        }

        public void CreateProject(Project project)
        {
            _homePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
            _homePage
                .ClickAddProjectButton();
            _createProjectPage.WaitForOpen(CreateProjectPage.PageName, CreateProjectPage.HeaderTitleLocation);
            _createProjectPage
                .FillAddProjectForm(project)
                .PressAcceptButton();
            _projectsMenuPage.WaitForOpen(ProjectsMenuPage.PageName, ProjectsMenuPage.MenuProjectItemSelected);
            _projectsMenuPage.OpenHomePage();
        }

        public void OpenProject(Project project)
        {
            _homePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
            _homePage.OpenProject(project.Name);
        }
    }
}
