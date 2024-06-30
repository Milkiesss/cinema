using cinema.Application.DTOs.User.Request;
using cinema.Application.DTOs.User.Responce;

namespace cinema.Application.Interfaces.Services;

public interface IUserService
{
    Task<BaseUserResponce> Create(UserCreateRequest entity);
    Task<BaseUserResponce> Update(UserUpdateRequest entity);
    Task<bool> Delete(Guid id);
    Task<BaseUserResponce> GetById(Guid id);
    Task<ICollection<BaseUserResponce>> GetAll(); 
    Task<Guid> Login(UserLoginRequest entity);
}