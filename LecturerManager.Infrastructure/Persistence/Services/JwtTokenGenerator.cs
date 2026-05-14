using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LecturerManager.Application.Common.Interfaces;
using LecturerManager.Domain.Identity.Enums;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LecturerManager.Infrastructure.Persistence.Services;

public class JwtTokenGenerator(IOptions<JwtOptions> options) : IJwtTokenGenerator
{
    private readonly JwtOptions _jwt = options.Value;

    public string GenerateToken(Guid userId, string login, UserRole role)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, login),
            new Claim(ClaimTypes.Role, role.ToString().ToLowerInvariant())
        };

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwt.Issuer,
            _jwt.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.ExpiresInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}