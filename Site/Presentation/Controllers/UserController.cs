using Application.Users.Commands.CreateUser;
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
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok();
    }
}