using Core.Model;

namespace Core.Services
{
    public interface ILoginServices
    {
        // Verificerer login med brugernavn og adgangskode
        Task<string> VerifyLogin(string username, string password);

        // Henter login-information ud fra brugernavn
        Task<Login> GetLogin(string username);
    }
}