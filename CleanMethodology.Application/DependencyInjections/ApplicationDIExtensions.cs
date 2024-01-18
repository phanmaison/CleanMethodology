using CleanMethodology.Application.Domains.User;
using Microsoft.Extensions.DependencyInjection;

namespace CleanMethodology.Application.DependencyInjections;

public static class ApplicationDIExtensions
{
    public static IServiceCollection UseApplication(this IServiceCollection services)
    {
        services.RegisterUsecases();

        return services;
    }

    private static void RegisterUsecases(this IServiceCollection services)
    {
        // the usecase is pure business logic and not expected to be subtituted hence we don't need to use interface

        services.AddScoped<UserCreateUsecase>();
    }
}
