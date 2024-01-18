using CleanMethodology.Application.Contracts.Repositories;
using CleanMethodology.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanMethodology.Infrastructure.DependencyInjections;

public static class InfrastructureDIExtensions
{
    public static IServiceCollection UseInfrastructure(this IServiceCollection services)
    {
        services.RegisterRepositories();

        return services;
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
