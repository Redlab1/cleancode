﻿using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
        return services;
    }
}