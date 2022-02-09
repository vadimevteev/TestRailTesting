using TestRailAutomationTest.Model;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Service;

public static class ProjectCreator
{
    public static Project CreateRandomWithAllFields()
    {
        return new Project()
        {
            Name = RandomData.GetName(),
            Announcement = RandomData.GetRandomText()
        };
    }

    public static Project CreateRandomRequiredFields()
    {
        return new Project()
        {
            Name = RandomData.GetName(),
            Announcement = ""
        };
    }
}
