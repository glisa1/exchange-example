namespace Exchange_Example_Api.Features.CreateUser;

public static class CreateUserEndpoint
{
    public static void MapCreateUserEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/create-user", async (CreateUserCommand user, ICreateUserService createUserService) =>
        {
            if (!user.IsValid())
            {
                return Results.BadRequest(new { Message = "Invalid input data." });
            }

            var existingUser = await createUserService.UserExistsByEmail(user.Email);
            if (existingUser)
            {
                return Results.Ok();
            }

            await createUserService.CreateUser(user);
            return Results.Ok();
        })
        .WithName("CreateUser")
        .WithTags("CreateUser");
    }
}
