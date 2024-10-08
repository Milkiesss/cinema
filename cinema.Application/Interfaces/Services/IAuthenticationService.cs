using cinema.Application.DTOs.User;
using cinema.Application.DTOs.User.Reaponce;

namespace cinema.Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<LoginResponce> Login(LoginRequest entity);
    Task<RegisterRequest> Register(RegisterRequest entity);
}