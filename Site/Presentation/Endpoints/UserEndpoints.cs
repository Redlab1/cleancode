using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Endpoints;

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