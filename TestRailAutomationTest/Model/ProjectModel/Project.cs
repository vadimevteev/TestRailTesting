using TestRailAutomationTest.Model.ProjectModel.Enum;

namespace TestRailAutomationTest.Model.ProjectModel
{
    public class Project
    {
        public string Name { get; set; }

        public string Announcement { get; set; }

        public bool IsAnnouncementVisible { get; set; }

        public ProjectType ProjectType { get; set; }
    }
}
