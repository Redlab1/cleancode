using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUser;

internal sealed class GetUserQueryHandler(IApplicationDbContext dbContext) : IRequestHandler<GetUserQuery, User>
{
    public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken) => 
        await dbContext.Users.FirstOrDefaultAsync(x => x.Name == request.Name.ToLower(), cancellationToken: cancellationToken);
}