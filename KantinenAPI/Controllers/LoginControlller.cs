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
    [Route("api/admins")] // Basisruten for alle endpoints i denne controller
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repo; // Repository til håndtering af login
        private readonly IConfiguration _configuration; // Konfiguration til JWT-indstillinger

        // Constructor der injicerer ILoginRepository og IConfiguration
        public LoginController(ILoginRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        // Verificerer login og genererer JWT-token
        [HttpPost]
        [Route("verify")]
        public IActionResult VerifyLogin(Login login)
        {
            bool isVerified = _repo.VerifyLogin(login.Username, login.Password); // Verificerer login

            if (isVerified)
            {
                // Opretter claims til JWT-token
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, "User")
                };

                // Henter JWT-indstillinger fra konfiguration
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Opretter JWT-token
                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationMinutes"])),
                    signingCredentials: credentials);

                // Returnerer JWT-token
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else
            {
                // Returnerer HTTP 401 Unauthorized ved ugyldigt login
                return Unauthorized();
            }
        }

        // Henter admin-bruger ud fra brugernavn
        [HttpGet]
        [Route("get admin")]
        public Login? GetAdmin([FromQuery] string username)
        {
            return _repo.GetLogin(username); // Henter login-information fra repository
        }
    }
}