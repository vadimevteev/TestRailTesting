using System.Linq;
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
    }
}
