using AutoMapper;
using cinema.Application.DTOs.Comment.Request;
using cinema.Application.DTOs.Movie.Request;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.Application.DTOs.Comment.Response;

namespace cinema.Application.Mapping
{
    public class CommentMapProfile : Profile
    {
        public CommentMapProfile()
        {
            CreateMap<CommentCreateRequest, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));

            CreateMap<Comment, CommentUpdateRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));
            CreateMap<CommentCreateResponse, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));
            CreateMap<CommentUpdateResponse, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));

        }
    }
}
