
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Response;

namespace cinema.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<MovieCreateResponse> CreateAsync(MovieCreateRequest entity, string fileName, string contentType,Stream  stream);
        Task<MovieUpdateResponse> UpdateAsync(MovieUpdateRequest entity,string fileName, string contentType,Stream source);
        Task<bool> DeleteAsync(Guid id);
        Task<MovieGetByIdResponse> GetByIdAsync(Guid id);
        Task<ICollection<MovieGetAllResponse>> GetAllAsync();
    }
}
