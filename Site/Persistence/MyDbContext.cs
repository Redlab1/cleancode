using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }

    public DbSet<Domain.Entities.User> Users { get; set; }
}