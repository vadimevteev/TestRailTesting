using TestRailAutomationTest.Model.Project.Enum;

namespace TestRailAutomationTest.Model.Project
{

    public class Project
    {
        public string Name { get; set; }

        public string Announcement { get; set; }

        public bool IsAnnouncementVisible { get; set; }

        public ProjectType ProjectType { get; set; }
    }
}
