using Exchange_Example_Api.Utils.Request;
using Microsoft.AspNetCore.Mvc;

namespace Exchange_Example_Api.Features.GetFavoriteStocks;

public static class GetFavoriteStocksEndpoint
{
    public static void MapGetFavoriteStocksEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/get-favorite-stocks", async (
            IQueryRequestHandler<GetFavoriteStocksQuery, List<GetFavoriteStocksDto>> queryHandler,
            [FromQuery] Guid userId,
            CancellationToken cancelationToken) =>
        {
            var query = new GetFavoriteStocksQuery
            {
                UserId = userId
            };

            if (!query.IsValid())
            {
                return Results.BadRequest(new { Message = "Invalid user ID." });
            }

            var stocks = await queryHandler.Handle(query, cancelationToken);
            return Results.Ok(stocks);
        })
        .WithName("GetFavoriteStocks")
        .WithTags("GetFavoriteStocks");
    }
}
