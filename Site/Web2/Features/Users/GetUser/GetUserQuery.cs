using MediatR;

namespace Web2.Features.Users.GetUser;

public sealed record GetUserQuery(string Name) : IRequest<User>;