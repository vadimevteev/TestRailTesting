using System.Text.Json.Serialization;
using Newtonsoft.Json;
using TestRailAutomationTest.Model.ProjectModel.Enum;

namespace TestRailAutomationTest.Model.ProjectModel
{
    public class Project
    {
        public string Name { get; set; }
        
        public string Announcement { get; set; }
        
        [JsonPropertyName("show_announcement")]
        public bool IsAnnouncementVisible { get; set; }

        [JsonPropertyName("suite_mode")]
        public ProjectType ProjectType { get; set; }
    }
}
