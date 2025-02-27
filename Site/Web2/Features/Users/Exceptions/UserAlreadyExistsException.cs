namespace Web2.Features.Users.Exceptions;

public class UserAlreadyExistsException(string email) : Exception($"An user with the email {email} already exists!");