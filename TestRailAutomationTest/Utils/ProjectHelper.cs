using FluentAssertions;
using TestRailAutomationTest.Model.ProjectModel;

namespace TestRailAutomationTest.Utils;

public static class ProjectHelper
{
    public static void ValidateAnnouncement(Project expectedProject, Project actualProject)
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
