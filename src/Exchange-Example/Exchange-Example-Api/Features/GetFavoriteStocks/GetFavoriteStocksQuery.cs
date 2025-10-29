using Exchange_Example_Api.Utils;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetFavoriteStocks;

public sealed class GetFavoriteStocksQuery : Query, IValidatable
{
    public Guid UserId { get; init; }

    public bool IsValid()
    {
        return UserId != Guid.Empty;
    }
}
