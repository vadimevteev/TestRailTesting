using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Model.Project;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public class CreateProjectTest : BaseTest
{
    private static IEnumerable<Project> Projects => new[] {ProjectCreator.CreateRandomRequiredFields(), ProjectCreator.CreateRandomWithAllFields()};

    [TestCaseSource(nameof(Projects)), Description("This test checks ability to create project with all and only required fields")]
    public void CreateProject_WithAllAndOnlyRequiredFields_ShouldBeSuccessful(Project expectedProject)
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
        
        OverviewPage.WaitForOpen(OverviewPage.PageName, OverviewPage.MenuProjectItemSelected);
        OverviewPage.GoToHomePage();
        
        HomePage.WaitForOpen(HomePage.PageName, HomePage.HeaderTitleLocation);
        HomePage.OpenProject(expectedProject.Name);
        
        ProjectPage.WaitForOpen(ProjectPage.PageName, ProjectPage.ChartLineLocation);
        var actualProject = ProjectPage.GetProject();
        
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
