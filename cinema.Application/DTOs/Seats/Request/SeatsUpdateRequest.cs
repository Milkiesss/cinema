using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Seats.Request
{
    public class SeatsUpdateRequest : BaseSeatsDto
    { 
        public Guid Id { get; set; }
    }

}
