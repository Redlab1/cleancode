using Application.Data;
using Domain.Exceptions;
using MediatR;

namespace Application.Users.Commands.DeleteUser;

internal sealed class DeleteUserCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FindAsync(request.Id, cancellationToken);
        if (user is null)
            throw new EntityNotFoundException(request.Id);

        dbContext.Users.Remove(user);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}