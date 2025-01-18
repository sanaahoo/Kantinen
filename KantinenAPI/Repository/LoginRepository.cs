using Core.Model;
using MongoDB.Driver;
using Core.Model;
using KantinenAPI.Repositories;


namespace KantinenAPI.Repositories;

public class LoginRepository : ILoginRepository
{
    // Hardcoded valid credentials for demonstration purposes
    private readonly Dictionary<string, string> _validUsers = new()
    {
        { "admin", "password123" },
        { "user", "pass1234" }
    };

    public Task<bool> AuthenticateAsync(string username, string password)
    {
        // Check if the username exists and the password matches
        var isAuthenticated = _validUsers.TryGetValue(key: username, value: out var storedPassword) && storedPassword == password;
        return Task.FromResult(result: isAuthenticated);
    }

    public Login? GetLogin(string username)
    {
        throw new NotImplementedException();
    }

    public bool VerifyLogin(string username, string password)
    {
        throw new NotImplementedException();
    }
}