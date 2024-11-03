using AutoMapper;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Reservation.Request;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.Application.DTOs.Reservation.Response;

namespace cinema.Application.Mapping
{
    public class ReservationMapProfile : Profile
    {
        public ReservationMapProfile()
        {
            CreateMap<ReservationCreateRequest, Reservation>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.SeatId, opt => opt.MapFrom(src => src.SeatId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));


            CreateMap<ReservationUpdateRequest, Reservation>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SeatId, opt => opt.MapFrom(src => src.SeatId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Reservation, ReservationCreateResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SeatId, opt => opt.MapFrom(src => src.SeatId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Reservation, ReservationUpdateResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SeatId, opt => opt.MapFrom(src => src.SeatId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Reservation, ReservationGetAllScreeningResponse>()
                .ForMember(dest => dest.reservationId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SeatId, opt => opt.MapFrom(src => src.SeatId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
