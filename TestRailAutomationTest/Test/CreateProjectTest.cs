using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Model.Project;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Page.Project;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public class CreateProjectTest : BaseTest
{
    private static IEnumerable<Project> Projects => new[] {ProjectCreator.CreateRandomRequiredFields(), ProjectCreator.CreateRandomWithAllFields()};

    [TestCaseSource(nameof(Projects)), Description("Create project with requried/all fields should be successful, " +
                                                   "project with with requried/all fields should be created")]
    public void CreateProject_WithRequiredAndAllFields_ShouldBeSuccessful(Project expectedProject)
    {
        LoginPage.OpenStartPage();
        LoginPage
            .FillLoginForm(Users.FirstOrDefault()!)
            .PressFindButton();
        
        HomePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
        HomePage
            .ClickAddProjectButton();
        
        AddProjectPage.WaitForOpen(AddProjectPage.PageName, AddProjectPage.HeaderTitleLocation);
        AddProjectPage
            .FillAddProjectForm(expectedProject)
            .PressAcceptButton();
        
        ProjectsMenuPage.WaitForOpen(ProjectsMenuPage.PageName, ProjectsMenuPage.MenuProjectItemSelected);
        ProjectsMenuPage.OpenHomePage();
        
        HomePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
        HomePage.OpenProject(expectedProject.Name);
        
        OverviewPage.WaitForOpen(OverviewPage.PageName, OverviewPage.ChartLineLocation);
        var actualProject = OverviewPage.GetProject();
        
        expectedProject.Name.Should().Be(actualProject.Name);
        ValidateAnnouncement(expectedProject, actualProject);
    }

    private static void ValidateAnnouncement(Project expectedProject, Project actualProject)
    {
        if (expectedProject.IsAnnouncementVisible)
        {
            expectedProject.Announcement.Should().Be(actualProject.Announcement);
        }
        else
        {
            actualProject.IsAnnouncementVisible.Should().BeFalse();
        }
    }
}
