  using AutoMapper;
using cinema.Application.DTOs.Movie.Responce;
using cinema.Application.DTOs.Seats.Request;
using cinema.Application.DTOs.Seats.Responce;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using System.Collections;
using System.Runtime.InteropServices;

namespace cinema.Application.Services
{
    public class SeatsService : ISeatsService
    {
        private readonly ISeatsRepository _rep;
        private readonly ISeatManagementService _serv;
        private readonly IMapper _mapper;
        public SeatsService(ISeatsRepository SeatRep, ISeatManagementService serv, IMapper mapper)
        {
            _rep = SeatRep;
            _serv = serv;
            _mapper = mapper;
        }
        public async Task<ICollection<SeatsCreateResponce>> CreateRange(SeatsCreateRequest entity)
        {
            var GetAllSeats = _serv.FillSeats(entity);
            var result = _mapper.Map<ICollection<Seats>>(GetAllSeats);
            await _rep.CreateRange(result);
            await _serv.CountCapacity(entity.AuditoriumId);
            return _mapper.Map<ICollection<SeatsCreateResponce>>(result);
        }

        public async Task<bool> DeleteRow(int RowNumber)
        {
            return await _rep.DeleteRow(RowNumber);
        }

        public async Task<ICollection<SeatsGetAllResponce>> GetAll()
        {
            var result = await _rep.GetAll();
            return _mapper.Map<ICollection<SeatsGetAllResponce>>(result);
        }

        public async Task<ICollection<SeatsGetByIdResponce>> GetSeatsByAuditoriumId(Guid id)
        {
            var result = await _rep.GetSeatsByAuditoriumId(id);
            return _mapper.Map<ICollection<SeatsGetByIdResponce>>(result);
        }

        public async Task<ICollection<SeatsUpdateResponce>> UpdateRange(ICollection<SeatsUpdateRequest> entity)
        {
            var result = _mapper.Map<ICollection<Seats>>(entity);
            await _rep.Update(result);
            return _mapper.Map<ICollection<SeatsUpdateResponce>>(result);

        }
    }
}
