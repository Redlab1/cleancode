using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web2.Features.Users.CreateUser;

public static class CreateUserEndpoint
{
    public static void MapEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/users", async ([FromBody] CreateUserRequest request, [FromServices] ISender sender) =>
        {
            var user = await sender.Send((CreateUserCommand)request);
            return Results.Ok(user);
        });
    }
}