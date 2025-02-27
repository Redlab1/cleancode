using Web3.Infrastructure;

namespace Web3.Features.Users;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task CreateAsync(User user) => await dbContext.Users.AddAsync(user);

    public void Delete(User user) => dbContext.Users.Remove(user);
}