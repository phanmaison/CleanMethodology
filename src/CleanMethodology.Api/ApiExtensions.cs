using CleanMethodology.Api.Endpoints;
using CleanMethodology.Core.Exceptions;
using CleanMethodology.Core.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using System.Net;

namespace CleanMethodology.Api;

public static class ApiExtensions
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
                Title = $"Clean Methodology",
                Description = "Sample implementation of CleanArchitecture: use Usecase and top-down approach"
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

    public static void UseApiEndpoints(this WebApplication app)
    {
        app.ConfigureExceptionHandler();

        // minimal endpoints
        app
            .RegisterUserEndpoints()
            .RegisterWeatherForecastEndpoints();
    }

    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "text/html";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature == null)
                    return;

                var exception = contextFeature.Error;

                if (exception is BusinessException businessException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    await context.Response.WriteAsync(businessException.Message);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    LogHelper.Error("Unhandled error", exception);

                    await context.Response.WriteAsync($"Internal Server Error: {exception.Message}");
                }
            });
        });
    }
}
