using cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Repository
{
    public interface ISeatsRepository 
    {
        Task<ICollection<Seats>> CreateRange(ICollection<Seats> entity);
        Task<ICollection<Seats>> UpdateRange(ICollection<Seats> entity);
        Task<bool> DeleteRow(int RowNumber);
        Task<ICollection<Seats>> GetSeatsByAuditoriumId(Guid id);
        Task SaveChanges();
    }
}
