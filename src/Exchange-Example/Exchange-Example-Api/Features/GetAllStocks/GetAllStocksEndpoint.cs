using Exchange_Example_Api.Data.Models;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetAllStocks;

public static class GetAllStocksEndpoint
{
    public static void MapGetAllStocksEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/get-all-stocks", async (IQueryRequestHandler<GetAllStocksQuery, List<Stock>> queryHandler, CancellationToken cancelationToken) =>
        {
            var stocks = await queryHandler.Handle(new GetAllStocksQuery(), cancelationToken);
            return Results.Ok(stocks);
        })
        .WithName("GetAllStocks")
        .WithTags("GetAllStocks");
    }
}
