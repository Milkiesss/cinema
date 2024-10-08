using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Reservation.Responce
{
    public class ReservationGetAllScreeningResponce : BaseReservationDto
    {
        public Guid reservationId { get; set; }
    }
}
