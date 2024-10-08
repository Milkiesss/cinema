
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;

namespace cinema.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<MovieCreateResponce> CreateAsync(MovieCreateRequest entity);
        Task<MovieUpdateResponce> UpdateAsync(MovieUpdateRequest entity);
        Task<bool> DeleteAsync(Guid id);
        Task<MovieGetByIdResponce> GetByIdAsync(Guid id);
        Task<ICollection<MovieGetAllResponce>> GetAllAsync();
    }
}
