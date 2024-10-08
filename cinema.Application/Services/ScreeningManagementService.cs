﻿using cinema.Application.DTOs.Screening.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using System.Collections.Generic;
using cinema.Application.DTOs.Screening;

namespace cinema.Application.Services;

public class ScreeningManagementService : IScreeningManagementService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IScreeningRepository _screeningRepository;
    private Dictionary<Guid, Movie>   _moviesCash;
    private Dictionary<(DateTime, Guid), List<Screening>> _screeningDayChash;
    private IScreeningManagementService _screeningManagementServiceImplementation;

    public ScreeningManagementService(IMovieRepository movieRepository, IScreeningRepository screeningRepository)
    {
        _movieRepository = movieRepository;
        _screeningRepository = screeningRepository;
        _moviesCash = new Dictionary<Guid, Movie>();
        _screeningDayChash = new Dictionary<(DateTime, Guid), List<Screening>>();
    }

    public async Task<ICollection<TDtos>> GetMovieSessionEndTimeAsync<TDtos>(ICollection<TDtos> request) where TDtos : BaseScreeningDto
    {
        if (_moviesCash.Count == 0)
            await GetMoviesAsync();
        var endTime = request.Select(async item =>
        {
            if (!_moviesCash.ContainsKey(item.MovieId))
                await GetMoviesByIdAsync(item.MovieId);
            
            var movie = _moviesCash[item.MovieId];
            item.EndScreening = item.StartScreening.AddMinutes(movie.DurationMinuts + 40);
            await CheckSessionOverlapAsync(item);
            return item;
        });
        return await Task.WhenAll(endTime);
    }

    public async Task<bool> CheckSessionOverlapAsync<TDtos>(TDtos request) where TDtos : BaseScreeningDto
    {
        var sessionKey = (request.StartScreening.Date, request.AuditoriumId);
        if (_screeningDayChash is null || !_screeningDayChash.ContainsKey(sessionKey))
        {
            var dailySession = await _screeningRepository.GetScreeningByDateAndAuditoriumIdAsync(request.StartScreening.Date, request.AuditoriumId);
            if (dailySession.Count == 0)
                return false;
            _screeningDayChash.Add(sessionKey, dailySession.ToList());
        }

        var overlapCheck = _screeningDayChash[sessionKey].Any(overlap =>
            request.StartScreening < overlap.EndScreening && overlap.StartScreening < request.EndScreening);

        if (overlapCheck)
            throw new Exception($"Session with a start time {request.StartScreening } and the end time {request.EndScreening} overlaps with other sessions.");
        return false;
    }
   
    public async Task GetMoviesByIdAsync(Guid Id)
    {
        var movies = await _movieRepository.GetByIdAsync(Id);
        _moviesCash.Add(movies.Id, movies);
    }
    public async Task GetMoviesAsync()
    {
        var movies = await _movieRepository.GetAllAsync();
        _moviesCash = movies.ToDictionary(m => m.Id);
    }
    
}