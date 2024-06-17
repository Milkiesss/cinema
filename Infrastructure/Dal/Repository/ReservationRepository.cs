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
        public async Task<Reservation> Create(Reservation entity)
        {
            await _db.reservations.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _db.reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            _db.reservations.Remove(result);
            await SaveChanges();
            return true;
        }

        public async Task<Reservation> GetByScreeningId(Guid ScreeningId)
        {
            var result = await _db.reservations.Include(x => x.Seat).Include(x=> x.Screening).FirstOrDefaultAsync(x => x.ScreeningId == ScreeningId);
            if (result is null)
                throw new KeyNotFoundException();
            return result;
        }
        public async Task<Reservation> GetByMovieId(Guid MovieId)
        {
            var result = await _db.reservations.Include(x => x.Seat)
                .Include(x=> x.Screening)
                .ThenInclude(x=>x.Movie)
                .FirstOrDefaultAsync(x => x.Screening.MovieId == MovieId);
            if (result is null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<Reservation> Update(Reservation entity)
        {
            _db.reservations.Update(entity);
            await SaveChanges();
            return entity;
        }
        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
