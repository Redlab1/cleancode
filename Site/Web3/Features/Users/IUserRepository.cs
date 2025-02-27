namespace Web3.Features.Users;

public interface IUserRepository
{
    Task AddAsync(User user);
    void Delete(User user);
}