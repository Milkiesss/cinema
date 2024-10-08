using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using cinema.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace cinema.Infrastructure.Dal.Repository
{
    public class AuditoriumRepository : IAuditoriumRepository
    {
        private readonly DataContext _db;
        public AuditoriumRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<Auditorium> CreateAsync(Auditorium entity)
        {
            await _db.auditoriums.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _db.auditoriums.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            _db.auditoriums.Remove(result);
            await SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Auditorium>> GetAllAsync()
        {
            return await _db.auditoriums.ToListAsync();
        }

        public async Task<Auditorium> GetByIdAsync(Guid id)
        {
            var result = await _db.auditoriums.Include(a=>a.Seats).FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<Auditorium> UpdateAsync(Auditorium entity)
        {
            _db.auditoriums.Update(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
