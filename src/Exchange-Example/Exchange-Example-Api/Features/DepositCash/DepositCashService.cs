using Exchange_Example_Api.Data;

namespace Exchange_Example_Api.Features.DepositCash;

public class DepositCashService(AppDbContext appDbContext) : IDepositCashService
{
    public async Task<DepositCashResult> DepositCashAsync(Guid userId, double amount, CancellationToken cancellationToken = default)
    {
        var user = await appDbContext.Users.FindAsync([userId], cancellationToken);
        if (user == null)
        {
            return DepositCashResult.UserNotFound;
        }

        user.Balance += amount;
        await appDbContext.SaveChangesAsync(cancellationToken);
        return DepositCashResult.Success;
    }
}
