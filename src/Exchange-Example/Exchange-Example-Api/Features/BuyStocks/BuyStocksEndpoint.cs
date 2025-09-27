using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.BuyStocks;

public static class BuyStocksEndpoint
{
    public static void MapBuyStocksEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/but-stocks", async (BuyStocksCommand stocks, ICommandRequestHandler<BuyStocksCommand, bool> commandHandler, CancellationToken cancellationToken) =>
        {
            if (!stocks.IsValid())
            {
                return Results.BadRequest(new { Message = "Invalid input data." });
            }

            var result = await commandHandler.Handle(stocks, cancellationToken);

            if (!result)
            {
                return Results.NotFound(new { Message = $"Stock with ID {stocks.StockId} not found." });
            }

            return Results.Ok();
        })
        .WithName("BuyStocks")
        .WithTags("BuyStocks");
    }
}
