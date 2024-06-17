using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.Application.DTOs.Reservation.Request;
using cinema.Application.DTOs.Reservation.Responce;

namespace cinema.Application.Interfaces.Services
{
    public interface IReservationService
    {
        Task<ReservationCreateResponce> Create(ReservationCreateRequest entity);
        Task<ReservationUpdateResponce> Update(ReservationUpdateRequest entity);
        Task<bool> Delete(Guid id);
        Task<ReservationGetAllScreeningResponce> GetByScreeningId(Guid ScreeningId);
        Task<ReservationGetByMovieIdResponce> GetByMovieId(Guid MovieId);
    }
}
