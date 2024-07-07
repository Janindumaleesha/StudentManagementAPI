using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using StudentManagementAPI.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAuth()
        {
            var claims = new[]
            {
                new Claim("Full Name", "Janindu Maleesha"),
                new Claim(JwtRegisteredClaimNames.Sub, "StudentId")
            };

            var keyBytes = Encoding.UTF8.GetBytes(ConstantsHelper.Secret);

            var key = new SymmetricSecurityKey(keyBytes);

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                ConstantsHelper.Audience, 
                ConstantsHelper.Issuer, 
                claims, 
                notBefore: DateTime.Now, 
                expires: DateTime.Now.AddHours(1),
                signingCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { AccessToken = tokenString });
        }
    }
}
