using cinema.Application.DTOs.Screening;


namespace cinema.Application.Interfaces.Services;

public interface IScreeningManagementService
{
    Task<ICollection<TDtos>> GetMovieSessionEndTimeAsync<TDtos>(ICollection<TDtos> request) where TDtos : BaseScreeningDto;
    Task<bool> CheckSessionOverlapAsync<TDtos>(TDtos request) where TDtos : BaseScreeningDto;
}