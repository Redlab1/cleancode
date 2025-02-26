using Domain.Entities;
using MediatR;

namespace Application.Users.Queries.GetUser;

public sealed record GetUserQuery(string Name) : IRequest<User>;