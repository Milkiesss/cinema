using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Domain.Entities
{
    public class ReservationStatistic 
    {
        public Guid Userid { get; set; }
        public User User { get; set; }
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public bool Arrived { get; set; }
    }
}
