namespace MyOnlineShop.Infrastructure.Identity
{
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using MyOnlineShop.Application.Common;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    internal class JwtTokenGeneratorService : IJwtTokenGenerator
    {
        private readonly ApplicationSettings applicationSettings;

        public JwtTokenGeneratorService(IOptions<ApplicationSettings> options)
        {
            this.applicationSettings = options.Value;
        }

        public string GenerateToken(
            User user,
            IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.applicationSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email)
            };

            if (roles.Any())
            {
                var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
                claims.AddRange(roleClaims);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
