using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Repository
{
    public interface IReservationRepository 
    {
        Task<Reservation> CreateAsync(Reservation entity);
        Task<Reservation> UpdateAsync(Reservation entity);
        Task<bool> DeleteAsync(Guid id);
        Task<Reservation> GetByScreeningIdAsync(Guid ScreeningId);
        Task<Reservation> GetByMovieIdAsync(Guid MovieId);
        Task SaveChangesAsync();
    }
}
