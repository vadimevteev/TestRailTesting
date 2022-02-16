using System.Linq;
using NUnit.Framework;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Project;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public class CreateTestCase : BaseTest
{
    [Test]
    public void CreateTestCase_WithRequiredAndAllFields_ShouldBeSuccessful()
    {
        LoginPage.OpenStartPage();
        LoginPage
            .FillLoginForm(Users.FirstOrDefault()!)
            .PressFindButton();
        
        HomePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
        HomePage
            .ClickAddProjectButton();
        
        AddProjectPage.WaitForOpen(AddProjectPage.PageName, AddProjectPage.HeaderTitleLocation);

        var project = ProjectCreator.CreateRandomRequiredFields();
        AddProjectPage
            .FillAddProjectForm(project)
            .PressAcceptButton();
        
        ProjectsMenuPage.WaitForOpen(ProjectsMenuPage.PageName, ProjectsMenuPage.MenuProjectItemSelected);
        ProjectsMenuPage.OpenHomePage();
        
        HomePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
        HomePage.OpenProject(project.Name);
        
        OverviewPage.WaitForOpen(OverviewPage.PageName, OverviewPage.ChartLineLocation);
        OverviewPage.OpenTestCasesPage();

        TestCasesPage.WaitForOpen(TestCasesPage.PageName, TestCasesPage.HeaderTitleLocation);
        TestCasesPage.AddTestCase();
    }
}
