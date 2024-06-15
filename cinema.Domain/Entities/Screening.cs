using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Domain.Entities
{
    public class Screening : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public DateTime StartScreening { get; set; }
        public DateTime EndScreening { get; set; }
        public Guid AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; }
    }
}
