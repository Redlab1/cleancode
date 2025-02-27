namespace Web2.Features.Users.Exceptions;

public sealed class UserNotFoundException(Guid id) : Exception($"Entity with Id {id} was not found!");