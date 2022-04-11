using TestRailAutomationTest.Model.ProjectModel;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Project;

namespace TestRailAutomationTest.Steps
{
    public class ProjectSteps
    {
        private readonly HomePage _homePage;
        private readonly CreateProjectPage _createProjectPage;
        private readonly ProjectsMenuPage _projectsMenuPage;
        private readonly ProjectOverviewPage? _projectOverviewPage;

        public ProjectSteps(HomePage homePage, CreateProjectPage createProjectPage, ProjectsMenuPage projectsMenuPage)
        {
            _homePage = homePage;
            _createProjectPage = createProjectPage;
            _projectsMenuPage = projectsMenuPage;
        }
        
        public ProjectSteps(HomePage homePage, CreateProjectPage createProjectPage, ProjectsMenuPage projectsMenuPage, ProjectOverviewPage projectOverviewPage)
        {
            _homePage = homePage;
            _createProjectPage = createProjectPage;
            _projectsMenuPage = projectsMenuPage;
            _projectOverviewPage = projectOverviewPage;
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

        public Project GetActualProject()
        { 
            _projectOverviewPage?.WaitForOpen(ProjectOverviewPage.PageName, ProjectOverviewPage.ChartLineLocation);
            return _projectOverviewPage?.GetProject()!;
        }
    }
}
