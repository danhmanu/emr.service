using Emr.Infrastructure.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emr.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Kiểm tra thông tin đăng nhập (thường là so sánh với dữ liệu trong cơ sở dữ liệu)
            if (login.Username == "test" && login.Password == "password")
            {
                AuthenticationJwt jwt = new AuthenticationJwt();
                var token = jwt.GenerateJwtToken();
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
