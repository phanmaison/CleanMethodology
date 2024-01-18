using CleanMethodology.Application.Domains.User;
using Microsoft.AspNetCore.Mvc;

namespace CleanMethodology.Api.Endpoints;

public static class UserEndpoints
{
    public static WebApplication RegisterUserEndpoints(this WebApplication app)
    {
        // GET /users
        app.MapGet("/users", async ([FromServices] UserListUsecase userListUsecase) =>
        {
            var users = await userListUsecase.ExecuteAsync();

            return users;
        })
        .WithTags("User")
        .WithName("UserList")
        .WithSummary("List all users")
        .WithOpenApi();

        // POST /users
        app.MapPost("/users", async ([FromBody] UserCreateUsecase.Request request, [FromServices] UserCreateUsecase userCreateUsecase) =>
        {
            var user = await userCreateUsecase.ExecuteAsync(request);

            return user;
        })
        .WithTags("User")
        .WithName("UserCreate")
        .WithSummary("Create a new user")
        .WithOpenApi();

        return app;
    }


}