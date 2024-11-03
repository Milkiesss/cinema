using AutoMapper;
using cinema.Application.DTOs.User;
using cinema.Application.DTOs.User.Request;
using cinema.Application.DTOs.User.Responce;
using cinema.Domain.Entities;
using cinema.Domain.ValueObject;

namespace cinema.Application.Mapping;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<FullNameDto, FullName>();
        CreateMap<FullName, FullNameDto>();
        
        CreateMap<User, LoginResponse>();
        
        CreateMap<User, UserGetByEmailResponse>()
            .ForMember(dest => dest.fullName,
                opt => opt.MapFrom(src => src.FullName));

        CreateMap<User, RegisterationResponse>()
            .ForMember(dest => dest.fullName,
                opt => opt.MapFrom(src => src.FullName));

        CreateMap<RegisterationRequest, User>()
            .ConstructUsing(dto => new User(
            Guid.NewGuid(),
            new FullName(dto.fullName.firstName, dto.fullName.lastName),
            dto.role,
            dto.birthDate,
            dto.email,
            dto.password
            ));
        
    }
}