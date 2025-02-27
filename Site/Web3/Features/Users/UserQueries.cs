using MediatR;

namespace Web3.Features.Users
{
    public class UserQueries
    {
        public sealed record GetUserQuery(string Name) : IRequest<User>;
    }
}
