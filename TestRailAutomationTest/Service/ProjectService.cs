using System.Net;
using System.Threading.Tasks;
using RestSharp;
using TestRailAutomationTest.Client;
using TestRailAutomationTest.Exception;
using TestRailAutomationTest.Model.ProjectModel;
using TestRailAutomationTest.Service.ConstantsAPI;
using static TestRailAutomationTest.Service.ConstantsAPI.EndPoints;

namespace TestRailAutomationTest.Service
{
    public static class ProjectService
    {
        private const string AddProjectRequest = Prefix + Api + Version + AddProject;
        
        public static async Task<Project> CreateProject(HttpClient client, Project project)
        {
            var request = new RestRequest(AddProjectRequest, Method.Post)
                .AddHeader(Headers.ContentType, ContentTypes.ApplicationJson)
                .AddBody(project);
            
            var response = await client.SendRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ClientRequestException("Request status code is not ok!");
            }

            return response.Data!;
        }
    }
}
