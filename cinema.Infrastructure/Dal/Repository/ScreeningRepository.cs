using cinema.Application.DTOs.Screening.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using cinema.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace cinema.Infrastructure.Dal.Repository
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly DataContext _db;
        public ScreeningRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Screening>> CreateRangeAsync(ICollection<Screening> entity)
        {
            await _db.AddRangeAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _db.screenings.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            _db.screenings.Remove(result);
            await SaveChangesAsync();
            return true;
        }
        public async Task<ICollection<Screening>> UpdateRangeAsync(ICollection<Screening> entity)
        {
            _db.UpdateRange(entity);
            await SaveChangesAsync();
            return entity;
        }
        public async Task<ICollection<Screening>> GetScreeningByDateAndAuditoriumIdAsync(DateTime date, Guid Id)
        {
           return await _db.screenings.Where(x => x.AuditoriumId == Id && x.StartScreening.Date == date.Date).ToListAsync();
        }

        public async Task<ICollection<Screening>> GetByIdsAsync(ICollection<Guid> Ids)
        {
            return await _db.screenings.Where(x => Ids.Contains(x.Id)).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
