using cinema.Application.DTOs.Screening.Request;
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
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly DataContext _db;
        public ScreeningRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Screening>> CreateRange(ICollection<Screening> entity)
        {
            await _db.AddRangeAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _db.screenings.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            _db.screenings.Remove(result);
            await SaveChanges();
            return true;
        }
        public async Task<Screening> Update(Screening entity)
        {
            _db.Update(entity);
            await SaveChanges();
            return entity;
        }
        public async Task<ICollection<Screening>> GetScreeningByDateAndAuditoriumId(DateTime date, Guid Id)
        {
           return await _db.screenings.Where(x => x.AuditoriumId == Id && x.StartScreening.Date == date.Date).ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

    }
}
