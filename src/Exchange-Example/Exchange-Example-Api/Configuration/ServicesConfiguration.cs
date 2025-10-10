using Exchange_Example_Api.Features.BuyStocks;
using Exchange_Example_Api.Features.CreateUser;
using Exchange_Example_Api.Features.DepositCash;
using Exchange_Example_Api.Features.GetAllStocks;
using Exchange_Example_Api.Features.GetUserBalance;
using Exchange_Example_Api.Features.GetUserStocks;
using Exchange_Example_Api.Features.WithdrawCash;

namespace Exchange_Example_Api.Configuration;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IBuyStocksService, BuyStocksService>();
        services.AddScoped<IGetAllStocksService, GetAllStocksService>();
        services.AddScoped<ICreateUserService, CreateUserService>();
        services.AddScoped<IGetUserStocksService, GetUserStocksService>();
        services.AddScoped<IGetUserBalanceService, GetUserBalanceService>();
        services.AddScoped<IDepositCashService, DepositCashService>();
        services.AddScoped<IWithdrawCashService, WithdrawCashService>();
    }
}
