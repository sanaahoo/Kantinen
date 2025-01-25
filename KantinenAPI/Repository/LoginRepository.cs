using Core.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KantinenAPI.Repository;

public class LoginRepository : ILoginRepository
{
    private IMongoCollection<Login> _loginCollection; // MongoDB-samling til login

    // Constructor der initialiserer MongoDB-klient og database
    public LoginRepository()
    {
        var client = new MongoClient("mongodb+srv://sanaa:9xRHv28k5gLVqjL5@cluster0.9rqsi.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        var database = client.GetDatabase("kantinedb");
        _loginCollection = database.GetCollection<Login>("login_collection"); // Henter login-samlingen
    }

    // Hardcoded brugere til demonstration
    private readonly Dictionary<string, string> _validUsers = new()
    {
        { "admin", "password123" },
        { "user", "pass1234" }
    };

    // Autentificerer en bruger asynkront (hardcoded)
    public Task<bool> AuthenticateAsync(string username, string password)
    {
        var isAuthenticated = _validUsers.TryGetValue(username, out var storedPassword) && storedPassword == password;
        return Task.FromResult(isAuthenticated);
    }

    // Henter login-information (ikke implementeret)
    public Login? GetLogin(string username)
    {
        throw new NotImplementedException();
    }

    // Verificerer login med brugernavn og adgangskode
    public bool VerifyLogin(string username, string password)
    {
        Login existingLogin = _loginCollection.Find(a => a.Username == username && a.Password == password)
            .FirstOrDefault();

        return existingLogin != null; // Returnerer true, hvis login findes
    }
}