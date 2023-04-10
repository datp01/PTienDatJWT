using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PractiveJwt10.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        protected readonly PracticeContext _context;
        protected readonly ILogger<T> _logger;
        protected readonly IConfiguration _config;
        public BaseController(PracticeContext context, ILogger<T> logger, IConfiguration config)
        {
            _config = config;
            _context = context;
            _logger = logger;
        }

        protected string[] GetStringArr(string str)
        {
            return str.SplitString();
        }

        protected string GenerateToken(string username)
        {
            var secretKey = _config.GetValue<string>("Authen:Secret");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username)
            };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
