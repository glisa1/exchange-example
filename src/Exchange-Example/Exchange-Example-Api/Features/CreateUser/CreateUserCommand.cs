using Exchange_Example_Api.Utils;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.CreateUser;

public sealed class CreateUserCommand() : Command, IValidatable
{
    public string KeycloakId { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public double Balance { get; init; }

    public bool IsValid() =>
        !string.IsNullOrEmpty(KeycloakId) &&
        Guid.Parse(KeycloakId) != Guid.Empty &&
        !string.IsNullOrWhiteSpace(Username) &&
        !string.IsNullOrWhiteSpace(Email) &&
        Balance >= 0;
}
