using cinema.Application.DTOs.Screening.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using System.Collections.Generic;
using cinema.Application.DTOs.Movie;
using cinema.Application.DTOs.Screening;
using Microsoft.Extensions.Caching.Memory;

namespace cinema.Application.Services;

public class ScreeningManagementService : IScreeningManagementService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMemoryCache _cache;

    public ScreeningManagementService(IMovieRepository movieRepository, IScreeningRepository screeningRepository, IMemoryCache cache)
    {
        _movieRepository = movieRepository;
        _screeningRepository = screeningRepository;
        _cache = cache;
    }

    public async Task<ICollection<TDtos>> GetMovieSessionEndTimeAsync<TDtos>(ICollection<TDtos> request) where TDtos : BaseScreeningDto
    {
        foreach (var item in request)
        {
            if(!_cache.TryGetValue(item.MovieId, out Movie movie))
                movie = await GetMovieFromCacheAsync(item.MovieId);
            item.EndScreening = item.StartScreening.AddMinutes(movie.DurationMinuts + 40);
            await CheckSessionOverlapAsync(item);
        }

        return request;
    }

    public async Task<bool> CheckSessionOverlapAsync<TDtos>(TDtos request) where TDtos : BaseScreeningDto
    {
        var sessionKey = (request.StartScreening.Date, request.AuditoriumId);
        if (!_cache.TryGetValue(sessionKey, out ICollection<Screening> dailySession))
        { 
            dailySession = await _screeningRepository.GetScreeningByDateAndAuditoriumIdAsync(request.StartScreening.Date, request.AuditoriumId);
            if (dailySession.Count == 0)
                return false;
            _cache.Set(sessionKey, dailySession.ToList(), TimeSpan.FromHours(1));
        }

        var overlapCheck = dailySession.Any(overlap =>
            request.StartScreening < overlap.EndScreening && overlap.StartScreening < request.EndScreening);

        if (overlapCheck)
            throw new Exception($"Session with a start time {request.StartScreening } and the end time {request.EndScreening} overlaps with other sessions.");
        return false;
    }
    
    public async Task<Movie> GetMovieFromCacheAsync(Guid MovieId)
    {
         var movie = await GetMoviesByIdAsync(MovieId);
        _cache.Set(movie.Id, movie, TimeSpan.FromHours(1));
        return movie;
    }
   
    public async Task<Movie> GetMoviesByIdAsync(Guid Id)
    {
        var movies = await _movieRepository.GetByIdAsync(Id);
        return movies;
    }
    
}