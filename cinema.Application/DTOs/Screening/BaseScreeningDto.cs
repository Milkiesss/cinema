using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Screening
{
    public class BaseScreeningDto
    {
        public Guid MovieId { get; set; }
        public Guid AuditoriumId { get; set; }
        public DateTime StartScreening { get; set; }
        public DateTime EndScreening { get; set; }
    }
}
