namespace Exchange_Example_Api.Features.DepositCash;

public interface IDepositCashService
{
    Task<DepositCashResult> DepositCashAsync(Guid userId, double amount, CancellationToken cancellationToken = default);
}
