using System.Net.Http.Json;
using Core.Model;

namespace Core.Services
{
    public class LoginServices : ILoginServices
    {
        HttpClient http;
        private string _serverUrl = "https://localhost:7095";

        public LoginServices(HttpClient http)
        {
            this.http = http;
        }

        public async Task<bool> VerifyLogin(string username, string password)
        {
            var response = await http.GetFromJsonAsync<bool>(requestUri: $"{_serverUrl}/api/login/verify?username={username}&password={password}");
            return response;
        }

        public Task<Login> GetLogin(string username)
        {
            throw new NotImplementedException();
        }
    }
}