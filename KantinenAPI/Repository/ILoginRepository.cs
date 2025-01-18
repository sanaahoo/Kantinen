using Core.Model;


namespace KantinenAPI.Repositories

{
    public interface ILoginRepository
    {
        Login? GetLogin(string username);
        public bool VerifyLogin(string username, string password);
    }
}