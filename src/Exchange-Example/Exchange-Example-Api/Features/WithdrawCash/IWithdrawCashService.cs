namespace Exchange_Example_Api.Features.WithdrawCash;

public interface IWithdrawCashService
{
    Task<WithdrawCashResult> Withdraw(Guid userId, double amount, CancellationToken cancellationToken = default);
}
