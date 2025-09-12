using Exchange_Example_Api.Utils;

namespace Exchange_Example_Api.Features.CreateUser;

public record CreateUserCommand(string KeycloakId, string Username, string Email, double Balance) : IValidatable
{
    public bool IsValid() =>
        !string.IsNullOrEmpty(KeycloakId) &&
        Guid.Parse(KeycloakId) != Guid.Empty &&
        !string.IsNullOrWhiteSpace(Username) &&
        !string.IsNullOrWhiteSpace(Email) &&
        Balance >= 0;
}
