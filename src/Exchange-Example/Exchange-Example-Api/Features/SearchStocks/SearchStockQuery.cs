using Exchange_Example_Api.Utils;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.SearchStocks;

public sealed class SearchStockQuery : Query, IValidatable
{
    public required string SearchTerm { get; init; }
    public required int PageNumber { get; init; }
    public required int PageSize { get; init; }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(SearchTerm)
               && PageNumber > 0
               && PageSize > 0;
    }
}
