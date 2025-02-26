using MediatR;

namespace Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string Name, int Age, string Email) : IRequest<Domain.Entities.User>;