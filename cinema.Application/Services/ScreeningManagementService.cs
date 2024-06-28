using cinema.Application.DTOs.Screening.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;

namespace cinema.Application.Services;

public class ScreeningManagementService : IScreeningManagementService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IScreeningRepository _screeningRepository;
    private Dictionary<Guid, Movie>   _moviesCash;
    private List<Screening> _screeningDayChash;
    public ScreeningManagementService(IMovieRepository movieRepository, IScreeningRepository screeningRepository)
    {
        _movieRepository = movieRepository;
        _screeningRepository = screeningRepository;
    }

    public async Task<ICollection<ScreeningCreateRequest>> GetMovieSessionEndTime(ICollection<ScreeningCreateRequest> request)
    {
        if (_moviesCash.Count == 0)
            await GetMoviesAsync();
        var endTime = request.Select(async item =>
        {
            if (!_moviesCash.ContainsKey(item.MovieId))
                await GetMoviesAsync(item.MovieId);
            
            var movie = _moviesCash[item.MovieId];
            item.StartScreening = item.StartScreening.AddMinutes(movie.DurationMinuts + 40);
            return item;
        });
        return endTime;
    }
    
    public async Task<bool> CheckSessionOverlap(ScreeningCreateRequest request)
    {
        var DailySession = await _screeningRepository.GetScreeningByDateAndAuditoriumId(request.StartScreening.Date, request.AuditoriumId);

        var OverLapCheck = DailySession.Any(Overlap =>
            request.StartScreening <= Overlap.EndScreening && Overlap.StartScreening >= request.EndScreening);

        if(OverLapCheck)
            throw new Exception($"Session with a start time {request.StartScreening } and the end time {request.EndScreening} overlaps with other sessions.");
        return false;
    }
    public async Task GetMoviesAsync(Guid Id)
    {
        var movies = await _movieRepository.GetById(Id);
        _moviesCash.Add(movies.Id, movies);
    }
    public async Task GetMoviesAsync()
    {
        var movies = await _movieRepository.GetAll();
        _moviesCash = movies.ToDictionary(m => m.Id);
    }
}