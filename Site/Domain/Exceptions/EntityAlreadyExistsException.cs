namespace Domain.Exceptions;

public class EntityAlreadyExistsException(string email) : Exception($"An user with the email {email} already exists!");