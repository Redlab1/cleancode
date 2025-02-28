using MediatR;

namespace Web2.Features.Users.DeleteUser;

internal sealed class DeleteUserCommandHandler(UserDbContext dbContext//DeleteUserRepository deleteUserRepository
    ) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FindAsync(request.Id, cancellationToken);
        if (user is null)
            throw new UserNotFoundException(request.Id);

        dbContext.Users.Remove(user);
        //deleteUserRepository.Delete(user);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}