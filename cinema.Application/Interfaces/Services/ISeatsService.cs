using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;
using cinema.Application.DTOs.Seats.Request;
using cinema.Application.DTOs.Seats.Responce;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Services
{
    public interface ISeatsService
    {
        Task<ICollection<SeatsCreateResponce>> CreateRangeAsync(SeatsCreateRequest entity);
        Task<ICollection<SeatsUpdateResponce>> UpdateRangeAsync(ICollection<SeatsUpdateRequest> entity);
        Task<bool> DeleteRowAsync(int RowNumber);
    }
}
