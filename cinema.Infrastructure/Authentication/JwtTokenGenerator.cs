using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using cinema.Application.Interfaces.Services.Authentication;
using cinema.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace cinema.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(User entity)
    {
        var siginingCredential = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("Cinema-brings-stories-to-life-on-screen.")),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, entity.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, entity.FullName.firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, entity.FullName.lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("role",entity.Role.ToString()),
            new Claim("email",entity.Email)
        };
        var securityToken = new JwtSecurityToken(
            issuer: "Cinema-ShandrigozHuilo",
            expires: DateTime.Now.AddHours(2),
            claims: claims,
            signingCredentials: siginingCredential);
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}