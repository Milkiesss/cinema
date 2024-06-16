using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Screening.Request
{
    public class ScreeningUpdateRequest : BaseScreeningDto
    {
        public Guid id { get; set; }
    }
}
