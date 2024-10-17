using System.Security.Cryptography.X509Certificates;
using Ardalis.GuardClauses;
using cinema.Domain.ValueObject;

namespace cinema.Domain.Entities
{
    public class User : BaseEntity
    {
        public FullName FullName { get; set; }  
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? Token { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }

        public User(){}

        public User(Guid id, FullName fullName, string role, string email, string password)
        {
            SetId(id);
            FullName =  Guard.Against.Null(fullName);
            Role = role;
            Email = email;
            Password = password;
        }
        
    }
}
