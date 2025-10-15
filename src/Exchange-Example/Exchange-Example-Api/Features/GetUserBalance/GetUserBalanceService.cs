
using Exchange_Example_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.GetUserBalance;

public class GetUserBalanceService(AppDbContext dbContext) : IGetUserBalanceService
{
    public async Task<double> GetBalanceAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users
            .Where(u => u.KeycloakId == userId)
            .Select(u => u.Balance)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
