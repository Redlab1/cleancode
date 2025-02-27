using System.Text.Json.Serialization;

namespace Web2.Features.Users.DeleteUser;

public sealed class DeleteUserRequest
{
    public Guid Id { get; }

    [JsonConstructor]
    public DeleteUserRequest(Guid id)
    {
        Id = id;
    }

    public static implicit operator DeleteUserCommand(DeleteUserRequest request) => new(request.Id);
}