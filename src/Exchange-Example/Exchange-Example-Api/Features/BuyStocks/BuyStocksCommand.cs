using Exchange_Example_Api.Utils;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.BuyStocks;

public class BuyStocksCommand : Command, IValidatable
{
    public int UserId { get; init; }
    public int StockId { get; init; }
    public decimal Quantity { get; init; }

    public bool IsValid() =>
        UserId > 0 &&
        StockId > 0 &&
        Quantity > 0;
}
