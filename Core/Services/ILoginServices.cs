using Core.Model;

namespace Core.Services
{
    public interface ILoginServices
    {
        Task<bool> VerifyLogin(string username, string password);
        Task<Login> GetLogin(string username);


    }
}