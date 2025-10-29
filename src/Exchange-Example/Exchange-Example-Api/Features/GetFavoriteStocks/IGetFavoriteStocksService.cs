using Exchange_Example_Api.Data.Models;

namespace Exchange_Example_Api.Features.GetFavoriteStocks;

public interface IGetFavoriteStocksService
{
    Task<List<Stock>> GetFavoriteStocks(Guid userId, CancellationToken cancellationToken = default);
}
