using cinema.Application.DTOs.Comment;

namespace cinema.Application.DTOs.Movie.Response
{
    public class MovieGetByIdResponse : BaseMovieDto
    {
        public Guid Id { get; set; }
        public ICollection<BaseCommentDto> CommentDtos { get; set; }
    }
}
