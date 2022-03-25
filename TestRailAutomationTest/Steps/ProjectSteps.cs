using TestRailAutomationTest.Model.ProjectModel;
using TestRailAutomationTest.Page;

namespace TestRailAutomationTest.Steps
{
    public class ProjectSteps
    {
        private readonly HomePage _homePage;
        private readonly CreateProjectPage _createProjectPage;
        private readonly ProjectsMenuPage _projectsMenuPage;
        private readonly Project _project;

        public ProjectSteps(HomePage homePage, CreateProjectPage createProjectPage, ProjectsMenuPage projectsMenuPage, Project project)
        {
            _homePage = homePage;
            _createProjectPage = createProjectPage;
            _projectsMenuPage = projectsMenuPage;
            _project = project;
        }

        public void CreateProject()
        {
            _homePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
            _homePage
                .ClickAddProjectButton();
            _createProjectPage.WaitForOpen(CreateProjectPage.PageName, CreateProjectPage.HeaderTitleLocation);
            _createProjectPage
                .FillAddProjectForm(_project)
                .PressAcceptButton();
            _projectsMenuPage.WaitForOpen(ProjectsMenuPage.PageName, ProjectsMenuPage.MenuProjectItemSelected);
            _projectsMenuPage.OpenHomePage();
        }

        public void OpenProject()
        {
            _homePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
            _homePage.OpenProject(_project.Name);
        }
    }
}
