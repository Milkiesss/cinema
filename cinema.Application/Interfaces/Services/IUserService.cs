using cinema.Application.DTOs.User;
using cinema.Application.DTOs.User.Request;
using cinema.Application.DTOs.User.Responce;

namespace cinema.Application.Interfaces.Services;

public interface IUserService
{
    Task<LoginResponse> Login(LoginRequest entity);
    Task<RegisterationResponse> Register(RegisterationRequest entity);
    public Task<UserGetByEmailResponse> GetByEmailAsync(string Email);
    public Task<bool> DeleteAsync (Guid Id);
}