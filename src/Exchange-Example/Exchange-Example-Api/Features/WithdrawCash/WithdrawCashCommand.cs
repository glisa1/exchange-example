using Exchange_Example_Api.Utils;
using Exchange_Example_Api.Utils.Request;

namespace Exchange_Example_Api.Features.WithdrawCash;

public sealed class WithdrawCashCommand : Command, IValidatable
{
    public required Guid UserId { get; init; }
    public required double Amount { get; init; }

    public bool IsValid()
    {
        return UserId != Guid.Empty && Amount > 0;
    }
}
