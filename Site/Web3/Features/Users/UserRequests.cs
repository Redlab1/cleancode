using Newtonsoft.Json;

namespace Web3.Features.Users
{
    public class UserRequests
    {
        public sealed class CreateUserRequest
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }

            [JsonConstructor]
            public CreateUserRequest(string name, int age, string email)
            {
                Name = name;
                Age = age;
                Email = email;
            }

            public static implicit operator UserCommands.CreateUserCommand(CreateUserRequest request) => new(request.Name, request.Age, request.Email);
        }
        public sealed class DeleteUserRequest
        {
            public Guid Id { get; }

            [JsonConstructor]
            public DeleteUserRequest(Guid id)
            {
                Id = id;
            }

            public static implicit operator UserCommands.DeleteUserCommand(DeleteUserRequest request) => new(request.Id);
        }
    }
}
