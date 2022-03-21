using TestRailAutomationTest.Model.ProjectModel;
using TestRailAutomationTest.Page;

namespace TestRailAutomationTest.Steps
{
    public static class ProjectSteps
    {
        public static void CreateProject(HomePage homePage, CreateProjectPage createProjectPage, ProjectsMenuPage projectsMenuPage, Project project)
        {
            homePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
            homePage
                .ClickAddProjectButton();

            createProjectPage.WaitForOpen(CreateProjectPage.PageName, CreateProjectPage.HeaderTitleLocation);
            createProjectPage
                .FillAddProjectForm(project)
                .PressAcceptButton();
            projectsMenuPage.WaitForOpen(ProjectsMenuPage.PageName, ProjectsMenuPage.MenuProjectItemSelected);
            projectsMenuPage.OpenHomePage();
        }

        public static void OpenProject(HomePage homePage, Project project)
        {
            homePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
            homePage.OpenProject(project.Name);
        }
    }
}
