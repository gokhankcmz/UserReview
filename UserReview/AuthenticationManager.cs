using Contracts;
using Entities;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace UserReview
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IConfiguration _configuration;
        public AuthenticationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Authenticate(UserForAuthenticationDto userForAuthenticationDto, IRepositoryManager repository)
        {
            var _user = repository.User.GetUser(userForAuthenticationDto.username, userForAuthenticationDto.password, trackChanges: false);
            if (_user == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, _user.userType.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                Issuer = jwtSettings.GetSection("validIssuer").Value,
                Audience= jwtSettings.GetSection("validAudience").Value,
                SigningCredentials = GetSigningCredentials()

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        private SigningCredentials GetSigningCredentials()
        {
            var key =
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
