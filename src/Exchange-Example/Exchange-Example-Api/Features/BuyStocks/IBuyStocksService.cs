namespace Exchange_Example_Api.Features.BuyStocks;

public interface IBuyStocksService
{
    public Task BuyStocks(BuyStocksModel model);

    public Task<bool> StockExists(int stockId);
}
