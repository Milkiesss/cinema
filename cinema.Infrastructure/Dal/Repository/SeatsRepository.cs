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
        public async Task<ICollection<Seats>> CreateRangeAsync(ICollection<Seats> entity)
        {
            await _db.seats.AddRangeAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteRowAsync(int RowNumber)
        {
            var result = await _db.seats.FirstOrDefaultAsync(x => x.RowNumber == RowNumber);
            if (result is null)
                throw new KeyNotFoundException();
            _db.seats.Remove(result);
            await SaveChangesAsync();
            return true;
        }
        
        public async Task<ICollection<Seats>> UpdateRangeAsync(ICollection<Seats> entity)
        {
            _db.seats.UpdateRange(entity);
            await SaveChangesAsync();     
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
