namespace Exchange_Example_Api.Features.GetUserBalance;

public interface IGetUserBalanceService
{
    Task<double> GetBalanceAsync(int userId, CancellationToken cancellationToken = default);
}
