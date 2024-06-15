using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Seats
{
    public class BaseSeatsDto
    {
        public Guid AuditoriumId { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public int PriceModifire { get; set; }
    }
}
