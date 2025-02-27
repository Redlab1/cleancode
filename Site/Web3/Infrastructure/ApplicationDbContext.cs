using Microsoft.EntityFrameworkCore;
using Web3.Features.Users;

namespace Web3.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }

    public DbSet<User> Users { get; set; }
    //public DbSet<Products> Products { get; set; }
}