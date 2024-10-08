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
        Task<ReservationCreateResponce> CreateAsync(ReservationCreateRequest entity);
        Task<ReservationUpdateResponce> UpdateAsync(ReservationUpdateRequest entity);
        Task<bool> DeleteAsync(Guid id);
        Task<ReservationGetAllScreeningResponce> GetByScreeningIdAsync(Guid ScreeningId);
        Task<ReservationGetByMovieIdResponce> GetByMovieIdAsync(Guid MovieId);
    }
}
