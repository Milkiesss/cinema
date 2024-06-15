using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<MovieCreateResponce> Create(MovieCreateRequest entity);
        Task<MovieUpdateResponce> Update(MovieUpdateRequest entity);
        Task<bool> Delete(Guid id);
        Task<MovieGetByIdResponce> GetById(Guid id);
        Task<ICollection<MovieGetAllResponce>> GetAll();
    }
}
