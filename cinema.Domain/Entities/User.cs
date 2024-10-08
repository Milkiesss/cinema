using cinema.Domain.ValueObject;

namespace cinema.Domain.Entities
{
    public class User : BaseEntity
    {
        public FullName FullName { get; set; }  
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
