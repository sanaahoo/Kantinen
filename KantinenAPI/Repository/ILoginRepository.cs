using Core.Model;


namespace KantinenAPI.Repository

{
    public interface ILoginRepository
    {
        Login? GetLogin(string username);
        public bool VerifyLogin(string username, string password);
    }
}