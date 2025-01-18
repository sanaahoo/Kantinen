namespace Core.Services;

public class LoginServiceInMemory 
{
    private readonly Dictionary<string, string> _users;

    public LoginServiceInMemory()
    {
        // Mock users: Username => Password
        _users = new Dictionary<string, string>
        {
            { "admin", "password123" },
            { "user", "pass1234" }
        };
    }

    public Task<bool> AuthenticateAsync(string username, string password)
    {
        // Validate credentials against the mock user list
        return Task.FromResult(result: _users.TryGetValue(key: username, value: out var storedPassword) && storedPassword == password);
    }

    public Task<bool> RegisterAsync(string username, string password)
    {
        if (_users.ContainsKey(key: username))
            return Task.FromResult(result: false);

        _users[key: username] = password;
        return Task.FromResult(result: true);
    }
}