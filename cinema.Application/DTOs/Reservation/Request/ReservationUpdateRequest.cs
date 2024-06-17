using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Reservation.Request
{
    public class ReservationUpdateRequest : BaseReservationDto
    {
        public Guid Id { get; set; }
    }
}
