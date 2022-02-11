using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public class CreateProjectTest : BaseTest
{
    private static IEnumerable<Project> Projects => new[] {ProjectCreator.CreateRandomRequiredFields(), ProjectCreator.CreateRandomWithAllFields()};

    [TestCaseSource(nameof(Projects))]
    public void CreateProject_ShouldBeSuccessful(Project expectedProject)
    {
        //TODO: Waits for opening all pages
        
        LoginPage.OpenStartPage();
        LoginPage
            .FillLoginForm(Users.FirstOrDefault()!)
            .PressFindButton();
        HomePage.WaitForOpen(Page.HomePage.HeaderTitleLocation);
        HomePage
            .ClickAddProjectButton();
        AddProjectPage.WaitForOpen(Page.AddProjectPage.HeaderTitleLocation);
        AddProjectPage
            .FillAddProjectForm(expectedProject)
            .PressAcceptButton();
        OverviewPage.GoToHomePage();
        HomePage.WaitForOpen(Page.HomePage.HeaderTitleLocation);
        HomePage.GoToProjectPage(expectedProject.Name);
        var actualProject = new Project()
        {
            Name = ProjectPage.GetProjectName(),
            Announcement = ProjectPage.GetProjectAnnouncement(),
            IsShowAnnouncement = ProjectPage.IsShownAnnouncement()
        };
        //TODO: IF(exp.IsShow == act.IsShow == false) -> always equals
        // TODO: if(exp.IsShow == act.IsShow == true) -> compare announcements
        // TODO: if(exp.IsShow == true, act.IsShow == false) -> compare exp.announcemet with empty string
        // expectedProject.Should().BeEquivalentTo(actualProject,
        //     options => options
        //         .Including(o => o.Name)
        //         .Including(o => o.IsShowAnnouncement));
        // if (actualProject.IsShowAnnouncement)
        // {
        //     
        // }
    }
}
