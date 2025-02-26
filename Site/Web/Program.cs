using Application.Configurations;
using Infrastructure.Configurations;
using Persistence.Configurations;
using Presentation.Endpoints;

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

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });

    app.MigrateDatabase();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapUserEndpoints();

app.Run();
