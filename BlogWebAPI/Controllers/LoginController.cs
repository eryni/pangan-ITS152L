using BlogDataLibrary.Data;
using BlogDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ISqlData _db;

        public LoginController(IConfiguration config, ISqlData db)
        {
            _config = config;
            _db = db;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLogin login)
        {
            UserModel? user = _db.Authenticate(login.UserName!, login.Password!);

            if (user != null)
            {
                var token = GenerateToken(user);
                // Returns token and id as required for LE5 frontend
                return Ok(new { id_token = token, id = user.Id });
            }

            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult Register([FromBody] UserModel user)
        {
            _db.Register(user.UserName!, user.FirstName!, user.LastName!, user.Password!);
            return Ok("User registered.");
        }

        private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? "User")
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"]!,
                _config["Jwt:Audience"]!,
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class UserLogin
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}