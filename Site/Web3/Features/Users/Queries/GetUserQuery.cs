using MediatR;
using Web3.Features.Users.Models;

namespace Web3.Features.Users.Queries
{
    public sealed record GetUserQuery(string Name) : IRequest<User>;
}
