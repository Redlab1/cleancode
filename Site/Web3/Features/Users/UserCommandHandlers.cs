using MediatR;
using Microsoft.EntityFrameworkCore;
using Web3.Infrastructure;

namespace Web3.Features.Users
{
    public class UserCommandHandlers
    {
        internal class CreateUserCommandHandler(UserRepository userRepository,
            ApplicationDbContext dbContext,
            IPublisher publisher)
            : IRequestHandler<UserCommands.CreateUserCommand, User?>
        {
            public async Task<User?> Handle(UserCommands.CreateUserCommand request, CancellationToken cancellationToken)
            {
                var userExists = await dbContext.Users.AnyAsync(x => x.Email.Equals(request.Email, StringComparison.InvariantCultureIgnoreCase), cancellationToken);
                if (userExists)
                    throw new UserException.UserAlreadyExistsException(request.Email);

                var user = User.Create(request.Name, request.Age, request.Email);

                await userRepository.CreateAsync(user);

                await dbContext.SaveChangesAsync(cancellationToken);

                await publisher.Publish(new UserCreatedDomainEvent(user.Id), cancellationToken);

                return await dbContext.Users.FindAsync(user.Id, cancellationToken);
            }
        }

        internal sealed class DeleteUserCommandHandler(ApplicationDbContext dbContext, UserRepository userRepository
        ) : IRequestHandler<UserCommands.DeleteUserCommand>
        {
            public async Task Handle(UserCommands.DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await dbContext.Users.FindAsync(request.Id, cancellationToken);
                if (user is null)
                    throw new UserException.UserNotFoundException(request.Id);

                userRepository.Delete(user);

                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
