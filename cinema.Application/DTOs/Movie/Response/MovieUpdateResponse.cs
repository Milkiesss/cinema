namespace cinema.Application.DTOs.Movie.Response
{
    public class MovieUpdateResponse : BaseMovieDto
    {
        public Guid Id { get; set; }
        public string imgeUrl { get; set; }
    }
}
