
using Exchange_Example_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.WithdrawCash;

public class WithdrawCashService(AppDbContext appDbContext) : IWithdrawCashService
{
    public async Task<WithdrawCashResult> Withdraw(Guid userId, double amount, CancellationToken cancellationToken = default)
    {
        var user = await appDbContext.Users.SingleOrDefaultAsync(u => u.KeycloakId == userId, cancellationToken);
        if (user == null)
        {
            return WithdrawCashResult.UserNotFound;
        }

        if (user.Balance <= amount)
        {
            return WithdrawCashResult.InsufficientFunds;
        }

        user.Balance -= amount;
        await appDbContext.SaveChangesAsync(cancellationToken);
        return WithdrawCashResult.Success;
    }
}
