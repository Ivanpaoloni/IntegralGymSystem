using IntegralGymSystem.Contracts.Dtos.Security;
using IntegralGymSystem.Contracts.Dtos.Users;
using IntegralGymSystem.Contracts.Managers;
using IntegralGymSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegralGymSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserManager _userManager;
        public AuthenticationController(IConfiguration configuration, IUserManager userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public UserTokenDto Token([FromBody] LoginDto dto)
        {
            UserTokenDto response = new();
            var userLogged = _userManager.Login(dto).Result;

            if (userLogged != null)
            {
                response.User = userLogged;
                response.Token = GenerateJwtToken(new ApplicationUser { Id = userLogged.Id, UserName = userLogged.UserName, GymId = userLogged.GymId});
                return response;
            }

            throw new Exception("Invalid credentials");
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", user.Id.ToString()),
            new Claim("GymId", user.GymId.ToString() ?? string.Empty) // Si necesitas incluir el GymId
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
