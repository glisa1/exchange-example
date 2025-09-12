using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.CreateUser;

public class CreateUserService(AppDbContext dbContext) : ICreateUserService
{
    public async Task CreateUser(CreateUserCommand command)
    {
        var newUser = new User
        {
            KeycloakId = Guid.Parse(command.KeycloakId),
            Username = command.Username,
            Email = command.Email,
            Balance = command.Balance
        };

        await dbContext.Users.AddAsync(newUser);

        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> UserExistsByEmail(string email)
    {
        return await dbContext.Users.AnyAsync(u => u.Email == email);
    }
}
