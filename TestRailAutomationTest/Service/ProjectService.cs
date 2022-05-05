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
        private const string AddProjectRequest = $"{Prefix}{Api}{Version}{AddProject}";
        
        public static Task<RestResponse<Project>> CreateProject(HttpClient client, Project project)
        {
            var request = new RestRequest(AddProjectRequest, Method.Post)
                .AddHeader(Headers.ContentType, ContentTypes.ApplicationJson)
                .AddBody(project);
            return client.SendRequest<Project>(request);
        }

        public static void CheckResponseStatusCode<T>(RestResponse<T> response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpStatusCodeException("Request status code is not ok!");
            }
        }
    }
}
