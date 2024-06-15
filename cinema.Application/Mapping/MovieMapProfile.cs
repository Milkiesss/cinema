using AutoMapper;
using cinema.Application.DTOs.Movie;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<Movie, MovieCreateResponce>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<MovieUpdateRequest, Movie>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<Movie, MovieUpdateResponce>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<Movie, MovieGetByIdResponce>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.CommentDtos, opt => opt.MapFrom(src => src.Comments));

            CreateMap<Movie, MovieGetAllResponce>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.FilmRentalDurationDays, opt => opt.MapFrom(src => src.FilmRentalDurationDays))
                .ForMember(dest => dest.DurationMinuts, opt => opt.MapFrom(src => src.DurationMinuts))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

        }
    }
}
