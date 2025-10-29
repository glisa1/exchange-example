using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Features.GetFavoriteStocks;

public class GetFavoriteStocksService(AppDbContext appDbContext) : IGetFavoriteStocksService
{
    public async Task<List<Stock>> GetFavoriteStocks(Guid userId, CancellationToken cancellationToken = default)
    {
        // TODO: Query does not seem to work
        return await appDbContext.Users
            .Where(u => u.KeycloakId == userId)
            .SelectMany(u => u.FavoriteStocks)
            .Select(fs => fs.Stock)
            .ToListAsync(cancellationToken);
    }
}
