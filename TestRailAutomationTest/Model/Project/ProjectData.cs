using TestRailAutomationTest.Model.Project.Enum;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Model.Project
{
    public static class ProjectData
    {
        public static ProjectType GetRandomProjectType()
        {
            return RandomData.Faker.PickRandom<ProjectType>();
        }
    }
}
