using System.Text.Json.Serialization;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserRequest
{
    public string Name { get; set; }
    public int Age { get; set; }

    [JsonConstructor]
    public CreateUserRequest(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public static implicit operator CreateUserCommand(CreateUserRequest request) => new(request.Name, request.Age);
}