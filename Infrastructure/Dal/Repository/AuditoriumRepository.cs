using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using cinema.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Infrastructure.Dal.Repository
{
    public class AuditoriumRepository : IAuditoriumRepository
    {
        private readonly DataContext _db;
        public AuditoriumRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<Auditorium> Create(Auditorium entity)
        {
            await _db.auditoriums.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _db.auditoriums.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            _db.auditoriums.Remove(result);
            await SaveChanges();
            return true;
        }

        public async Task<ICollection<Auditorium>> GetAll()
        {
            return await _db.auditoriums.ToListAsync();
        }

        public async Task<Auditorium> GetById(Guid id)
        {
            var result = await _db.auditoriums.Include(a=>a.Seats).FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<Auditorium> Update(Auditorium entity)
        {
            _db.auditoriums.Update(entity);
            await SaveChanges();
            return entity;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
