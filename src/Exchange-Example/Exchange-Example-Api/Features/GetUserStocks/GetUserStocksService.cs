using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.GetUserStocks;

public class GetUserStocksService(AppDbContext dbContext) : IGetUserStocksService
{
    public async Task<List<UserStocks>> GetUserStocksAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await dbContext.UserStocks
                .Where(us => us.UserId == userId)
                .ToListAsync(cancellationToken);
    }
}
