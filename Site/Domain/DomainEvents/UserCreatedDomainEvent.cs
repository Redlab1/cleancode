using MediatR;

namespace Domain.DomainEvents;

public sealed record UserCreatedDomainEvent(Guid UserId) : INotification;