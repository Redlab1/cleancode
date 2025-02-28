using MediatR;
using Web3.Features.Users.Commands;
using Web3.Features.Users.Repositories;
using Web3.Features.Users.Validators;
using Web3.Infrastructure;

namespace Web3.Features.Users.Handlers
{
    internal sealed class DeleteUserCommandHandler(ApplicationDbContext dbContext, UserRepository userRepository
    ) : IRequestHandler<DeleteUserCommand>
    {
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users.FindAsync(request.Id, cancellationToken);
            if (user is null)
                throw new UserException.UserNotFoundException(request.Id);

            userRepository.Delete(user);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
