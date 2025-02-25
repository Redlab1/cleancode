using Domain.Abstractions.Repositories;
using Domain.Exceptions;
using MediatR;
using Persistence;

namespace Application.Users.Commands.CreateUser;

internal class CreateUserCommandHandler(
    IUserRepository userRepository, 
    MyDbContext dbContext) 
    : IRequestHandler<CreateUserCommand, Domain.Entities.User?>
{
    public async Task<Domain.Entities.User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await userRepository.ExistsAsync(request.Name);
        if (userExists)
            throw new EntityAlreadyExistsException($"An user with the name {request.Name} already exists!");

        var user = Domain.Entities.User.Create(request.Name, request.Age);
        await userRepository.AddAsync(user);

        await dbContext.SaveChangesAsync(cancellationToken);

        return await userRepository.GetByIdAsync(user.Id);
    }
}