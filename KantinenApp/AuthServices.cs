namespace KantinenApp
{
    using Blazored.LocalStorage;
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class AuthService
    {
        private readonly ILocalStorageService _localStorage;

        public AuthService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        // Check if the user is logged in and has a valid token
        public async Task<bool> IsUserLoggedIn()
        {
            var token = await _localStorage.GetItemAsync<string>("jwt");
            return !string.IsNullOrEmpty(token) && !IsTokenExpired(token);
        }

        // Check if the token is expired
        private bool IsTokenExpired(string token)
        {
            try
            {
                var tokenParts = token.Split('.');
                if (tokenParts.Length != 3) return true;

                var payload = tokenParts[1];
                var jsonBytes = ParseBase64WithoutPadding(payload);
                var claims = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

                if (claims != null && claims.TryGetValue("exp", out var exp))
                {
                    // Check the type of exp and convert it to a Unix timestamp
                    if (exp is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Number)
                    {
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
                // Token is invalid or error in parsing
                return true;
            }

            return true;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            if (base64.Length % 4 == 2) base64 += "==";
            else if (base64.Length % 4 == 3) base64 += "=";
            return Convert.FromBase64String(base64);
        }

        // Logout the user and remove the token
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("jwt");
        }
    }

}
