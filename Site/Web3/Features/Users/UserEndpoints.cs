using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web3.Features.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/users", async ([FromBody] UserRequests.CreateUserRequest request, [FromServices] ISender sender) =>
        {
            var user = await sender.Send((UserCommands.CreateUserCommand)request);
            return Results.Ok(user);
        });

        app.MapGet("api/users/{name}", async ([FromRoute] string name, [FromServices] ISender sender) =>
        {
            var user = await sender.Send(new UserQueries.GetUserQuery(name));
            return Results.Ok(user);
        });

        app.MapDelete("api/users", async ([FromBody] UserRequests.DeleteUserRequest request, [FromServices] ISender sender) =>
        {
            await sender.Send((UserCommands.DeleteUserCommand)request);
            return Results.Ok();
        });
    }
}