namespace Exchange_Example_Api.Features.CreateUser;

public interface ICreateUserService
{
    Task<bool> UserExistsByEmail(string email, CancellationToken cancellationToken = default);

    Task CreateUser(CreateUserCommand command, CancellationToken cancellationToken = default);
}
