using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Web2.Features.Users.GetUser;

internal sealed class GetUserQueryHandler(UserDbContext dbContext) : IRequestHandler<GetUserQuery, User>
{
    public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken) => 
        await dbContext.Users.FirstOrDefaultAsync(x => x.Name == request.Name.ToLower(), cancellationToken: cancellationToken);
}