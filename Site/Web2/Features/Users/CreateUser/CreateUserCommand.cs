using MediatR;

namespace Web2.Features.Users.CreateUser;

public sealed record CreateUserCommand(string Name, int Age, string Email) : IRequest<User>;