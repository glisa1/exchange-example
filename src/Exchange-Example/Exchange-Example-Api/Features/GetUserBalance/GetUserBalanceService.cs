
using Exchange_Example_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.GetUserBalance;

public class GetUserBalanceService(AppDbContext dbContext) : IGetUserBalanceService
{
    public async Task<double> GetBalanceAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users
            .Where(u => u.Id == userId)
            .Select(u => u.Balance)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
