using Exchange_Example_Api.Features.BuyStocks;
using Exchange_Example_Api.Features.GetAllStocks;
using Exchange_Example_Api.Features.GetStatus;
using Exchange_Example_Api.Features.GetUserStocks;

namespace Exchange_Example_Api.Configuration;

public static class CustomEndpointConfiguration
{
    public static void MapAllCustomEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGetStatusEndpoint();
        app.MapGetUserStocksEndpoint();
        app.MapBuyStocksEndpoint();
        app.MapGetAllStocksEndpoint();
    }
}
