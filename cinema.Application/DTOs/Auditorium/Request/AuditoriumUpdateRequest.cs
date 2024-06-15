using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Auditorium.Request
{
    public class AuditoriumUpdateRequest : BaseAuditoriumDto
    {
        public Guid Id { get; set; }
    }
}
