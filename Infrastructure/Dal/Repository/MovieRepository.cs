using cinema.Application.DTOs.Movie;
using cinema.Application.DTOs.Movie.Pag;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Pagination;
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
        public async Task<Movie> Create(Movie entity)
        {
            await _db.movies.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _db.movies.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            _db.movies.Remove(result);
            await SaveChanges();
            return true;
        }

        public async Task<ICollection<Movie>> GetAll()
        {
            return await _db.movies.ToListAsync();
        }

        public async Task<Movie> GetById(Guid id)
        {
            var result = await _db.movies.Include(x=>x.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
                throw new KeyNotFoundException();
            return result;
        }

        public async Task<Movie> Update(Movie entity)
        {
            _db.movies.Update(entity);
            await SaveChanges();
            return entity;
        }
        public async Task<MoviePagResponce> GetPagedMovies(MoviePagRequest request)
        {
            var query = _db.movies.AsQueryable();
            var movieList = PaginationExtension.GetPageResponce<Movie, MoviePagResponce, MovieLIstItems>(query, request, x =>
                new MovieLIstItems
                {
                    Id = x.Id,
                    Title = x.Title,
                    // Добавьте остальные поля, которые вам нужны для MovieListItem
                });
            return movieList;
        }
        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
