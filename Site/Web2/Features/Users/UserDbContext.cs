using Microsoft.EntityFrameworkCore;

namespace Web2.Features.Users;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}