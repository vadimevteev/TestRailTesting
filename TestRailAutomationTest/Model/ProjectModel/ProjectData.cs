using TestRailAutomationTest.Model.ProjectModel.Enum;
using TestRailAutomationTest.Utils;

namespace TestRailAutomationTest.Model.ProjectModel
{
    public static class ProjectData
    {
        public static ProjectType GetRandomProjectType()
        {
            return RandomData.Faker.PickRandom<ProjectType>();
        }
    }
}
