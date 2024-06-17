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
        Task<Reservation> Create(Reservation entity);
        Task<Reservation> Update(Reservation entity);
        Task<bool> Delete(Guid id);
        Task<Reservation> GetByScreeningId(Guid ScreeningId);
        Task<Reservation> GetByMovieId(Guid MovieId);
        Task SaveChanges();
    }
}
