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
        Task<ICollection<ScreeningCreateResponce>> CreateRange(ICollection<ScreeningCreateRequest> entity);
        Task<ScreeningUpdateResponce> Update(ScreeningUpdateRequest entity);
        Task<bool> Delete(Guid id);
        Task<ICollection<ScreeningGetByDateAndAuditoriumIdResponce>> GetDailyScreeningsByAuditoriumId(DateTime date, Guid Id);

    }
}
