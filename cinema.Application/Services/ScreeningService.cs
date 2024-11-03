using AutoMapper;
using cinema.Application.DTOs.Screening.Request;
using cinema.Application.DTOs.Screening.Response;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;

namespace cinema.Application.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _rep;
        private readonly IScreeningManagementService _managementService;
        private readonly IMapper _mapper;

        public ScreeningService(IScreeningRepository rep,IScreeningManagementService managementService, IMapper mapper)
        {
            _rep = rep;
            _managementService = managementService;
            _mapper = mapper;
        }
        public async Task<ICollection<ScreeningCreateResponse>> CreateRangeAsync(ICollection<ScreeningCreateRequest> entity)
        {
            var calculateEndTimeSession = await _managementService.GetMovieSessionEndTimeAsync(entity);
            var result = _mapper.Map<ICollection<Screening>>(calculateEndTimeSession);
            await _rep.CreateRangeAsync(result);
            return _mapper.Map<ICollection<ScreeningCreateResponse>>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _rep.DeleteAsync(id);
        }

        public async Task<ICollection<ScreeningGetByDateAndAuditoriumIdResponse>> GetDailyScreeningsByAuditoriumIdAsync(DateTime date, Guid Id)
        {
            var result = await _rep.GetScreeningByDateAndAuditoriumIdAsync(date,Id);
            return _mapper.Map<ICollection<ScreeningGetByDateAndAuditoriumIdResponse>>(result);
        }

        public async Task<ICollection<ScreeningGetByIdResponse>> GetByIdsAsync(ICollection<Guid> Ids)
        {
            var result = await _rep.GetByIdsAsync(Ids);
            return _mapper.Map<ICollection<ScreeningGetByIdResponse>>(result);
        }

        public async Task<ICollection<ScreeningUpdateResponse>> UpdateRangeAsync(ICollection<ScreeningUpdateRequest> entity)
        {
            var calculateEndTimeSession = await _managementService.GetMovieSessionEndTimeAsync(entity);
            var result = _mapper.Map<ICollection<Screening>>(calculateEndTimeSession);
            await _rep.UpdateRangeAsync(result);
            return _mapper.Map<ICollection<ScreeningUpdateResponse>>(result);
        }
    }
}
