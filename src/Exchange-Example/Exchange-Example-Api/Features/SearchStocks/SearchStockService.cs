using Exchange_Example_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.SearchStocks;

public class SearchStockService(AppDbContext appDbContext) : ISearchStockService
{
    public async Task<SearchStockResult> SearchStocksAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var allSearchResults = appDbContext.Stocks
            .Where(s => s.Ticker.Contains(searchTerm) || s.Name.Contains(searchTerm))
            .OrderBy(s => s.Ticker);

        var totalRecords = await allSearchResults.CountAsync(cancellationToken);

        var pagedResults = allSearchResults
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(StockDto.FromEntity)
            .ToList();

        return new SearchStockResult
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = totalRecords,
            Stocks = pagedResults
        };
    }
}
