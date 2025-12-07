using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Ports.Dependencies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace TokenService
{
    public class JwtOptions
    {
        public string Key { get; set; } = "";
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public int ExpiresMinutes { get; set; } = 1440;
    }

    public class JwtService : IJwtService
    {
        private readonly JwtOptions _options;
        private readonly SymmetricSecurityKey _key;

        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        }

        public string GenerateToken(int userId, string username, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(ClaimTypes.Role, role)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_options.ExpiresMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
