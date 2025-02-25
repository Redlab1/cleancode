using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository(MyDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user) => await dbContext.Users.AddAsync(user);

    public async Task<bool> ExistsAsync(string name) => await dbContext.Users.AnyAsync(x => x.Name == name);

    public async Task<User?> GetByIdAsync(Guid id) => await dbContext.Users.FindAsync(id);

    public void Delete(User user) => dbContext.Users.Remove(user);
}