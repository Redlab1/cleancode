using Newtonsoft.Json;
using Web3.Features.Users.Commands;

namespace Web3.Features.Users.Requests
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

        public static implicit operator CreateUserCommand(CreateUserRequest request) => new(request.Name, request.Age, request.Email);
    }
}
