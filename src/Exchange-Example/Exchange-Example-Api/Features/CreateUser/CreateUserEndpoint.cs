using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.CreateUser;

public static class CreateUserEndpoint
{
    public static void MapCreateUserEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/create-user", async (CreateUserCommand user, ICommandRequestHandler<CreateUserCommand, bool> commandHandler, CancellationToken cancelationToken) =>
        {
            if (!user.IsValid())
            {
                return Results.BadRequest(new { Message = "Invalid input data." });
            }

            await commandHandler.Handle(user, cancelationToken);

            return Results.Ok();
        })
        .WithName("CreateUser")
        .WithTags("CreateUser");
    }
}
