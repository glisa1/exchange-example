using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetUserStocks;

public sealed class GetUserStocksQuery : Query
{
    public required int UserId { get; init; }
}
