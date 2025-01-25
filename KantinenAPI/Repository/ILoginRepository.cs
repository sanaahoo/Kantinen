using Core.Model;


namespace KantinenAPI.Repository

{
    public interface ILoginRepository
    {
        // Henter login-information ud fra brugernavn
        Login? GetLogin(string username);

        // Verificerer login med brugernavn og adgangskode
        bool VerifyLogin(string username, string password);
    }
}