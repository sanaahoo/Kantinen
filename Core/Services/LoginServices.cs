using System.Net.Http.Json;
using Core.Model;

namespace Core.Services
{
    public class LoginServices : ILoginServices
    {
        HttpClient http; // HttpClient til at foretage HTTP-anmodninger
        private string _serverUrl = "https://localhost:7086"; // Base URL for API'et

        // Constructor der injicerer HttpClient
        public LoginServices(HttpClient http)
        {
            this.http = http;
        }

        // Metode til at logge ind (ikke implementeret endnu)
        public async Task LoginAsync(string username, string password)
        { }

        // Verificerer login med brugernavn og adgangskode
        public async Task<string> VerifyLogin(string username, string password)
        {
            // Opretter et login-objekt med brugernavn og adgangskode
            var loginModel = new
            {
                Username = username,
                Password = password
            };

            // Sender en POST-anmodning til API'et for at verificere login
            var response = await http.PostAsJsonAsync($"{_serverUrl}/api/admins/verify", loginModel);

            // Tjekker om anmodningen var succesfuld
            if (response.IsSuccessStatusCode)
            {
                // Henter token fra svaret
                var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
                return tokenResponse?.Token ?? string.Empty; // Returnerer token eller en tom streng
            }

            return string.Empty; // Returnerer en tom streng, hvis login ikke er verificeret
        }

        // Henter login-information (ikke implementeret endnu)
        public Task<Login> GetLogin(string username)
        {
            throw new NotImplementedException();
        }

        // DTO (Data Transfer Object) til at modtage token fra API'et
        public class TokenResponse
        {
            public string Token { get; set; } // Token, der returneres fra API'et
        }
    }
}