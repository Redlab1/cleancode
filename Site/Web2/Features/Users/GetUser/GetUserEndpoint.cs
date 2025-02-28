using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web2.Features.Users.GetUser;

public static class GetUserEndpoint
{
    public static void MapEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/users/{name}", async ([FromRoute] string name, [FromServices] ISender sender) =>
        {
            var user = await sender.Send(new GetUserQuery(name));
            return Results.Ok(user);
        });
    }
}