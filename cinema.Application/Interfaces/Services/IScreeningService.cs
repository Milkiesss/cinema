using cinema.Application.DTOs.Screening.Request;
using cinema.Application.DTOs.Seats.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema.Application.DTOs.Screening.Response;

namespace cinema.Application.Interfaces.Services
{
    public interface IScreeningService
    {
        Task<ICollection<ScreeningCreateResponse>> CreateRangeAsync(ICollection<ScreeningCreateRequest> entity);
        Task<ICollection<ScreeningUpdateResponse>> UpdateRangeAsync(ICollection<ScreeningUpdateRequest> entity);
        Task<bool> DeleteAsync(Guid id);
        Task<ICollection<ScreeningGetByDateAndAuditoriumIdResponse>> GetDailyScreeningsByAuditoriumIdAsync(DateTime date, Guid Id);
        Task<ICollection<ScreeningGetByIdResponse>> GetByIdsAsync(ICollection<Guid> Ids);
    }
}
