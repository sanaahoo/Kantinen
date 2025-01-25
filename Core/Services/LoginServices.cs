using System.Net.Http.Json;
using Core.Model;

namespace Core.Services
{
    public class LoginServices : ILoginServices
    {
        HttpClient http;
        private string _serverUrl = "https://localhost:7086";

        public LoginServices(HttpClient http)
        {
            this.http = http;
        }
        
        public async Task LoginAsync(string username, string password)
        { }
        
        
        
        

        public async Task<string> VerifyLogin(string username, string password)
        {
            var loginModel = new
            {
                Username = username,
                Password = password
            };

            // Send login request
            var response = await http.PostAsJsonAsync($"{_serverUrl}/api/admins/verify", loginModel);

            if (response.IsSuccessStatusCode)
            {
                // Extract the token from the response
                var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
                return tokenResponse?.Token ?? string.Empty;
            }

            return string.Empty; // Return empty string if not verified
        }

        public Task<Login> GetLogin(string username)
        {
            throw new NotImplementedException();
        }

        // DTO for the token response
        public class TokenResponse
        {
            public string Token { get; set; }
        }
    }
}