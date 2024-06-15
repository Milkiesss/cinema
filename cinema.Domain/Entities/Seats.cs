using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Domain.Entities
{
    public class Seats : BaseEntity
    {
        public Guid AuditoriumId { get; set; }
        public virtual Auditorium Auditorium { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; } 
        public int PriceModifire { get; set; }
    }
}
