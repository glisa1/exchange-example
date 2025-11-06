using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetFavoriteStocks;

public sealed class GetFavoriteStocksQueryHandler(IGetFavoriteStocksService getFavoriteStocksService) : IQueryRequestHandler<GetFavoriteStocksQuery, List<GetFavoriteStocksDto>>
{
    public async Task<List<GetFavoriteStocksDto>> Handle(GetFavoriteStocksQuery query, CancellationToken cancellationToken = default)
    {
        var favoriteStocks = await getFavoriteStocksService.GetFavoriteStocks(query.UserId, cancellationToken);

        return [.. favoriteStocks
            .Select(stock => new GetFavoriteStocksDto(
                stock.Ticker,
                stock.Name,
                stock.Description))];
    }
}
