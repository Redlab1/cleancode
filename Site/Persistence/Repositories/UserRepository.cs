using Application.Data;
using Domain.Abstractions.Repositories;
using Domain.Entities;

namespace Persistence.Repositories;

public class UserRepository(IApplicationDbContext dbContext) : IUserRepository
{
    public async Task CreateAsync(User user) => await dbContext.Users.AddAsync(user);

    public void Delete(User user) => dbContext.Users.Remove(user);
}