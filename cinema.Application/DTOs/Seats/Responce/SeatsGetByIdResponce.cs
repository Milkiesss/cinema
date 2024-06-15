using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Seats.Responce
{
    public class SeatsGetByIdResponce : BaseSeatsDto
    {
        public Guid Id { get; set; }
    }
}
