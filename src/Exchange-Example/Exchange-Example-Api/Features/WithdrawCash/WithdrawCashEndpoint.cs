using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.WithdrawCash;

public static class WithdrawCashEndpoint
{
    public static void MapWithdrawCashEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/withdraw", async (WithdrawCashCommand command, ICommandRequestHandler<WithdrawCashCommand, WithdrawCashResult> commandHandler) =>
        {
            if (!command.IsValid())
            {
                return Results.BadRequest("Invalid request data");
            }

            var result = await commandHandler.Handle(command);
            return result switch
            {
                WithdrawCashResult.Success => Results.Ok("Withdrawal successful"),
                WithdrawCashResult.InsufficientFunds => Results.Problem("Insufficient funds"),
                WithdrawCashResult.UserNotFound => Results.NotFound("User not found"),
                _ => Results.StatusCode(500)
            };
        });
    }
}
