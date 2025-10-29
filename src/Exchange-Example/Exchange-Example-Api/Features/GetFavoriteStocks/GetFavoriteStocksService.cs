using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.GetFavoriteStocks;

public class GetFavoriteStocksService(AppDbContext appDbContext) : IGetFavoriteStocksService
{
    public async Task<List<Stock>> GetFavoriteStocks(int userId, CancellationToken cancellationToken = default)
    {
        return await appDbContext.Users
            .Where(u => u.Id == userId)
            .SelectMany(u => u.FavoriteStocks)
            .Select(fs => fs.Stock)
            .ToListAsync(cancellationToken);
    }
}
