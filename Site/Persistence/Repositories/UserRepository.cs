using Application.Data;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository(IApplicationDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user) => await dbContext.Users.AddAsync(user);

    public void Delete(User user) => dbContext.Users.Remove(user);
}