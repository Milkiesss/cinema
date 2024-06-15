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
        public async Task<AuditoriumCreateResponce> Create(AuditoriumCreateRequest entity)
        {
            var result = _mapper.Map<Auditorium>(entity);
            await _rep.Create(result);
            return _mapper.Map<AuditoriumCreateResponce>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _rep.Delete(id);
        }

        public async Task<ICollection<AuditoriumGetAllResponce>> GetAll()
        {
            var result = await _rep.GetAll();
            return _mapper.Map<ICollection<AuditoriumGetAllResponce>>(result);
        }

        public async Task<AuditoriumGetByIdResponce> GetById(Guid id)
        {
            var result = await _rep.GetById(id);
            return _mapper.Map<AuditoriumGetByIdResponce>(result);
        }

        public async Task<AuditoriumUpdateResponce> Update(AuditoriumUpdateRequest entity)
        {
            var result = _mapper.Map<Auditorium>(entity);
            await _rep.Update(result);
            return _mapper.Map<AuditoriumUpdateResponce>(result);
        }
    }
}
