using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web2.Features.Users.DeleteUser;

public static class DeleteUserEndpoint
{
    public static void MapEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("api/users", async ([FromBody] DeleteUserRequest request, [FromServices] ISender sender) =>
        {
            await sender.Send((DeleteUserCommand)request);
            return Results.Ok();
        });
    }
}