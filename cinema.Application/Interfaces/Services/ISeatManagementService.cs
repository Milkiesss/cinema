using cinema.Application.DTOs.Seats.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Services
{
    public interface ISeatManagementService
    {
        public ICollection<SeatsCreateRequest> FillSeats(SeatsCreateRequest seats);
        Task<bool> CountCapacity(Guid Id);
    }
}
