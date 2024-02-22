using CleanMethodology.Application.Contracts.Repositories;
using CleanMethodology.Application.Contracts.Services;
using CleanMethodology.Infrastructure.Repositories;
using CleanMethodology.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanMethodology.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection UseInfrastructure(this IServiceCollection services)
    {
        services.RegisterServices();

        services.RegisterRepositories();

        return services;
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IEmailTemplateService, EmailTemplateService>();
    }
}
