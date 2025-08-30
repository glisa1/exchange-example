using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Endpoints.GetUserStocks;

public static class GetUserStocksEndpoint
{
    public static void MapGetUserStocksEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/user-stocks/{userId}", async (int userId, Data.AppDbContext dbContext) =>
        {
            var userStocks = await dbContext.UserStocks
                .Where(us => us.UserId == userId)
                .ToListAsync();
            if (userStocks == null || userStocks.Count == 0)
            {
                return Results.NotFound(new { Message = "No stocks found for the specified user." });
            }
            return Results.Ok(userStocks);
        })
        .WithName("GetUserStocks")
        .WithTags("UserStocks");
    }
}
