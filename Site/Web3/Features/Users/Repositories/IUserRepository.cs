using Web3.Features.Users.Models;

namespace Web3.Features.Users.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    void Delete(User user);
}