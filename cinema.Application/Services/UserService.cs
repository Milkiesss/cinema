using AutoMapper;
using cinema.Application.DTOs.User.Request;
using cinema.Application.DTOs.User.Responce;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;

namespace cinema.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _rep;
    private readonly CryptograaphyService _serv;
    private readonly IMapper _mapper;

    public UserService(IUserRepository rep,CryptograaphyService serv, IMapper mapper)
    {
        _rep = rep;
        _serv = serv;
        _mapper = mapper;
    }
    public async Task<BaseUserResponce> Create(UserCreateRequest entity)
    {
        var request = _mapper.Map<User>(entity);
        request.Password = _serv.HashPassword(entity.Password);
        await _rep.Create(request);
        return _mapper.Map<BaseUserResponce>(request);
    }

    public Task<BaseUserResponce> Update(UserUpdateRequest entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(Guid id)
    {
        return await _rep.Delete(id);
    }

    public async Task<BaseUserResponce> GetById(Guid id)
    {
        var result = await _rep.GetById(id);
        return _mapper.Map<BaseUserResponce>(result);
    }

    public async Task<ICollection<BaseUserResponce>> GetAll()
    {
        var result =await _rep.GetAll();
        return _mapper.Map<ICollection<BaseUserResponce>>(result);
    }

    public async Task<Guid> Login(UserLoginRequest entity)
    {
        var request = _mapper.Map<User>(entity);
        var userExist = await _rep.Login(request);
        var passwordVerify = _serv.VerifyPassword(entity.Password, userExist.Password);
        if(passwordVerify)
            return userExist.Id;
        return Guid.Empty;
    }
}