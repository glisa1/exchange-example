using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.SearchStocks;

public class SearchStockQueryHandler(ISearchStockService searchStockService) : IQueryRequestHandler<SearchStockQuery, SearchStockResult>
{
    public async Task<SearchStockResult> Handle(SearchStockQuery query, CancellationToken cancellationToken = default)
    {
        return await searchStockService.SearchStocksAsync(query.SearchTerm, query.PageNumber, query.PageSize, cancellationToken);
    }
}
