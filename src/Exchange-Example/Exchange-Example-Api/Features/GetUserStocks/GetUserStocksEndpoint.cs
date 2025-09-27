using Exchange_Example_Api.Data.Models;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetUserStocks;

public static class GetUserStocksEndpoint
{
    public static void MapGetUserStocksEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/user-stocks/{userId}", async (int userId, IQueryRequestHandler<GetUserStocksQuery, List<UserStocks>> queryRequestHandler, CancellationToken cancellationToken) =>
        {
            if (userId <= 0)
            {
                return Results.BadRequest(new { Message = "Invalid user ID." });
            }

            var query = new GetUserStocksQuery { UserId = userId };

            var userStocks = await queryRequestHandler.Handle(query, cancellationToken);

            return Results.Ok(userStocks);
        })
        .WithName("GetUserStocks")
        .WithTags("UserStocks");
    }
}
