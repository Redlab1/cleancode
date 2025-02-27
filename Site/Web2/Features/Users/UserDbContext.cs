using Microsoft.EntityFrameworkCore;
using Web2.Infrastructure;

namespace Web2.Features.Users;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }

    public DbSet<User> Users { get; set; }
}