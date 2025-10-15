using Exchange_Example_Api.Features.BuyStocks;
using Exchange_Example_Api.Features.CreateUser;
using Exchange_Example_Api.Features.DepositCash;
using Exchange_Example_Api.Features.GetAllStocks;
using Exchange_Example_Api.Features.GetStatus;
using Exchange_Example_Api.Features.GetUserBalance;
using Exchange_Example_Api.Features.GetUserStocks;
using Exchange_Example_Api.Features.WithdrawCash;

namespace Exchange_Example_Api.Configuration;

public static class CustomEndpointConfiguration
{
    public static void MapAllCustomEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGetStatusEndpoint();
        app.MapGetUserStocksEndpoint();
        app.MapBuyStocksEndpoint();
        app.MapGetAllStocksEndpoint();
        app.MapCreateUserEndpoint();
        app.MapDepositCashEndpoint();
        app.MapGetUserBalanceEndpoint();
        app.MapWithdrawCashEndpoint();
    }
}
