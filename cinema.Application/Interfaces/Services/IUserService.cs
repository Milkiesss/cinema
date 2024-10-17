using cinema.Application.DTOs.User;
using cinema.Application.DTOs.User.Reaponce;

namespace cinema.Application.Interfaces.Services;

public interface IUserService
{
    Task<LoginResponce> Login(LoginRequest entity);
    Task<RegisterationResponce> Register(RegisterationRequest entity);
    public Task<UserGetByEmailResponce> GetByEmailAsync(string Email);
    public Task<bool> DeleteAsync (Guid Id);
}