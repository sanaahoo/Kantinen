using Core.Model;

namespace Core.Services
{
    public interface ILoginServices
    {
        Task<string> VerifyLogin(string username, string password);
        Task<Login> GetLogin(string username);


    }
}