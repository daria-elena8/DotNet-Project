using DotnetProjectAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotnetProjectAPI.Services.UserService;
using DotnetProjectAPI.Models.Auth;



namespace DotnetProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequest model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid username / password." });

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("MY_SECRET_KEY_celputin16caractere"); 

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Role, user.role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "https://localhost:7000",  
                Audience = "https://localhost:7000",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }


}
