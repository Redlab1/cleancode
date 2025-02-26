using Application.Configurations;
using Infrastructure.Configurations;
using Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddPersistence()
    .AddInfrastructure();

builder.Services.AddControllers()
    .AddApplicationPart(Application.Configurations.AssemblyReference.Assembly)
    .AddControllersAsServices();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MigrateDatabase();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
