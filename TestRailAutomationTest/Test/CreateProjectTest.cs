using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TestRailAutomationTest.Model.ProjectModel;
using TestRailAutomationTest.Service;
using TestRailAutomationTest.Steps;

namespace TestRailAutomationTest.Test
{
    public class CreateProjectTest : BaseTest
    {
        private static IEnumerable<Project> Projects => new[]
            {ProjectCreator.CreateRandomRequiredFields(), ProjectCreator.CreateRandomWithAllFields()};

        [TestCaseSource(nameof(Projects)), Description(
             "Create project with requried/all fields should be successful, " +
             "project with with requried/all fields should be created")]
        public void CreateProject_WithRequiredAndAllFields_ShouldBeSuccessful(Project expectedProject)
        {
            LoginSteps loginSteps = new(LoginPage);
            ProjectSteps projectSteps = new(HomePage, CreateProjectPage, ProjectsMenuPage, ProjectOverviewPage);
            
            loginSteps.Login(Users.FirstOrDefault()!);
            projectSteps.CreateProject(expectedProject);
            projectSteps.OpenProject(expectedProject);
            var actualProject = projectSteps.GetActualProject();

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
}
