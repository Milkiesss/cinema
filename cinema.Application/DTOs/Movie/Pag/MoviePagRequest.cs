using cinema.Application.Pagination;

namespace cinema.Application.DTOs.Movie.Pag;

public class MoviePagRequest : IPaginationRequest
{
    public PageRequest? Page { get; set; }
}