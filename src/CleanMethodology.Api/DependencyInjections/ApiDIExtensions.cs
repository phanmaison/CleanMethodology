using Microsoft.OpenApi.Models;

namespace CleanMethodology.Api.DependencyInjections;

public static class ApiDIExtensions
{
    public static IServiceCollection UseApi(this IServiceCollection services)
    {
        services.ConfigureSwagger();

        return services;
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = $"v1",
                Title = $"CleanMethodology Sample",
                Description = "Sample implementation of CleanArchitecture"
            });

            options.UseInlineDefinitionsForEnums();

            options.DescribeAllParametersInCamelCase();

            options.CustomSchemaIds((type) =>
            {
                if (type.FullName?.Contains('+') == true)
                {
                    var lastIndex = type.FullName.LastIndexOf(".", StringComparison.Ordinal);
                    var name = type.FullName[(lastIndex + 1)..];
                    return name.Replace("+", ".");
                }

                return type.Name;
            });
        });

    }
}
