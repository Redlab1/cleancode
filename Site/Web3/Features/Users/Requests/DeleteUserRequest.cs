using Newtonsoft.Json;
using Web3.Features.Users.Commands;

namespace Web3.Features.Users.Requests
{
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
}
