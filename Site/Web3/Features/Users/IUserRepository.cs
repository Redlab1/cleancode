namespace Web3.Features.Users;

public interface IUserRepository
{
    Task CreateAsync(User user);
    void Delete(User user);
}