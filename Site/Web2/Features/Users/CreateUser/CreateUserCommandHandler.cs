using MediatR;
using Microsoft.EntityFrameworkCore;
using Web2.Infrastructure;
using Web2.Features.Users.Exceptions;

namespace Web2.Features.Users.CreateUser;

internal class CreateUserCommandHandler(//CreateUserRepository createUserRepository,
    UserDbContext dbContext,
    IPublisher publisher)
    : IRequestHandler<CreateUserCommand, User?>
{
    public async Task<User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await dbContext.Users.AnyAsync(x => x.Email.Equals(request.Email, StringComparison.InvariantCultureIgnoreCase), cancellationToken);
        if (userExists)
            throw new UserAlreadyExistsException(request.Email);

        var user = User.Create(request.Name, request.Age, request.Email);

        //await createUserRepository.CreateAsync(user);
        await dbContext.Users.AddAsync(user, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        await publisher.Publish(new UserCreatedDomainEvent(user.Id), cancellationToken);

        return await dbContext.Users.FindAsync(user.Id, cancellationToken);
    }
}