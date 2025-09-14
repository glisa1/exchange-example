using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.CreateUser;

public class CreateUserCommandHandler(ICreateUserService createUserService) : ICommandRequestHandler<CreateUserCommand, bool>
{
    public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        var existingUser = await createUserService.UserExistsByEmail(command.Email, cancellationToken);
        if (existingUser)
        {
            return await Task.FromResult(true);
        }

        await createUserService.CreateUser(command, cancellationToken);

        return await Task.FromResult(true);
    }
}
