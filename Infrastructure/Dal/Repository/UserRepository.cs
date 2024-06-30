using cinema.Application.Interfaces.Repository;
using cinema.Domain.Entities;
using cinema.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace cinema.Infrastructure.Dal.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _db;

    public UserRepository(DataContext db)
    {
        _db = db;
    }
    public async Task<User> Create(User entity)
    {
        await _db.users.AddAsync(entity);
        await SaveChanges();
        return entity;
    }

    public async Task<User> Update(User entity)
    {
        _db.users.Update(entity);
        await SaveChanges();
        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var result = await _db.users.FirstOrDefaultAsync(x => x.Id == id);
        if (result is null)
            throw new KeyNotFoundException();
        _db.users.Remove(result);
        await SaveChanges();
        return true;
    }

    public async Task<User> GetById(Guid id)
    {
        var result = await _db.users.FirstOrDefaultAsync(x => x.Id == id);
        if (result is null)
            throw new KeyNotFoundException();
        return result;
    }

    public async Task<ICollection<User>> GetAll()
    {
        return await _db.users.ToListAsync();
    }
    public async Task<User> Login(User entity)
    {
        var UserExist = await _db.users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == entity.Email);
        if (UserExist is null)
            throw new InvalidOperationException("User with specified email does not exist.");

        return UserExist;
    }
    public async Task SaveChanges()
    {
        await _db.SaveChangesAsync();
    }
}