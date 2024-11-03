using System.Security.AccessControl;
using AutoMapper;
using cinema.Application.DTOs.User;
using cinema.Application.DTOs.User.Request;
using cinema.Application.DTOs.User.Responce;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Application.Interfaces.Services.Authentication;
using cinema.Domain.Entities;

namespace cinema.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _rep;
    private IMapper _mapper;
    private IJwtTokenGenerator _jwtTokenGenerator;

    public UserService(IUserRepository rep, IMapper mapper, IJwtTokenGenerator jwtTokenGeneratorl)
    {
        _rep = rep;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGeneratorl;
    }
    
    public async Task<RegisterationResponse> Register(RegisterationRequest entity)
    {
        if (await _rep.IsExist(entity.email))
            throw new Exception("User is already exists");
        
        var user = _mapper.Map<User>(entity);
        
        user.Token = _jwtTokenGenerator.GenerateToken(user);
        
        var result = await _rep.CreateAsync(user);
        return _mapper.Map<RegisterationResponse>(result);
    }

    public async Task<LoginResponse> Login(LoginRequest entity)
    {
        if (!await _rep.IsExist(entity.email))
            throw new Exception("User is not exists");
        var user = await _rep.GetByEmailAsync(entity.email);
        //check if password is correct
        
        user.Token = _jwtTokenGenerator.GenerateToken(user);
        return _mapper.Map<LoginResponse>(user);
    }

    public async Task<UserGetByEmailResponse> GetByEmailAsync(string Email)
    {
        var result = await _rep.GetByEmailAsync(Email);
        return _mapper.Map<UserGetByEmailResponse>(result);
    }

    public Task<bool> DeleteAsync(Guid Id)
    {
        throw new NotImplementedException();
    }
}