using cinema.Application.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Movie.Responce
{
    public class MovieGetByIdResponce : BaseMovieDto
    {
        public Guid Id { get; set; }
        public ICollection<BaseCommentDto> CommentDtos { get; set; }
    }
}
