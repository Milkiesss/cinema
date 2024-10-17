using AutoMapper;
using cinema.Application.DTOs.User;
using cinema.Application.DTOs.User.Reaponce;
using cinema.Domain.Entities;
using cinema.Domain.ValueObject;

namespace cinema.Application.Mapping;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<FullNameDto, FullName>();
        CreateMap<FullName, FullNameDto>();
        
        CreateMap<User, LoginResponce>();
        
        CreateMap<User, UserGetByEmailResponce>()
            .ForMember(dest => dest.fullName,
                opt => opt.MapFrom(src => src.FullName));

        CreateMap<User, RegisterationResponce>()
            .ForMember(dest => dest.fullName,
                opt => opt.MapFrom(src => src.FullName));

        CreateMap<RegisterationRequest, User>()
            .ConstructUsing(dto => new User(
            Guid.NewGuid(),
            new FullName(dto.fullName.firstName, dto.fullName.lastName),
            dto.role,
            dto.email,
            dto.password
            ));
        
    }
}