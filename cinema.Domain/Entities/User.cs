using Ardalis.GuardClauses;
using cinema.Domain.Enums;
using cinema.Domain.ValueObject;

namespace cinema.Domain.Entities
{
    public class User : BaseEntity
    {
        public FullName FullName { get; set; }  
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age => DateTime.Now.Year - BirthDate.Year;
        public EnumRole? Role { get; set; } 
        public string? Token { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }

        public User(){}

        public User(Guid id, FullName fullName, EnumRole role,DateTime birthDate ,string email, string password)
        {
            SetId(id);
            FullName =  Guard.Against.Null(fullName);
            BirthDate = birthDate;
            Role = role;
            Email = email;
            Password = password;
        }
        
    }
}
