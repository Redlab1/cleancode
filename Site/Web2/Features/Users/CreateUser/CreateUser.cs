using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web2.Features.Users.Exceptions;

namespace Web2.Features.Users.CreateUser
{
    public class CreateUser
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CreateUserController(ISender sender) : ControllerBase
        {
            [HttpPost]
            public async Task<IActionResult> Create(CreateUserRequest request)
            {
                var user = await sender.Send((CreateUserCommand)request);
                return Ok(user);
            }
        }
        public sealed class CreateUserRequest
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }

            [JsonConstructor]
            public CreateUserRequest(string name, int age, string email)
            {
                Name = name;
                Age = age;
                Email = email;
            }

            public static implicit operator CreateUserCommand(CreateUserRequest request) => new(request.Name, request.Age, request.Email);
        }
        public sealed record CreateUserCommand(string Name, int Age, string Email) : IRequest<User>;
        public class CreateUserCommandHandler(
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

                await dbContext.Users.AddAsync(user, cancellationToken);

                await dbContext.SaveChangesAsync(cancellationToken);

                await publisher.Publish(new UserCreatedDomainEvent(user.Id), cancellationToken);

                return await dbContext.Users.FindAsync(user.Id, cancellationToken);
            }
        }
        public sealed record UserCreatedDomainEvent(Guid UserId) : INotification;
    }
}
