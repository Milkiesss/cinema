using cinema.Application.DTOs.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Auditorium
{
    public class BaseAuditoriumDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<BaseSeatsDto> Seats { get; set; }
    }
}
