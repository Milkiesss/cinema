using cinema.Application.DTOs.Movie.Pag;
using cinema.Domain.Entities;

namespace cinema.Application.Interfaces.Repository
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<MoviePagResponce> GetPagedMovies(MoviePagRequest request);
    }
}
