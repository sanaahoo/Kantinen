using Core.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace KantinenAPI.Repository;

public class LoginRepository : ILoginRepository

{
    private IMongoCollection<Login> _loginCollection;

    public LoginRepository(){
        var client = new MongoClient("mongodb+srv://sanaa:9xRHv28k5gLVqjL5@cluster0.9rqsi.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        var database = client.GetDatabase("kantinedb");
        _loginCollection = database.GetCollection<Login>("login_collection");
    }

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