using cinema.Application.DTOs.User;
using cinema.Application.DTOs.User.Reaponce;
using cinema.Application.Interfaces.Services;

namespace cinema.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    public Task<LoginResponce> Login(LoginRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task<RegisterRequest> Register(RegisterRequest entity)
    {
        throw new NotImplementedException();
    }
}