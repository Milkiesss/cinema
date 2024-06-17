using AutoMapper;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;
using cinema.Application.DTOs.Reservation.Request;
using cinema.Application.DTOs.Reservation.Responce;
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
        public async Task<ReservationCreateResponce> Create(ReservationCreateRequest entity)
        {
            var result = _mapper.Map<Reservation>(entity);
            await _rep.Create(result);
            return _mapper.Map<ReservationCreateResponce>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _rep.Delete(id);
        }

        public async Task<ReservationGetAllScreeningResponce> GetByScreeningId(Guid ScreeningId)
        {
            var result = await _rep.GetByScreeningId(ScreeningId);
            return _mapper.Map<ReservationGetAllScreeningResponce>(result);
        }

        public async Task<ReservationGetByMovieIdResponce> GetByMovieId(Guid MovieId)
        {
            var result = await _rep.GetByMovieId(MovieId);
            return _mapper.Map<ReservationGetByMovieIdResponce>(result);
        }

        public async Task<ReservationUpdateResponce> Update(ReservationUpdateRequest entity)
        {
            var result = _mapper.Map<Reservation>(entity);
            await _rep.Update(result);
            return _mapper.Map<ReservationUpdateResponce>(result);

        }
    }
}
