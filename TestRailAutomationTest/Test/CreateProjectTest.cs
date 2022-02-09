using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Service;

namespace TestRailAutomationTest.Test;

public class CreateProjectTest : BaseTest
{

    [Test]
    public void CreateProject_WithRequiredFields_ShouldBeSuccessful()
    {
        LoginPage.OpenStartPage();
        LoginPage
            .FillLoginForm(Users.FirstOrDefault()!)
            .PressFindButton()
            .WaitForOpen(Page.HomePage.HeaderTitleLocation);
        HomePage
            .ClickAddProjectButton()
            .WaitForOpen(Page.AddProjectPage.HeaderTitleLocation);
        var projectRequiredFields = ProjectCreator.CreateRandomRequiredFields();
        AddProjectPage
            .FillAddProjectForm(projectRequiredFields)
            .PressAcceptButton();
        OverviewPage.IsProjectExists(projectRequiredFields.Name).Should().BeTrue();
    }

    [Test]
    public void CreateProject_WithAllFields_ShouldBeSuccessful()
    {
        LoginPage.OpenStartPage();
        LoginPage
            .FillLoginForm(Users.FirstOrDefault()!)
            .PressFindButton()
            .WaitForOpen(Page.HomePage.HeaderTitleLocation);
        HomePage
            .ClickAddProjectButton()
            .WaitForOpen(Page.AddProjectPage.HeaderTitleLocation);
        var projectRequiredFields = ProjectCreator.CreateRandomWithAllFields();
        AddProjectPage
            .FillAddProjectForm(projectRequiredFields)
            .PressAcceptButton();
        OverviewPage.IsProjectExists(projectRequiredFields.Name).Should().BeTrue();
    }
}
