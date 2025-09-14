using Exchange_Example_Api.Data.Models;

namespace Exchange_Example_Api.Features.BuyStocks;

public interface IBuyStocksService
{
    public Task BuyStocks(BuyStocksCommand model, Stock stock, CancellationToken cancellationToken = default);

    public Task<Stock?> GetStockById(int stockId, CancellationToken cancellationToken = default);
}
