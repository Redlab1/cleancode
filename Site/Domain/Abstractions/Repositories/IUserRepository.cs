using Domain.Entities;

namespace Domain.Abstractions.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<bool> ExistsAsync(string name);
    Task<User?> GetByIdAsync(Guid id);
    void Delete(User user);
}