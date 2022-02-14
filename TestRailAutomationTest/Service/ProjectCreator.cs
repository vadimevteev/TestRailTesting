using TestRailAutomationTest.Model;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Service;

public static class ProjectCreator
{
    public static Project CreateRandomWithAllFields()
    {
        return new Project()
        {
            Name = RandomData.GetCompanyName(),
            Announcement = RandomData.GetText(),
            IsAnnouncementVisible = RandomData.GetBool(),
            ProjectType = RandomData.GetProjectType()
        };
    }

    public static Project CreateRandomRequiredFields()
    {
        return new Project()
        {
            Name = RandomData.GetCompanyName(),
            Announcement = "",
            IsAnnouncementVisible = false,
            ProjectType = ProjectType.SingleRepositoryForAllCases
        };
    }
}
