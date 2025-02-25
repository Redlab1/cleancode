using Domain.Abstractions.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseSqlServer("Data Source=localhost;Initial Catalog=CleanCodeDB;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=30");
        });

        return services;
    }

    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();
    }
}