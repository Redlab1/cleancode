using MediatR;

namespace Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string Name, int Age) : IRequest<Domain.Entities.User>;