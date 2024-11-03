using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Seats.Request;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.Application.DTOs.Seats.Response;

namespace cinema.Application.Interfaces.Services
{
    public interface ISeatsService
    {
        Task<ICollection<SeatsCreateResponse>> CreateRangeAsync(SeatsCreateRequest entity);
        Task<ICollection<SeatsUpdateResponse>> UpdateRangeAsync(ICollection<SeatsUpdateRequest> entity);
        Task<bool> DeleteRowAsync(int RowNumber);
    }
}
