using AutoMapper;
using cinema.Application.DTOs.Seats.Request;
using cinema.Domain.Entities;
using cinema.Application.DTOs.Seats.Response;

namespace cinema.Application.Mapping
{
    public class SeatMapProfile : Profile
    {
        public SeatMapProfile()
        {
            CreateMap<SeatsCreateRequest, Seats>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.RowNumber, opt => opt.MapFrom(src => src.RowNumber))
                 .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.SeatNumber))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceModifire));

            CreateMap<SeatsUpdateRequest, Seats>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.RowNumber, opt => opt.MapFrom(src => src.RowNumber))
                 .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.SeatNumber))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceModifire));

            CreateMap<Seats, SeatsCreateResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.RowNumber, opt => opt.MapFrom(src => src.RowNumber))
                 .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.SeatNumber))
                 .ForMember(dest => dest.PriceModifire, opt => opt.MapFrom(src => src.Price));

            CreateMap<Seats, SeatsUpdateResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.AuditoriumId, opt => opt.MapFrom(src => src.AuditoriumId))
                 .ForMember(dest => dest.RowNumber, opt => opt.MapFrom(src => src.RowNumber))
                 .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.SeatNumber))
                 .ForMember(dest => dest.PriceModifire, opt => opt.MapFrom(src => src.Price));
            
        }
    }
}
