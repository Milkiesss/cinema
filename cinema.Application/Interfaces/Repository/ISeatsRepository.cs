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
        Task<ICollection<Seats>> CreateRangeAsync(ICollection<Seats> entity);
        Task<ICollection<Seats>> UpdateRangeAsync(ICollection<Seats> entity);
        Task<bool> DeleteRowAsync(int RowNumber);
        Task SaveChangesAsync();
    }
}
