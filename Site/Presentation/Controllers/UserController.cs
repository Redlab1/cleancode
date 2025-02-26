using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        var user = await sender.Send((CreateUserCommand)request);
        return Ok(user);
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var user = await sender.Send(new GetUserQuery(name));
        return Ok(user);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteUserRequest request)
    {
        await sender.Send((DeleteUserCommand)request);
        return Ok();
    }
}