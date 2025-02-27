using MediatR;
namespace Web2.Features.Users.CreateUser;
public sealed record UserCreatedDomainEvent(Guid UserId) : INotification;

