namespace Exchange_Example_Api.Features.SearchStocks;

public interface ISearchStockService
{
    Task<SearchStockResult> SearchStocksAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken);
}
