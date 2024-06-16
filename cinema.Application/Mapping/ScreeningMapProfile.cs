using AutoMapper;
using cinema.Application.DTOs.Screening.Request;
using cinema.Application.DTOs.Screening.Responce;
using cinema.Application.DTOs.Seats.Request;
using cinema.Application.DTOs.Seats.Responce;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Mapping
{
    public class ScreeningMapProfile : Profile
    {
        public ScreeningMapProfile()
        {
            CreateMap<ScreeningCreateRequest, Screening>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                 .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));

            CreateMap<ScreeningUpdateRequest, Screening>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                 .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));

            CreateMap<Screening, ScreeningCreateResponce>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                 .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));

            CreateMap<Screening, ScreeningUpdateResponce>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                 .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));
            CreateMap<Screening, ScreeningGetByDateAndAuditoriumIdResponce>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                 .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));

        }
    }
}
