namespace Web2.Features.Users.CreateUser;

public class UserAlreadyExistsException(string email) : Exception($"An user with the email {email} already exists!");