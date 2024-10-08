using cinema.Application.DTOs.Screening.Request;
using cinema.Application.DTOs.Screening.Responce;
using cinema.Application.DTOs.Seats.Request;
using cinema.Application.DTOs.Seats.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Services
{
    public interface IScreeningService
    {
        Task<ICollection<ScreeningCreateResponce>> CreateRangeAsync(ICollection<ScreeningCreateRequest> entity);
        Task<ICollection<ScreeningUpdateResponce>> UpdateRangeAsync(ICollection<ScreeningUpdateRequest> entity);
        Task<bool> DeleteAsync(Guid id);
        Task<ICollection<ScreeningGetByDateAndAuditoriumIdResponce>> GetDailyScreeningsByAuditoriumIdAsync(DateTime date, Guid Id);
        Task<ICollection<ScreeningGetByIdResponce>> GetByIdsAsync(ICollection<Guid> Ids);
    }
}
