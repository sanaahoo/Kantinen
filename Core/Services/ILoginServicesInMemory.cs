namespace Core.Services;

public class LoginServicesInMemory
{
    private readonly Dictionary<string, string> _users; // Mock-database til brugere (brugernavn => adgangskode)

    public LoginServicesInMemory()
    {
        // Mock-brugere: Brugernavn => Adgangskode
        _users = new Dictionary<string, string>
        {
            { "admin", "password123" },
            { "user", "pass1234" }
        };
    }

    // Autentificerer en bruger ved at tjekke brugernavn og adgangskode
    public Task<bool> AuthenticateAsync(string username, string password)
    {
        // Validerer brugeroplysninger mod mock-brugerlisten
        return Task.FromResult(result: _users.TryGetValue(key: username, value: out var storedPassword) && storedPassword == password);
    }

    // Registrerer en ny bruger, hvis brugernavnet ikke allerede findes
    public Task<bool> RegisterAsync(string username, string password)
    {
        if (_users.ContainsKey(key: username))
            return Task.FromResult(result: false); // Brugernavnet findes allerede

        _users[key: username] = password; // Tilføjer ny bruger
        return Task.FromResult(result: true); // Registrering lykkedes
    }
}