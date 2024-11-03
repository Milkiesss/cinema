using AutoMapper;
using cinema.Application.DTOs.Auditorium.Request;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Seats;
using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.Application.DTOs.Auditorium.Response;

namespace cinema.Application.Mapping
{
    public class AuditoriumMapProfile : Profile
    {
        public AuditoriumMapProfile()
        {//MapPrice Error
            CreateMap<BaseSeatsDto, Seats>();
            CreateMap<Seats, BaseSeatsDto>();

            CreateMap<AuditoriumCreateRequest, Auditorium>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<AuditoriumUpdateRequest, Auditorium>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Auditorium, AuditoriumCreateResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

            CreateMap<Auditorium, AuditoriumUpdateResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

            CreateMap<Auditorium, AuditoriumGetAllResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

            CreateMap<Auditorium, AuditoriumGetByIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));
        }
    }
}
