using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Domain.Entities
{
    public class MovieStatistic : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public int BoxOfficeReceipts { get; set; }

    }
}
