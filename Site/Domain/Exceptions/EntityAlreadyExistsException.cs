namespace Domain.Exceptions;

public class EntityAlreadyExistsException(string name) : Exception($"An user with the name {name} already exists!");