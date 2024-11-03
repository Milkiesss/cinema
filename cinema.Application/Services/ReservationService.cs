using AutoMapper;
using cinema.Application.DTOs.Reservation.Request;
using cinema.Application.DTOs.Reservation.Response;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;

namespace cinema.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _rep;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }
        public async Task<ReservationCreateResponse> CreateAsync(ReservationCreateRequest entity)
        {
            var result = _mapper.Map<Reservation>(entity);
            await _rep.CreateAsync(result);
            return _mapper.Map<ReservationCreateResponse>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _rep.DeleteAsync(id);
        }

        public async Task<ReservationGetAllScreeningResponse> GetByScreeningIdAsync(Guid ScreeningId)
        {
            var result = await _rep.GetByScreeningIdAsync(ScreeningId);
            return _mapper.Map<ReservationGetAllScreeningResponse>(result);
        }

        public async Task<ReservationGetByMovieIdResponse> GetByMovieIdAsync(Guid MovieId)
        {
            var result = await _rep.GetByMovieIdAsync(MovieId);
            return _mapper.Map<ReservationGetByMovieIdResponse>(result);
        }

        public async Task<ReservationUpdateResponse> UpdateAsync(ReservationUpdateRequest entity)
        {
            var result = _mapper.Map<Reservation>(entity);
            await _rep.UpdateAsync(result);
            return _mapper.Map<ReservationUpdateResponse>(result);

        }
    }
}
