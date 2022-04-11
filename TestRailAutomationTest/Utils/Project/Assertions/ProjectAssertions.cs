using FluentAssertions;

namespace TestRailAutomationTest.Utils.Project.Assertions;

public static class ProjectHelper
{
    public static void ValidateAnnouncement(Model.ProjectModel.Project expectedProject, Model.ProjectModel.Project actualProject)
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
