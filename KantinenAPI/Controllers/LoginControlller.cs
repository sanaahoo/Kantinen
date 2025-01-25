using Core.Model;
using KantinenAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace KantinenAPI.Controllers
{
    [Route(template: "api/admins")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repo;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        [HttpPost]
        [Route(template: "verify")]
        public IActionResult VerifyLogin(Login login)
        {
            bool isVerified = false;
            isVerified = _repo.VerifyLogin(username: login.Username, password: login.Password);

            if (isVerified)
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, "User")
            };

                var jwtSettings = _configuration.GetSection("JwtSettings");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationMinutes"])),
                    signingCredentials: credentials);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else
            {

                return Unauthorized();
            }
        }

        [HttpGet]
        [Route(template: "get admin")]
        public Login? GetAdmin([FromQuery] string username)
        {
            return _repo.GetLogin(username: username);
        }
    }
}