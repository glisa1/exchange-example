using Exchange_Example_Api.Utils;

namespace Exchange_Example_Api.Features.BuyStocks;

public record BuyStocksModel(
    int UserId,
    int StockId,
    decimal Quantity) : IValidatable
{
    public bool IsValid() =>
        UserId > 0 &&
        StockId > 0 &&
        Quantity > 0;
}
