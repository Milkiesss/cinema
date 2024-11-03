using cinema.Domain.Entities;

namespace cinema.Application.Interfaces.Repository;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task<User> CreateAsync(User entity);
    Task<bool> IsExist(string email);
    Task SaveChangesAsync();
}