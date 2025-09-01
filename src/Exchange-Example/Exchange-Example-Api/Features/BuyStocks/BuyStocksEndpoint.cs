namespace Exchange_Example_Api.Features.BuyStocks;

public static class BuyStocksEndpoint
{
    public static void MapBuyStocksEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/but-stocks", async (BuyStocksModel stocks, IBuyStocksService buyStocksService) =>
        {
            if (!stocks.IsValid())
            {
                return Results.BadRequest(new { Message = "Invalid input data." });
            }

            if (!await buyStocksService.StockExists(stocks.StockId))
            {
                return Results.NotFound(new { Message = $"Stock with ID {stocks.StockId} not found." });
            }

            // Additional check if the user has money to buy the stocks. But that could also be handled in another api call.

            await buyStocksService.BuyStocks(stocks);

            return Results.Ok();
        })
        .WithName("BuyStocks")
        .WithTags("BuyStocks");
    }
}
