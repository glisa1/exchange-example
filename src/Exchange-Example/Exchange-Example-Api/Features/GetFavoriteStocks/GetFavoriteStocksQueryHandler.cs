using Exchange_Example_Api.Data.Models;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetFavoriteStocks;

public sealed class GetFavoriteStocksQueryHandler(IGetFavoriteStocksService getFavoriteStocksService) : IQueryRequestHandler<GetFavoriteStocksQuery, List<Stock>>
{
    public async Task<List<Stock>> Handle(GetFavoriteStocksQuery query, CancellationToken cancellationToken = default)
    {
        return await getFavoriteStocksService.GetFavoriteStocks(query.UserId, cancellationToken);
    }
}
