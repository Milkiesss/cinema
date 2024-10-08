using cinema.Application.DTOs.Movie;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using cinema.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace cinema.Infrastructure.Dal.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _db;
        public MovieRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<Movie> CreateAsync(Movie entity)
        {
            await _db.movies.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _db.movies.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            _db.movies.Remove(result);
            await SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Movie>> GetAllAsync()
        {
            return await _db.movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            var result = await _db.movies.Include(x=>x.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<Movie> UpdateAsync(Movie entity)
        {
            _db.movies.Update(entity);
            await SaveChangesAsync();
            return entity;
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
