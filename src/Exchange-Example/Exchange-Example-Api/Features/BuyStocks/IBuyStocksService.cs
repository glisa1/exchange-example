using Exchange_Example_Api.Data.Models;

namespace Exchange_Example_Api.Features.BuyStocks;

public interface IBuyStocksService
{
    public Task BuyStocks(BuyStocksModel model, Stock stock);

    public Task<Stock?> GetStockById(int stockId);
}
