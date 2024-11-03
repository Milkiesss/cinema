using AutoMapper;
using cinema.Application.DTOs.Screening.Request;
using cinema.Domain.Entities;
using cinema.Application.DTOs.Screening.Response;

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
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening));

            CreateMap<ScreeningUpdateRequest, Screening>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                  .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));

            CreateMap<Screening, ScreeningCreateResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                 .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));

            CreateMap<Screening, ScreeningUpdateResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                 .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));
            
            CreateMap<Screening, ScreeningGetByDateAndAuditoriumIdResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                 .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));

            
            CreateMap<Screening, ScreeningGetByIdResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                 .ForMember(dest => dest.StartScreening, opt => opt.MapFrom(src => src.StartScreening))
                 .ForMember(dest => dest.EndScreening, opt => opt.MapFrom(src => src.EndScreening));
            //todo: fix mapping
        }
    }
}
