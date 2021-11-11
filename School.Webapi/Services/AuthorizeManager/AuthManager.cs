using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.DTOs.UserDTOs;
using School.Webapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace School.Webapi.Services.AuthorizeManager
{
    public class AuthManager:IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configurations;
        private User user;

        public AuthManager(UserManager<User> userManager, 
            IConfiguration iconfiguration)
        {
            this._userManager = userManager;
            this._configurations = iconfiguration;
        }

        public async Task<string> CreateToken()
        {
            var signInCreadentials = GetSignInCredentials();
            var claims = await GetClaimsAsync();
            var token = GenerateTokenOptions(signInCreadentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signInCreadentials, 
            IEnumerable<Claim> claims)
        {
            var jwtSettings = _configurations.GetSection("Jwt");

            double lifetime = Convert.ToDouble(jwtSettings.GetSection("lifetime").Value);

            var expiration = DateTime.Now.AddMinutes(lifetime);

            var issuer = jwtSettings.GetSection("Issuer").Value;

            var token = new JwtSecurityToken(
                    issuer: issuer,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: signInCreadentials
                );
            return token;
        }

        private async Task<IEnumerable<Claim>> GetClaimsAsync()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private SigningCredentials GetSignInCredentials()
        {
            var key = _configurations.GetSection("Jwt").GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginDTO userDto)
        {
            user = await  _userManager.FindByNameAsync(userDto.Email);

            var validPassword = await _userManager.CheckPasswordAsync(user, 
                                            userDto.Password);

            return (user != null && validPassword);
        }
    }
}
