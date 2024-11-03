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

    public async Task<User> GetByEmailAsync(string email)
    {
        var result = await _db.users.FirstOrDefaultAsync(x => x.Email == email);
        if (result is null)
            throw new KeyNotFoundException();
        return result;
    }
    
    public async Task<User> CreateAsync(User entity)
    {
        var result = await _db.users.AnyAsync(x => x.Email == entity.Email);
        if (result is true)
            throw new Exception("user is already exist");
        await _db.users.AddAsync(entity);
        await SaveChangesAsync();
        return entity;
    }

    public async Task<bool> IsExist(string email)
    {
        return await _db.users.AnyAsync(x => x.Email == email);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}