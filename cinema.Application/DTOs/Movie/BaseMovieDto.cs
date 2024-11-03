using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Movie
{
    public class BaseMovieDto
    {
        public DateTime ReleaseDate { get; set; }
        public int FilmRentalDurationDays { get; set; }
        public int DurationMinuts { get; set; }
        public int restriction { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
    }
}
