namespace Exchange_Example_Api.Features.GetUserBalance;

public interface IGetUserBalanceService
{
    Task<double> GetBalanceAsync(Guid userId, CancellationToken cancellationToken = default);
}
