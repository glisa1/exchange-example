using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.GetUserBalance;

public sealed class GetUserBalanceQuery : Query
{
    public required int UserId { get; init; }
}
