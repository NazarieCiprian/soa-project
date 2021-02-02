using FreightApp.Core.Model;
using FreightApp.Core.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using FreightApp.Core.Dto;
using System.Threading.Tasks;

namespace FreightApp.Core.Utils
{
    public class AuthenticationHelper
    {
        private readonly TruckerServiceWebApp _truckerServiceWebApp;
        private IConfiguration _config;
        public AuthenticationHelper(IConfiguration configuration)
        {
            _truckerServiceWebApp = new TruckerServiceWebApp();
            _config = configuration;
        }

        public async Task<AuthInfo> Authenticate(string username, string password)
        {
            var trucker = await _truckerServiceWebApp.GetTruckerByUsernameAndPassword(username, password);
            if (trucker == null)
            {
                return null;
            }
            var token = GenerateJSONWebToken(trucker);
            var authInfo = new AuthInfo();
            authInfo.Token = token;
            authInfo.Id = trucker.Id;
            return authInfo;
        }

        private string GenerateJSONWebToken(TruckerModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
             };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
