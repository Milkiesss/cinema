using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Screening.Request
{
    public class ScreeningGetByDateAndAuditoriumIdRequest
    {
        public Guid AuditoriumId { get; set; }
        public DateTime Date { get; set; }
    }
}
