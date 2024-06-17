


using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Reservation
{
    public class BaseReservationDto
    {
        public Guid ScreeningId { get; set; }
        public Guid SeatId { get; set; }
        public Guid UserId { get; set; }
    }
}
