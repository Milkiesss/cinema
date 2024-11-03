  using AutoMapper;
  using cinema.Application.DTOs.Seats.Request;
  using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using System.Collections;
using System.Runtime.InteropServices;
using cinema.Application.DTOs.Seats.Response;

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
        public async Task<ICollection<SeatsCreateResponse>> CreateRangeAsync(SeatsCreateRequest entity)
        {
            var GetAllSeats = await _serv.FillSeatsAsync(entity);
            var result = _mapper.Map<ICollection<Seats>>(GetAllSeats);
            await _rep.CreateRangeAsync(result);
            await _serv.CountCapacityAsync(entity.AuditoriumId);
            return _mapper.Map<ICollection<SeatsCreateResponse>>(result);
        }

        public async Task<bool> DeleteRowAsync(int RowNumber)
        {
            return await _rep.DeleteRowAsync(RowNumber);
        }

        public async Task<ICollection<SeatsUpdateResponse>> UpdateRangeAsync(ICollection<SeatsUpdateRequest> entity)
        {
            var result = _mapper.Map<ICollection<Seats>>(entity);
            await _rep.UpdateRangeAsync(result);
            return _mapper.Map<ICollection<SeatsUpdateResponse>>(result);
        }
    }
}
