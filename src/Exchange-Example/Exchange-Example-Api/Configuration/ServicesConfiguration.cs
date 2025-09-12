using Exchange_Example_Api.Features.BuyStocks;
using Exchange_Example_Api.Features.CreateUser;
using Exchange_Example_Api.Features.GetAllStocks;

namespace Exchange_Example_Api.Configuration;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IBuyStocksService, BuyStocksService>();
        services.AddScoped<IGetAllStocksService, GetAllStocksService>();
        services.AddScoped<ICreateUserService, CreateUserService>();
    }
}
