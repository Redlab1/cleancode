namespace Web3.Features.Users
{
    public static class UserException
    {
        public class UserAlreadyExistsException(string email) : Exception($"An user with the email {email} already exists!");
        public sealed class UserNotFoundException(Guid id) : Exception($"Entity with Id {id} was not found!");
    }
}
