using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using TestRailAutomationTest.Model;
using TestRailAutomationTest.Model.ProjectModel;

namespace TestRailAutomationTest.Client
{
    public class HttpClient
    {
        private readonly RestClient _client;

        public HttpClient(string url)
        {
            _client = new RestClient(url);
        }

        public void Login(User user)
        {
            _client.Authenticator = new HttpBasicAuthenticator(user.Email, user.Password);
        }

        public async Task<RestResponse<T>> SendRequest<T>(RestRequest request)
        {
            return await _client.ExecuteAsync<T>(request);
        }
    }
}
