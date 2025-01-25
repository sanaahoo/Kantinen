namespace KantinenApp
{
    using Blazored.LocalStorage;
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;



    public class AuthService
    {
        private readonly ILocalStorageService _localStorage; // Service til at håndtere local storage

        // Constructor der injicerer ILocalStorageService
        public AuthService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        /// <summary>
        /// Tjekker om brugeren er logget ind og har et gyldigt token.
        /// </summary>
        /// <returns>True, hvis brugeren er logget ind og tokenet er gyldigt; ellers false.</returns>
        public async Task<bool> IsUserLoggedIn()
        {
            // Henter JWT-token fra local storage
            var token = await _localStorage.GetItemAsync<string>("jwt");

            // Tjekker om tokenet findes og ikke er udløbet
            return !string.IsNullOrEmpty(token) && !IsTokenExpired(token);
        }

        /// <summary>
        /// Tjekker om et JWT-token er udløbet.
        /// </summary>
        /// <param name="token">JWT-token, der skal tjekkes.</param>
        /// <returns>True, hvis tokenet er udløbet; ellers false.</returns>
        private bool IsTokenExpired(string token)
        {
            try
            {
                // Splitter tokenet i dens tre dele: header, payload og signature
                var tokenParts = token.Split('.');
                if (tokenParts.Length != 3) return true; // Tokenet er ugyldigt, hvis det ikke har tre dele

                // Dekoder payload-delen af tokenet
                var payload = tokenParts[1];
                var jsonBytes = ParseBase64WithoutPadding(payload);

                // Deserialiserer payload til et dictionary med claims
                var claims = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

                // Tjekker om "exp" (expiration time) claim findes i payload
                if (claims != null && claims.TryGetValue("exp", out var exp))
                {
                    // Håndterer forskellige typer af "exp" claims (long, int eller JsonElement)
                    if (exp is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Number)
                    {
                        // Konverterer Unix-timestamp til DateTime og tjekker om tokenet er udløbet
                        var expirationTime = DateTimeOffset.FromUnixTimeSeconds(jsonElement.GetInt64()).UtcDateTime;
                        return expirationTime < DateTime.UtcNow;
                    }

                    if (exp is long expirationLong)
                    {
                        var expirationTime = DateTimeOffset.FromUnixTimeSeconds(expirationLong).UtcDateTime;
                        return expirationTime < DateTime.UtcNow;
                    }

                    if (exp is int expirationInt)
                    {
                        var expirationTime = DateTimeOffset.FromUnixTimeSeconds(expirationInt).UtcDateTime;
                        return expirationTime < DateTime.UtcNow;
                    }
                }
            }
            catch (Exception)
            {
                // Hvis der opstår en fejl under parsing, betragtes tokenet som ugyldigt
                return true;
            }

            // Hvis "exp" claim ikke findes, betragtes tokenet som ugyldigt
            return true;
        }

        /// <summary>
        /// Hjælpemetode til at dekode Base64-streng uden padding.
        /// </summary>
        /// <param name="base64">Base64-streng, der skal dekodes.</param>
        /// <returns>Dekodet byte-array.</returns>
        private byte[] ParseBase64WithoutPadding(string base64)
        {
            // Tilføjer manglende padding-tegn, hvis nødvendigt
            if (base64.Length % 4 == 2) base64 += "==";
            else if (base64.Length % 4 == 3) base64 += "=";

            // Dekoder Base64-strengen til et byte-array
            return Convert.FromBase64String(base64);
        }

        /// <summary>
        /// Logger brugeren ud ved at fjerne JWT-token fra local storage.
        /// </summary>
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("jwt"); // Fjerner tokenet fra local storage
        }
    }
}
