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
        Task<ICollection<Screening>> CreateRange(ICollection<Screening> entity);
        Task<Screening> Update(Screening entity);
        Task<bool> Delete(Guid Id);
        Task<ICollection<Screening>> GetScreeningByDateAndAuditoriumId(DateTime date, Guid Id);
        Task SaveChanges();

    }
}
