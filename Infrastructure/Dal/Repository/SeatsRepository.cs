using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using cinema.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace cinema.Infrastructure.Dal.Repository
{
    public class SeatsRepository : ISeatsRepository
    {
        private readonly DataContext _db;
        public SeatsRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Seats>> CreateRange(ICollection<Seats> entity)
        {
            await _db.seats.AddRangeAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<bool> DeleteRow(int RowNumber)
        {
            var result = await _db.seats.FirstOrDefaultAsync(x => x.RowNumber == RowNumber);
            if (result is null)
                throw new KeyNotFoundException();
            _db.seats.Remove(result);
            await SaveChanges();
            return true;
        }

        public async Task<ICollection<Seats>> GetSeatsByAuditoriumId(Guid id)
        {
            var result = await _db.seats.Where(x => x.AuditoriumId == id).ToListAsync();
            if (result is null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<ICollection<Seats>> UpdateRange(ICollection<Seats> entity)
        {

            _db.seats.UpdateRange(entity);
            await SaveChanges();     
            return entity;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
