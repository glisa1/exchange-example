namespace Exchange_Example_Api.Features.CreateUser;

public interface ICreateUserService
{
    Task<bool> UserExistsByEmail(string email);

    Task CreateUser(CreateUserCommand command);
}
