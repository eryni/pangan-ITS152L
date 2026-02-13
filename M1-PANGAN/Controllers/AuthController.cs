using Microsoft.AspNetCore.Mvc;
using M1_PANGAN.Models;

namespace M1_PANGAN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username.ToLower() == "nela" && request.Password == "admin")
            {
                return Ok(new { success = true, message = "Login successful" });
            }
            return Unauthorized(new { success = false, message = "Invalid credentials!" });
        }
    }
}
