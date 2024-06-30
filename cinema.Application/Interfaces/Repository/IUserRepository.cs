using cinema.Domain.Entities;

namespace cinema.Application.Interfaces.Repository;

public interface IUserRepository : IBaseRepository<User>
{
     Task<User> Login(User entity);
}