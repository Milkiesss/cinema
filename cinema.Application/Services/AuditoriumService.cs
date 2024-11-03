using AutoMapper;
using cinema.Application.DTOs.Auditorium.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;

using cinema.Application.DTOs.Auditorium.Response;

namespace cinema.Application.Services
{
    public class AuditoriumService : IAuditoriumService
    {
        private readonly IAuditoriumRepository _rep;
        private readonly IMapper _mapper;
        public AuditoriumService(IAuditoriumRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }
        public async Task<AuditoriumCreateResponse> CreateAsync(AuditoriumCreateRequest entity)
        {
            var result = _mapper.Map<Auditorium>(entity);
            await _rep.CreateAsync(result);
            return _mapper.Map<AuditoriumCreateResponse>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _rep.DeleteAsync(id);
        }

        public async Task<ICollection<AuditoriumGetAllResponse>> GetAllAsync()
        {
            var result = await _rep.GetAllAsync();
            return _mapper.Map<ICollection<AuditoriumGetAllResponse>>(result);
        }

        public async Task<AuditoriumGetByIdResponse> GetByIdAsync(Guid id)
        {
            var result = await _rep.GetByIdAsync(id);
            return _mapper.Map<AuditoriumGetByIdResponse>(result);
        }

        public async Task<AuditoriumUpdateResponse> UpdateAsync(AuditoriumUpdateRequest entity)
        {
            var result = _mapper.Map<Auditorium>(entity);
            await _rep.UpdateAsync(result);
            return _mapper.Map<AuditoriumUpdateResponse>(result);
        }
    }
}
