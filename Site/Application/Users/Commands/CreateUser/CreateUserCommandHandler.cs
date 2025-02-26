using Application.Data;
using Domain.Abstractions.Repositories;
using Domain.DomainEvents;
using Domain.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.CreateUser;

internal class CreateUserCommandHandler(IUserRepository userRepository, 
    IApplicationDbContext dbContext,
    IPublisher publisher) 
    : IRequestHandler<CreateUserCommand, User?>
{
    public async Task<User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await dbContext.Users.AnyAsync(x => x.Name == request.Name, cancellationToken);
        if (userExists)
            throw new EntityAlreadyExistsException(request.Name);

        var user = User.Create(request.Name, request.Age, request.Email);
        
        await userRepository.AddAsync(user);

        await dbContext.SaveChangesAsync(cancellationToken);

        await publisher.Publish(new UserCreatedDomainEvent(user.Id), cancellationToken);

        return await dbContext.Users.FindAsync(user.Id, cancellationToken);
    }
}