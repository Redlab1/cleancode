using MediatR;

namespace Web3.Features.Users.Commands
{
    public sealed record DeleteUserCommand(Guid Id) : IRequest;
}
