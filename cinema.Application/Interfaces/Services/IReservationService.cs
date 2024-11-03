using cinema.Application.DTOs.Movie.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.Application.DTOs.Reservation.Request;
using cinema.Application.DTOs.Reservation.Response;

namespace cinema.Application.Interfaces.Services
{
    public interface IReservationService
    {
        Task<ReservationCreateResponse> CreateAsync(ReservationCreateRequest entity);
        Task<ReservationUpdateResponse> UpdateAsync(ReservationUpdateRequest entity);
        Task<bool> DeleteAsync(Guid id);
        Task<ReservationGetAllScreeningResponse> GetByScreeningIdAsync(Guid ScreeningId);
        Task<ReservationGetByMovieIdResponse> GetByMovieIdAsync(Guid MovieId);
    }
}
