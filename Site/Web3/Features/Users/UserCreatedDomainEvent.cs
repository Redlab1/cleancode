using MediatR;

namespace Web3.Features.Users;
public sealed record UserCreatedDomainEvent(Guid UserId) : INotification;

