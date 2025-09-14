using Exchange_Example_Api.Data.Models;
using Exchange_Example_Api.Features.BuyStocks;
using Exchange_Example_Api.Features.CreateUser;
using Exchange_Example_Api.Features.GetAllStocks;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Configuration;

public static class RequestHandlerConfiguration
{
    public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
    {
        services.AddScoped<IQueryRequestHandler<GetAllStocksQuery, List<Stock>>, GetAllStocksQueryHandler>();

        services.AddScoped<ICommandRequestHandler<CreateUserCommand, bool>, CreateUserCommandHandler>();
        services.AddScoped<ICommandRequestHandler<BuyStocksCommand, bool>, BuyStocksCommandHandler>();

        return services;
    }
}
