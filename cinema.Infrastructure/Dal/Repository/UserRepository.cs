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

    public async Task<User?> GetByEmailAsync(string Email)
    {
        var result = await _db.users.FirstOrDefaultAsync(x => x.Email == Email);
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

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}