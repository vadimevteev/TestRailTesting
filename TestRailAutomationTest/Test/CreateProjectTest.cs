using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Page;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public class CreateProjectTest : BaseTest
{
    private static IEnumerable<Project> Projects => new[] {ProjectCreator.CreateRandomRequiredFields(), ProjectCreator.CreateRandomWithAllFields()};

    [TestCaseSource(nameof(Projects))]
    public void CreateProject_ShouldBeSuccessful(Project expectedProject)
    {
        LoginPage.OpenStartPage();
        LoginPage
            .FillLoginForm(Users.FirstOrDefault()!)
            .PressFindButton();
        HomePage.WaitForOpen(HomePage.HeaderTitleLocation);
        HomePage
            .ClickAddProjectButton();
        AddProjectPage.WaitForOpen(AddProjectPage.HeaderTitleLocation);
        AddProjectPage
            .FillAddProjectForm(expectedProject)
            .PressAcceptButton();
        OverviewPage.WaitForOpen(OverviewPage.MenuProjectItemSelected);
        OverviewPage.GoToHomePage();
        HomePage.WaitForOpen(HomePage.HeaderTitleLocation);
        HomePage.GoToProjectPage(expectedProject.Name);
        ProjectPage.WaitForOpen(ProjectPage.ChartLineLocation);
        var actualProject = new Project
        {
            Name = ProjectPage.GetProjectName(),
            Announcement = ProjectPage.GetProjectAnnouncement(),
            IsAnnouncementVisible = ProjectPage.IsShownAnnouncement()
        };
        expectedProject.Name.Should().Be(actualProject.Name);
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
