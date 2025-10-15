using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetUserBalance;

public static class GetUserBalanceEndpoint
{
    public static void MapGetUserBalanceEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/user-balance/{userId}", async (Guid userId, IQueryRequestHandler<GetUserBalanceQuery, double> queryRequestHandler, CancellationToken cancellationToken) =>
        {
            if (userId == Guid.Empty)
            {
                return Results.BadRequest(new { Message = "Invalid user ID." });
            }

            var query = new GetUserBalanceQuery { UserId = userId };
            var balance = await queryRequestHandler.Handle(query, cancellationToken);

            return Results.Ok(new { Balance = balance });
        })
        .WithName("GetUserBalance")
        .WithTags("UserBalance");
    }
}
