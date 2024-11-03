using System.ComponentModel.DataAnnotations;
namespace cinema.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public DateTime ReleaseDate { get; set; }
        public int FilmRentalDurationDays { get; set; }
        public int DurationMinuts { get; set; }
        public string ImageUrl { get; set; }
        public int Restriction { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public ICollection<Comment>? Comments { get; set; }//now
    }
}
