using cinema.Application.DTOs.Screening.Request;

namespace cinema.Application.Interfaces.Services;

public interface IScreeningManagementService
{
    Task<ICollection<ScreeningCreateRequest>> GetMovieSessionEndTime(ICollection<ScreeningCreateRequest> request);
    Task<bool> CheckSessionOverlap(ScreeningCreateRequest request);
}