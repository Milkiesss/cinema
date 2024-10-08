using AutoMapper;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;

namespace cinema.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _rep;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<MovieCreateResponce> CreateAsync(MovieCreateRequest entity)
        {
            var result = _mapper.Map<Movie>(entity);
            await _rep.CreateAsync(result);
            return _mapper.Map<MovieCreateResponce>(result);
        }
        public async Task<MovieUpdateResponce> UpdateAsync(MovieUpdateRequest entity)
        {
            var result = _mapper.Map<Movie>(entity);
            await _rep.UpdateAsync(result);
            return _mapper.Map<MovieUpdateResponce>(result);
        } 

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _rep.DeleteAsync(id);
        }

        public async Task<ICollection<MovieGetAllResponce>> GetAllAsync()
        {
            var result = await _rep.GetAllAsync();
            return _mapper.Map<ICollection<MovieGetAllResponce>>(result);
        }

        public async Task<MovieGetByIdResponce> GetByIdAsync(Guid id)
        {
            var result = await _rep.GetByIdAsync(id);
            return _mapper.Map<MovieGetByIdResponce>(result);
        }

    }
}
