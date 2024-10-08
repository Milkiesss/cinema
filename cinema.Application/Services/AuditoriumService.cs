using AutoMapper;
using cinema.Application.DTOs.Auditorium.Request;
using cinema.Application.DTOs.Auditorium.Responce;
using cinema.Application.DTOs.Movie.Responce;
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
    public class AuditoriumService : IAuditoriumService
    {
        private readonly IAuditoriumRepository _rep;
        private readonly IMapper _mapper;
        public AuditoriumService(IAuditoriumRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }
        public async Task<AuditoriumCreateResponce> CreateAsync(AuditoriumCreateRequest entity)
        {
            var result = _mapper.Map<Auditorium>(entity);
            await _rep.CreateAsync(result);
            return _mapper.Map<AuditoriumCreateResponce>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _rep.DeleteAsync(id);
        }

        public async Task<ICollection<AuditoriumGetAllResponce>> GetAllAsync()
        {
            var result = await _rep.GetAllAsync();
            return _mapper.Map<ICollection<AuditoriumGetAllResponce>>(result);
        }

        public async Task<AuditoriumGetByIdResponce> GetByIdAsync(Guid id)
        {
            var result = await _rep.GetByIdAsync(id);
            return _mapper.Map<AuditoriumGetByIdResponce>(result);
        }

        public async Task<AuditoriumUpdateResponce> UpdateAsync(AuditoriumUpdateRequest entity)
        {
            var result = _mapper.Map<Auditorium>(entity);
            await _rep.UpdateAsync(result);
            return _mapper.Map<AuditoriumUpdateResponce>(result);
        }
    }
}
