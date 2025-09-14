using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.CreateUser;

public sealed class CreateUserCommandHandler(ICreateUserService createUserService) : ICommandRequestHandler<CreateUserCommand, bool>
{
    public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        var existingUser = await createUserService.UserExistsByEmail(command.Email, cancellationToken);
        if (existingUser)
        {
            return true;
        }

        await createUserService.CreateUser(command, cancellationToken);

        return false;
    }
}
