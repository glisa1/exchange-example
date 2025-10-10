using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.DepositCash;

public static class DepositCashEndpoint
{
    public static void MapDepositCashEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/deposit-cash", async (DepositCashCommand command, ICommandRequestHandler<DepositCashCommand, DepositCashResult> commandHandler, HttpContext context) =>
        {
            if (!command.IsValid())
            {
                return Results.BadRequest(new { Message = "Invalid input data." });
            }

            var result = await commandHandler.Handle(command);

            return result switch
            {
                DepositCashResult.Success => Results.Ok("Deposit successful"),
                DepositCashResult.UserNotFound => Results.NotFound("User not found"),
                _ => Results.StatusCode(500)
            };
        })
        .WithName("DepositCash")
        .WithTags("DepositCash")
        .Produces<decimal>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
