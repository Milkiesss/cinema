using cinema.Application.DTOs.Screening.Request;
using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Repository
{
    public interface IScreeningRepository
    {
        Task<ICollection<Screening>> CreateRangeAsync(ICollection<Screening> entity);
        Task<ICollection<Screening>> UpdateRangeAsync(ICollection<Screening> entity);
        Task<bool> DeleteAsync(Guid Id);
        Task<ICollection<Screening>> GetScreeningByDateAndAuditoriumIdAsync(DateTime date, Guid Id);
        Task<ICollection<Screening>> GetByIdsAsync(ICollection<Guid> Ids);
        Task SaveChangesAsync();

    }
}
