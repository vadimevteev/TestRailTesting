using System;
using RestSharp;
using RestSharp.Authenticators;
using TestRailAutomationTest.Model;

namespace TestRailAutomationTest.Client
{
    public class WebClient
    {
        private readonly RestClient _client;

        public WebClient(string url)
        {
            _client = new RestClient(url);
        }

        public void Login(User user)
        {
            _client.Authenticator = new HttpBasicAuthenticator(user.Email, user.Password);
        }

        public void SendRequest(RestRequest request)
        {
            _client.Execute(request);
        }
    }
}
