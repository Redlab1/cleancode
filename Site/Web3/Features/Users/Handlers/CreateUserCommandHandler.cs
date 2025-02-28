using MediatR;
using Microsoft.EntityFrameworkCore;
using Web3.Features.Users.Commands;
using Web3.Features.Users.Events;
using Web3.Features.Users.Models;
using Web3.Features.Users.Repositories;
using Web3.Features.Users.Validators;
using Web3.Infrastructure;

namespace Web3.Features.Users.Handlers
{
    internal class CreateUserCommandHandler(UserRepository userRepository,
        ApplicationDbContext dbContext,
        IPublisher publisher)
        : IRequestHandler<CreateUserCommand, User?>
    {
        public async Task<User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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
}
