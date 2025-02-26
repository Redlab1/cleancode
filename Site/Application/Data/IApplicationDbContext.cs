using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}