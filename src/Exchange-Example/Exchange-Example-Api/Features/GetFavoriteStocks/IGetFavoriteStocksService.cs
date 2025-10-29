using Exchange_Example_Api.Data.Models;

namespace Exchange_Example_Api.Features.GetFavoriteStocks;

public interface IGetFavoriteStocksService
{
    Task<List<Stock>> GetFavoriteStocks(int userId, CancellationToken cancellationToken = default);
}
