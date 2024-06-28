using cinema.Application.DTOs.Movie.Responce;
using cinema.Application.DTOs.Screening.Request;

namespace cinema.Application.Interfaces.Services;

public interface IScreeningManagementService
{
    Task<bool> CheckSessionOverlap(ScreeningCreateRequest request);
    Task GetMoviesAsync();
    Task<ICollection<ScreeningCreateRequest>> GetMovieSessionEndTime(ICollection<ScreeningCreateRequest> request);
}