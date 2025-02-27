using MediatR;

namespace Web2.Features.Users.DeleteUser;

public sealed record DeleteUserCommand(Guid Id) : IRequest;