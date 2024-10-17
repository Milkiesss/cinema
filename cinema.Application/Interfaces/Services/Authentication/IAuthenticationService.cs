using cinema.Application.DTOs.User;
using cinema.Application.DTOs.User.Reaponce;

namespace cinema.Application.Interfaces.Services.Authentication;

public interface IAuthenticationService
{
    Task<LoginResponce> Login(LoginRequest entity);
    Task<RegisterationRequest> Register(RegisterationRequest entity);
}