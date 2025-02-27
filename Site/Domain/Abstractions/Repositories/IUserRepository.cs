using Domain.Entities;

namespace Domain.Abstractions.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    void Delete(User user);
}