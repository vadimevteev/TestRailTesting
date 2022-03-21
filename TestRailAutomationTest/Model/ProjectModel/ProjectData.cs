using TestRailAutomationTest.Model.ProjectModel.Enum;
using static TestRailAutomationTest.Utils.RandomData;

namespace TestRailAutomationTest.Model.ProjectModel
{
    public static class ProjectData
    {
        public static ProjectType GetRandomProjectType()
        {
            return Faker.PickRandom<ProjectType>();
        }
    }
}
