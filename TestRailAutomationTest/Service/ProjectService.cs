using System.Net;
using RestSharp;
using TestRailAutomationTest.Model.ProjectModel;
using WebClient = TestRailAutomationTest.Client.WebClient;

namespace TestRailAutomationTest.Service
{
    public static class ProjectService
    {
        private const string AddProjectRequest = "index.php?/api/v2/add_project";
        
        public static void CreateProject(WebClient client, Project project)
        {
            var request = new RestRequest(AddProjectRequest, Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddBody(project);
            client.SendRequest(request);
        }
    }
}
