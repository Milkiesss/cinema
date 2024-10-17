using AutoMapper;
using cinema.Application.DTOs.User;
using cinema.Application.DTOs.User.Reaponce;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Application.Interfaces.Services.Authentication;
using cinema.Domain.Entities;

namespace cinema.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _rep;
    private IMapper _mapper;
    private IJwtTokenGenerator _jwtTokenGeneratorl;

    public UserService(IUserRepository rep, IMapper mapper, IJwtTokenGenerator jwtTokenGeneratorl)
    {
        _rep = rep;
        _mapper = mapper;
        _jwtTokenGeneratorl = jwtTokenGeneratorl;
    }
    
    public async Task<RegisterationResponce> Register(RegisterationRequest entity)
    {
        if (await _rep.GetByEmailAsync(entity.email) is not null)
            throw new Exception("User is already exists");
        
        var user = _mapper.Map<User>(entity);
        
        user.Token = _jwtTokenGeneratorl.GenerateToken(user);
        
        var result = await _rep.CreateAsync(user);
        return _mapper.Map<RegisterationResponce>(result);
    }

    public async Task<LoginResponce> Login(LoginRequest entity)
    {
        
        if (await _rep.GetByEmailAsync(entity.email) is not User user)
            throw new Exception("User is not exists");
        
        //check if password is correct
        
        user.Token = _jwtTokenGeneratorl.GenerateToken(user);
        return _mapper.Map<LoginResponce>(user);
    }

    public async Task<UserGetByEmailResponce> GetByEmailAsync(string Email)
    {
        var result = await _rep.GetByEmailAsync(Email);
        return _mapper.Map<UserGetByEmailResponce>(result);
    }

    public Task<bool> DeleteAsync(Guid Id)
    {
        throw new NotImplementedException();
    }
}