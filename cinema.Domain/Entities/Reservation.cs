using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public Guid ScreeningId { get; set; }
        public Screening Screening { get; set; }
        public Guid SeatId { get; set; }
        public Seats Seat { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
