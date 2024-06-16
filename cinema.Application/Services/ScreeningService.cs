using AutoMapper;
using cinema.Application.DTOs.Screening.Request;
using cinema.Application.DTOs.Screening.Responce;
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
            var GetEndTime = await CalculateEndTime(entity);
            var result = _mapper.Map<ICollection<Screening>>(GetEndTime);
            await _rep.CreateRange(result);
            return _mapper.Map<ICollection<ScreeningCreateResponce>>(result);
        }

        public Task<ICollection<ScreeningCreateRequest>> CalculateEndTime(ICollection<ScreeningCreateRequest> request)
        {
            var GetDailyScreeining = GetDailyScreeningsByAuditoriumId(request.)
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
