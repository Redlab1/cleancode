using MediatR;

namespace Web3.Features.Users.Events;
public sealed record UserCreatedDomainEvent(Guid UserId) : INotification;

