using MediatR;
using Web3.Features.Users.Models;

namespace Web3.Features.Users.Commands
{
    public sealed record CreateUserCommand(string Name, int Age, string Email) : IRequest<User>;
}
