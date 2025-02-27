namespace Web2.Features.Users.DeleteUser
{
    public class DeleteUserRepository(UserDbContext dbContext)
    {
        public void Delete(User user) => dbContext.Users.Remove(user);
    }

}
