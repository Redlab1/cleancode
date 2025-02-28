namespace Web2.Features.Users.DeleteUser;

public sealed class UserNotFoundException(Guid id) : Exception($"Entity with Id {id} was not found!");