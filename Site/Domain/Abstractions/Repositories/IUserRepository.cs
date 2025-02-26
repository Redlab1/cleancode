using Domain.Entities;

namespace Domain.Abstractions.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    void Delete(User user);
}