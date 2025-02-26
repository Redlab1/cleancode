using System.Text.Json.Serialization;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserRequest
{
    public string Name { get; }

    public int Age { get; }
    
    public string Email { get; }

    [JsonConstructor]
    public CreateUserRequest(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
    }

    public static implicit operator CreateUserCommand(CreateUserRequest request) => new(request.Name, request.Age, request.Email);
}