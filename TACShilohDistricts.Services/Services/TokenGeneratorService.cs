using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.IServices;

namespace TACShilohDistricts.Services.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        public TokenGeneratorService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(AppUser model)
        {
            var avatar = model.PictureUrl ??= "https://cdn3.iconfinder.com/data/icons/sharp-users-vol-1/32/-_Default_Account_Avatar-512.png";
            var userRoles = await _userManager.GetRolesAsync(model);
            //string roles = string.Join(',', userRoles);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.NameIdentifier, model.Id),
                new Claim(ClaimTypes.GivenName, model.FirstName),
                new Claim(ClaimTypes.Surname, model.LastName),
                new Claim(ClaimTypes.Uri, avatar),
                //new Claim(ClaimTypes.Role, roles)
            };

            //Gets the roles of the logged in user and adds it to Claims
            var roles = await _userManager.GetRolesAsync(model);
            if (roles.Any())
            {
                foreach (var role in roles)
                    claims.Add(new Claim(ClaimTypes.Role, role));
            }            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:Issuer"],
                audience: _configuration["JWTSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenAsString;
        }
    }
}
