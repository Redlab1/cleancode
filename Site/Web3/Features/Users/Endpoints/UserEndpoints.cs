using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web3.Features.Users.Commands;
using Web3.Features.Users.Queries;
using Web3.Features.Users.Requests;

namespace Web3.Features.Users.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/users", async ([FromBody] CreateUserRequest request, [FromServices] ISender sender) =>
        {
            var user = await sender.Send((CreateUserCommand)request);
            return Results.Ok(user);
        });

        app.MapGet("api/users/{name}", async ([FromRoute] string name, [FromServices] ISender sender) =>
        {
            var user = await sender.Send(new GetUserQuery(name));
            return Results.Ok(user);
        });

        app.MapDelete("api/users", async ([FromBody] DeleteUserRequest request, [FromServices] ISender sender) =>
        {
            await sender.Send((DeleteUserCommand)request);
            return Results.Ok();
        });
    }
}