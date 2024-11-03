using AutoMapper;
using cinema.Application.DTOs.Movie;
using cinema.Application.DTOs.Movie.Request;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using cinema.Application.DTOs.Movie.Response;

namespace cinema.Application.Mapping
{
    public class MovieMapProfile : Profile
    {
        public MovieMapProfile() 
        {
            CreateMap<MovieCreateRequest, Movie>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.Restriction, opt => opt.MapFrom(src => src.restriction))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<Movie, MovieCreateResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.imageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.restriction, opt => opt.MapFrom(src => src.Restriction))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            /*CreateMap<MovieUpdateRequest, Movie>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.Restriction, opt => opt.MapFrom(src => src.restriction))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));*/

            CreateMap<Movie, MovieUpdateResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.imgeUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.restriction, opt => opt.MapFrom(src => src.Restriction))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<Movie, MovieGetByIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.CommentDtos, opt => opt.MapFrom(src => src.Comments));

            CreateMap<Movie, MovieGetAllResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

        }
    }
}
