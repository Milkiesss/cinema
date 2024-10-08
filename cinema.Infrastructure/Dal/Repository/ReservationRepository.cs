using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using cinema.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Infrastructure.Dal.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _db;
        public ReservationRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<Reservation> CreateAsync(Reservation entity)
        {
            await _db.reservations.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _db.reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            _db.reservations.Remove(result);
            await SaveChangesAsync();
            return true;
        }

        public async Task<Reservation> GetByScreeningIdAsync(Guid ScreeningId)
        {
            var result = await _db.reservations.Include(x => x.Seat).Include(x=> x.Screening).FirstOrDefaultAsync(x => x.ScreeningId == ScreeningId);
            if (result is null)
                throw new KeyNotFoundException();
            return result;
        }
        public async Task<Reservation> GetByMovieIdAsync(Guid MovieId)
        {
            var result = await _db.reservations.Include(x => x.Seat)
                .Include(x=> x.Screening)
                .ThenInclude(x=>x.Movie)
                .FirstOrDefaultAsync(x => x.Screening.MovieId == MovieId);
            if (result is null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<Reservation> UpdateAsync(Reservation entity)
        {
            _db.reservations.Update(entity);
            await SaveChangesAsync();
            return entity;
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
