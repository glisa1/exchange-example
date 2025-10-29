using Exchange_Example_Api.Data.Models;

namespace Exchange_Example_Api.Features.SearchStocks;

public record SearchStockResult
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalRecords { get; init; }

    public List<StockDto> Stocks { get; init; } = [];
}

public record StockDto
{
    public required string Ticker { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }

    public static StockDto FromEntity(Stock stock) =>
        new()
        {
            Ticker = stock.Ticker,
            Name = stock.Name,
            Description = stock.Description
        };
}
