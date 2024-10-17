using cinema.Domain.Entities;

namespace cinema.Application.Interfaces.Repository;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string Email);
    Task<User> CreateAsync(User entity);
    Task SaveChangesAsync();
}