using AutoMapper;
using cinema.Application.DTOs.Screening.Request;
using cinema.Application.DTOs.Screening.Responce;
using cinema.Application.DTOs.Seats.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _rep;
        private readonly IMapper _mapper;

        public ScreeningService(IScreeningRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }
        public async Task<ICollection<ScreeningCreateResponce>> CreateRange(ICollection<ScreeningCreateRequest> entity)
        { 
            var result = _mapper.Map<ICollection<Screening>>(entity);
            var overlapTasks = result.Select(x =>  CheckSessionOverlap(x.StartScreening, x.EndScreening, x.AuditoriumId)).ToList();
            await Task.WhenAll(overlapTasks);
            await _rep.CreateRange(result);
            return _mapper.Map<ICollection<ScreeningCreateResponce>>(result);
        }

        public async Task<bool> CheckSessionOverlap(DateTime Start, DateTime End, Guid AuditoriumId)
        {
            var DailySession = await _rep.GetScreeningByDateAndAuditoriumId(Start.Date, AuditoriumId);

            var OverLapCheck = DailySession.Any(Overlap =>
            Start <= Overlap.EndScreening && Overlap.StartScreening >= End);

            if(OverLapCheck)
                throw new Exception($"Session with a start time {Start} and the end time {End} overlaps with other sessions.");
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _rep.Delete(id);
        }

        public async Task<ICollection<ScreeningGetByDateAndAuditoriumIdResponce>> GetDailyScreeningsByAuditoriumId(DateTime date, Guid Id)
        {
            var result = await _rep.GetScreeningByDateAndAuditoriumId(date,Id);
            return _mapper.Map<ICollection<ScreeningGetByDateAndAuditoriumIdResponce>>(result);
        }

        public Task<ScreeningUpdateResponce> Update(ScreeningUpdateRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
