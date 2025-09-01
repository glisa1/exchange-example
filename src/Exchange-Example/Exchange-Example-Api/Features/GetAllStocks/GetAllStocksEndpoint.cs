namespace Exchange_Example_Api.Features.GetAllStocks;

public static class GetAllStocksEndpoint
{
    public static void MapGetAllStocksEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/get-all-stocks", async (IGetAllStocksService getAllStocksService) =>
        {
            var stocks = await getAllStocksService.GetAllStocks();
            return Results.Ok(stocks);
        })
        .WithName("GetAllStocks")
        .WithTags("GetAllStocks");
    }
}
