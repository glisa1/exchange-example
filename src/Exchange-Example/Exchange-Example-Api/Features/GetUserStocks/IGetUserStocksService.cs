using Exchange_Example_Api.Data.Models;

namespace Exchange_Example_Api.Features.GetUserStocks;

public interface IGetUserStocksService
{
    Task<List<UserStocks>> GetUserStocksAsync(int userId, CancellationToken cancellationToken = default);
}
