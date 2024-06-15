using AutoMapper;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<MovieCreateResponce> Create(MovieCreateRequest entity)
        {
            var result = _mapper.Map<Movie>(entity);
            await _rep.Create(result);
            return _mapper.Map<MovieCreateResponce>(result);
        }
        public async Task<MovieUpdateResponce> Update(MovieUpdateRequest entity)
        {
            var result = _mapper.Map<Movie>(entity);
            await _rep.Update(result);
            return _mapper.Map<MovieUpdateResponce>(result);
        } 

        public async Task<bool> Delete(Guid id)
        {
            return await _rep.Delete(id);
        }

        public async Task<ICollection<MovieGetAllResponce>> GetAll()
        {
            var result = await _rep.GetAll();
            return _mapper.Map<ICollection<MovieGetAllResponce>>(result);
        }

        public async Task<MovieGetByIdResponce> GetById(Guid id)
        {
            var result = await _rep.GetById(id);
            return _mapper.Map<MovieGetByIdResponce>(result);
        }

    }
}
