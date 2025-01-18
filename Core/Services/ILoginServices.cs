using Core.Model;

namespace Kantinen.Services
{
    public interface ILoginService
    {
        Task<bool> VerifyLogin(string username, string password);
        Task<Login> GetLogin(string username);


    }
}