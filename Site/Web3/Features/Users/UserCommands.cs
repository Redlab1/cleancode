using MediatR;

namespace Web3.Features.Users
{
    public class UserCommands
    {
        public sealed record DeleteUserCommand(Guid Id) : IRequest;
        public sealed record CreateUserCommand(string Name, int Age, string Email) : IRequest<User>;
    }
}
