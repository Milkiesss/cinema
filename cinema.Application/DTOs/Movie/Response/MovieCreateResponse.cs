namespace cinema.Application.DTOs.Movie.Response
{
    public class MovieCreateResponse : BaseMovieDto
    {
        public Guid Id { get; set; }
        public string imageUrl { get; set; }
    }
}
