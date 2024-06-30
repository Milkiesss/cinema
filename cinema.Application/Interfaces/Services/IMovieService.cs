using cinema.Application.DTOs.Movie.Pag;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;

namespace cinema.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<MovieCreateResponce> Create(MovieCreateRequest entity);
        Task<MovieUpdateResponce> Update(MovieUpdateRequest entity);
        Task<bool> Delete(Guid id);
        Task<MovieGetByIdResponce> GetById(Guid id);
        Task<ICollection<MovieGetAllResponce>> GetAll();
        Task<MoviePagResponce> GetPagedMovies(MoviePagRequest request);
    }
}
