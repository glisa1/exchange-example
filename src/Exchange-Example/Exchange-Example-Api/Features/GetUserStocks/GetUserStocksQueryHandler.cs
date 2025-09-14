using Exchange_Example_Api.Data.Models;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetUserStocks;

public sealed class GetUserStocksQueryHandler(IGetUserStocksService getUserStocksService) : IQueryRequestHandler<GetUserStocksQuery, List<UserStocks>>
{
    public async Task<List<UserStocks>> Handle(GetUserStocksQuery query, CancellationToken cancellationToken = default)
    {
        return await getUserStocksService.GetUserStocksAsync(query.UserId, cancellationToken);
    }
}
