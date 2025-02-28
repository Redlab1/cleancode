namespace Web2.Features.Users.CreateUser
{
    public class CreateUserRepository(UserDbContext dbContext)
    {
        public async Task CreateAsync(User user) => await dbContext.Users.AddAsync(user);
    }
}
