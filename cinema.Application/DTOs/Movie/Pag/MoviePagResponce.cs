using cinema.Application.Pagination;

namespace cinema.Application.DTOs.Movie.Pag;

public class MoviePagResponce : IPaginationResponce<MovieLIstItems>
{
    public ICollection<MovieLIstItems> Items { get; set; }
    public PageResponce? Page { get; set; }
}