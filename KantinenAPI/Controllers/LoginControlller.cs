using Core.Model;
using KantinenAPI.Repository;
using Microsoft.AspNetCore.Mvc;


namespace KantinenAPI.Controllers
{
    [Route(template: "api/admins")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repo;

        public LoginController(ILoginRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route(template: "verify")]
        public bool VerifyLogin([FromQuery] string username, [FromQuery] string password)
        {
            return _repo.VerifyLogin(username: username, password: password);
        }

        [HttpGet]
        [Route(template: "get admin")]
        public Login? GetAdmin([FromQuery] string username)
        {
            return _repo.GetLogin(username: username);
        }
    }
}