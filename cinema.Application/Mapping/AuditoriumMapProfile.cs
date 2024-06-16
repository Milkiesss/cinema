using AutoMapper;
using cinema.Application.DTOs.Auditorium.Request;
using cinema.Application.DTOs.Auditorium.Responce;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Seats;
using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Mapping
{
    public class AuditoriumMapProfile : Profile
    {
        public AuditoriumMapProfile()
        {
            CreateMap<BaseSeatsDto, Seats>();
            CreateMap<Seats, BaseSeatsDto>();

            CreateMap<AuditoriumCreateRequest, Auditorium>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<AuditoriumUpdateRequest, Auditorium>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Auditorium, AuditoriumCreateResponce>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

            CreateMap<Auditorium, AuditoriumUpdateResponce>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

            CreateMap<Auditorium, AuditoriumGetAllResponce>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

            CreateMap<Auditorium, AuditoriumGetByIdResponce>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));
        }
    }
}
