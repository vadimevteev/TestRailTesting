using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Model.ProjectModel;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Steps;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Test
{
    public class CreateProjectTest : BaseTest
    {
        private LoginSteps? _loginSteps;
        private ProjectSteps? _projectSteps;
        private static IEnumerable<Project> Projects => new[]
            {ProjectCreator.CreateRandomRequiredFields(), ProjectCreator.CreateRandomWithAllFields()};
        
        [SetUp]
        public void SetUp()
        {
            _loginSteps = new LoginSteps(LoginPage);
            _projectSteps = new ProjectSteps(HomePage, CreateProjectPage, ProjectsMenuPage, ProjectOverviewPage);
            _loginSteps.Login(Users.FirstOrDefault()!);
        }

        [TestCaseSource(nameof(Projects)), Description(
             "Create project with requried/all fields should be successful, " +
             "project with with requried/all fields should be created")]
        public void CreateProject_WithRequiredAndAllFields_ShouldBeSuccessful(Project expectedProject)
        {
            _projectSteps!.CreateProject(expectedProject);
            _projectSteps.OpenProject(expectedProject);
            var actualProject = _projectSteps.GetActualProject();

            expectedProject.Name.Should().Be(actualProject.Name);
            ProjectHelper.ValidateAnnouncement(expectedProject, actualProject);
        }
    }
}
