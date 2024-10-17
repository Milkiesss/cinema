using cinema.Domain.Entities;

namespace cinema.Application.Interfaces.Services.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User entity);
}